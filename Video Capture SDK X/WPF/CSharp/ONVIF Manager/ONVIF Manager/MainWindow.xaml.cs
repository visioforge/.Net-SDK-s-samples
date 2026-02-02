using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using VisioForge.Core;
using VisioForge.Core.ONVIFX;

namespace ONVIF_Manager
{
    /// <summary>
    /// Interaction logic for the ONVIF Manager WPF demo's MainWindow.
    /// Demonstrates discovering, connecting to, and managing ONVIF-compliant devices, including retrieving device information, network settings, and profiles.
    /// </summary>
    public partial class MainWindow : Window
    {
        private ONVIFClientX? onvifClient;

        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
        }

        /// <summary>
        /// Handles the Loaded event of the MainWindow control.
        /// Initializes the SDK.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // Initialize the SDK
            await VisioForgeX.InitSDKAsync();
            Title += " (SDK Initialized)";
        }

        /// <summary>
        /// Handles the Click event of the btnConnect control.
        /// Attempts to connect to or disconnect from the ONVIF device using the provided credentials and URL.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private async void btnConnect_Click(object sender, RoutedEventArgs e)
        {
            string url = edURL.Text;
            string username = edUsername.Text;
            string password = edPassword.Text;            

            if (btnConnect.Content.ToString() == "Connect")
            {
                btnConnect.IsEnabled = false;
                btnConnect.Content = "Connecting...";

                try
                {
                    // Create ONVIF device and connect
                    onvifClient = new ONVIFClientX();
                    bool connected = await onvifClient.ConnectAsync(url, username, password);

                    if (!connected)
                    {
                        MessageBox.Show("Failed to connect to the device. Please check credentials and URL.", 
                            "Connection Failed", MessageBoxButton.OK, MessageBoxImage.Error);
                        await CleanupDeviceAsync();
                        return;
                    }

                    // Successfully connected
                    btnConnect.Content = "Disconnect";
                    await UpdateUI();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connecting to device: {ex.Message}", 
                        "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    await CleanupDeviceAsync();
                }
                finally
                {
                    btnConnect.IsEnabled = true;
                }
            }
            else
            {
                // Disconnect
                await CleanupDeviceAsync();
                btnConnect.Content = "Connect";
                ResetUI();
            }
        }

        /// <summary>
        /// Asynchronously retrieves and updates all device information in the UI.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdateUI()
        {
            if (onvifClient == null)
                return;

            try
            {
                // Basic device information
                txtModel.Text = onvifClient.DeviceInformation.Model ?? "-";
                txtFirmware.Text = onvifClient.DeviceInformation.FirmwareVersion ?? "-";
                txtSerialNumber.Text = onvifClient.DeviceInformation.SerialNumber ?? "-";
                txtHardwareId.Text = onvifClient.DeviceInformation.HardwareId ?? "-";
                txtManufacturer.Text = onvifClient.DeviceInformation.Manufacturer ?? "-";
                txtDeviceStatus.Text = "Connected";

                // Get system date and time
                var systemDateTime = await onvifClient.GetSystemDateAndTimeAsync();
                if (systemDateTime != null && systemDateTime.UTCDateTime != null)
                {
                    var dateTime = systemDateTime.UTCDateTime;
                    DateTime utcTime = new DateTime(
                        dateTime.Date.Year, dateTime.Date.Month, dateTime.Date.Day,
                        dateTime.Time.Hour, dateTime.Time.Minute, dateTime.Time.Second);
                    
                    txtDeviceTime.Text = utcTime.ToString("yyyy-MM-dd HH:mm:ss");
                    txtTimeSyncMethod.Text = systemDateTime.DateTimeType.ToString();
                }
                else
                {
                    txtDeviceTime.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                    txtTimeSyncMethod.Text = "Unknown";
                }

                // Get network interfaces to retrieve IP, MAC address and DHCP info
                await UpdateNetworkInformation();

                // Update profiles asynchronously
                UpdateProfiles();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating device information: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Asynchronously retrieves and updates network-specific information (IP, MAC, Gateway, DHCP) in the UI.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task UpdateNetworkInformation()
        {
            if (onvifClient == null)
                return;

            try
            {
                // Get network interfaces
                var networkInterfaces = await onvifClient.GetNetworkInterfacesAsync();
                
                if (networkInterfaces != null && networkInterfaces.Length > 0)
                {
                    // Get the first enabled network interface
                    var activeInterface = networkInterfaces.FirstOrDefault(ni => ni.Enabled);
                    
                    if (activeInterface != null)
                    {
                        // Get IPv4 configuration
                        if (activeInterface.IPv4 != null && activeInterface.IPv4.Config != null)
                        {
                            var ipv4Config = activeInterface.IPv4.Config;
                            
                            // DHCP status
                            txtDHCP.Text = ipv4Config.DHCP ? "Enabled" : "Disabled";
                            
                            // IP Address (take the first address from the manual list if available)
                            if (ipv4Config.Manual != null && ipv4Config.Manual.Length > 0)
                            {
                                var manualAddress = ipv4Config.Manual[0];
                                txtIPAddress.Text = $"{manualAddress.Address}/{manualAddress.PrefixLength}";
                            }
                            else if (ipv4Config.FromDHCP != null)
                            {
                                txtIPAddress.Text = $"{ipv4Config.FromDHCP.Address}/{ipv4Config.FromDHCP.PrefixLength}";
                            }
                        }
                        
                        // MAC Address
                        if (!string.IsNullOrEmpty(activeInterface.Info?.HwAddress))
                        {
                            txtMACAddress.Text = activeInterface.Info.HwAddress;
                        }
                    }
                }
                
                // Get Network Default Gateway
                var gateway = await onvifClient.GetNetworkDefaultGatewayAsync();
                if (gateway != null)
                {
                    if (gateway.IPv4Address != null && gateway.IPv4Address.Length > 0)
                    {
                        string gatewayText = txtIPAddress.Text;
                        if (gatewayText != "-" && !gatewayText.Contains("Gateway:"))
                        {
                            txtIPAddress.Text = $"{gatewayText} (Gateway: {gateway.IPv4Address[0]})";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error but don't show a message box since this is a sub-function
                Console.WriteLine($"Error getting network information: {ex.Message}");
            }
        }

        /// <summary>
        /// Asynchronously retrieves and updates available video and audio profiles from the ONVIF device.
        /// </summary>
        private async void UpdateProfiles()
        {
            if (onvifClient == null)
                return;

            try
            {
                // Clear existing items
                dgProfiles.Items.Clear();

                // Get profiles
                var profiles = await onvifClient.GetProfilesAsync();
                
                if (profiles != null)
                {
                    // Convert to list to avoid possible issues with Count property
                    var profileList = profiles.ToList();
                    
                    if (profileList.Any())
                    {
                        // Get RTSP URL
                        var firstProfile = profileList.First();
                        var streamUri = await onvifClient.GetStreamUriAsync(firstProfile);
                        txtRTSPUrl.Text = streamUri?.Uri ?? "-";

                        // Add profiles to grid
                        foreach (var profile in profileList)
                        {
                            var profileInfo = new ProfileInfo
                            {
                                Name = profile.Name ?? "-",
                                Resolution = $"{profile.VideoEncoderConfiguration.Resolution.Width}x{profile.VideoEncoderConfiguration.Resolution.Height}",
                                Encoding = profile.VideoEncoderConfiguration.Encoding.ToString() ?? "-",
                                Framerate = profile.VideoEncoderConfiguration.RateControl.FrameRateLimit.ToString(),
                                Bitrate = profile.VideoEncoderConfiguration.RateControl.BitrateLimit.ToString() + " Kbps"
                            };

                            // Add audio encoder information if available
                            if (profile.AudioEncoderConfiguration != null)
                            {
                                profileInfo.AudioEncoding = profile.AudioEncoderConfiguration.Encoding.ToString() ?? "-";
                                profileInfo.AudioBitrate = profile.AudioEncoderConfiguration.Bitrate.ToString() + " Kbps";
                                profileInfo.AudioSampleRate = profile.AudioEncoderConfiguration.SampleRate.ToString() + " Hz";
                            }
                            else
                            {
                                profileInfo.AudioEncoding = "No Audio";
                                profileInfo.AudioBitrate = "-";
                                profileInfo.AudioSampleRate = "-";
                            }

                            dgProfiles.Items.Add(profileInfo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error getting profiles: {ex.Message}", 
                    "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        /// <summary>
        /// Resets all device-related UI elements to their default "disconnected" states.
        /// </summary>
        private void ResetUI()
        {
            // Reset all UI elements to default values
            txtManufacturer.Text = "-";
            txtModel.Text = "-";
            txtFirmware.Text = "-";
            txtSerialNumber.Text = "-";
            txtHardwareId.Text = "-";
            txtIPAddress.Text = "-";
            txtMACAddress.Text = "-";
            txtDHCP.Text = "-";
            txtDeviceTime.Text = "-";
            txtTimeSyncMethod.Text = "-";
            txtDeviceStatus.Text = "Disconnected";
            txtRTSPUrl.Text = "-";
            dgProfiles.Items.Clear();
        }

        /// <summary>
        /// Asynchronously disposes of the current ONVIF client.
        /// </summary>
        /// <returns>A task representing the asynchronous operation.</returns>
        private async Task CleanupDeviceAsync()
        {
            if (onvifClient != null)
            {
                try
                {
                    onvifClient.Dispose();
                }
                catch { /* Ignore errors during cleanup */ }
                finally
                {
                    onvifClient = null;
                }
            }
        }

        /// <summary>
        /// Handles the Closing event of the MainWindow control.
        /// Ensures the ONVIF client is cleaned up and the SDK resources are released.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CancelEventArgs"/> instance containing the event data.</param>
        private async void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            await CleanupDeviceAsync();
            VisioForgeX.DestroySDK();
        }
    }

    /// <summary>
    /// Represents information about an ONVIF profile for display in the UI.
    /// </summary>
    public class ProfileInfo
    {
        public string Name { get; set; } = string.Empty;
        public string Resolution { get; set; } = string.Empty;
        public string Encoding { get; set; } = string.Empty;
        public string Framerate { get; set; } = string.Empty;
        public string Bitrate { get; set; } = string.Empty;
        // Audio encoder properties
        public string AudioEncoding { get; set; } = string.Empty;
        public string AudioBitrate { get; set; } = string.Empty;
        public string AudioSampleRate { get; set; } = string.Empty;
    }
}