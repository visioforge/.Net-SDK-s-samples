using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using VisioForge.Core;
using VisioForge.Core.UI.WebForms;

namespace HLS_Webcam_Web_Forms
{
    public partial class Default : Page
    {
        protected DropDownList cbVideo;
        protected DropDownList cbAudio;
        protected HlsPlayer player;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }

            // Device enumeration needs the SDK initialized; run it as a page async task.
            RegisterAsyncTask(new PageAsyncTask(async () =>
            {
                HlsStreamManager.EnsureSdkInitialized();

                foreach (var device in await DeviceEnumerator.Shared.VideoSourcesAsync())
                {
                    cbVideo.Items.Add(new ListItem(device.Name, device.Name));
                }

                foreach (var device in await DeviceEnumerator.Shared.AudioSourcesAsync())
                {
                    cbAudio.Items.Add(new ListItem(device.Name, device.Name));
                }
            }));
        }

        protected void btStart_Click(object sender, EventArgs e)
        {
            player.Source = "device://" + cbVideo.SelectedValue;
            player.AudioSource = cbAudio.SelectedValue.Length == 0 ? string.Empty : "device://" + cbAudio.SelectedValue;
        }

        protected void btStop_Click(object sender, EventArgs e)
        {
            player.Stop();
        }
    }
}
