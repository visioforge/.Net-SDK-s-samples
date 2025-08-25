using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace MMT_MAUI.Controls
{
    /// <summary>
    /// Custom tab view control to replace Syncfusion TabView
    /// </summary>
    public class CustomTabView : ContentView
    {
        private readonly Grid _mainGrid;
        private readonly ScrollView _tabHeaderScrollView;
        private readonly HorizontalStackLayout _tabHeaders;
        private readonly ContentView _contentArea;
        private readonly BoxView _indicator;
        private readonly ObservableCollection<TabItem> _items;
        private TabItem _selectedItem;

        public static readonly BindableProperty TabBarBackgroundProperty =
            BindableProperty.Create(nameof(TabBarBackground), typeof(Color), typeof(CustomTabView), Colors.White);

        public static readonly BindableProperty IndicatorBackgroundProperty =
            BindableProperty.Create(nameof(IndicatorBackground), typeof(Color), typeof(CustomTabView), Color.FromArgb("#007ACC"));

        public static readonly BindableProperty TabBarPlacementProperty =
            BindableProperty.Create(nameof(TabBarPlacement), typeof(TabBarPlacement), typeof(CustomTabView), TabBarPlacement.Top);

        public Color TabBarBackground
        {
            get => (Color)GetValue(TabBarBackgroundProperty);
            set => SetValue(TabBarBackgroundProperty, value);
        }

        public Color IndicatorBackground
        {
            get => (Color)GetValue(IndicatorBackgroundProperty);
            set => SetValue(IndicatorBackgroundProperty, value);
        }

        public TabBarPlacement TabBarPlacement
        {
            get => (TabBarPlacement)GetValue(TabBarPlacementProperty);
            set => SetValue(TabBarPlacementProperty, value);
        }

        public ObservableCollection<TabItem> Items => _items;

        public CustomTabView()
        {
            _items = new ObservableCollection<TabItem>();
            _items.CollectionChanged += OnItemsCollectionChanged;

            // Create main grid layout
            _mainGrid = new Grid();

            // Create tab headers container
            _tabHeaders = new HorizontalStackLayout
            {
                Spacing = 0
            };

            _tabHeaderScrollView = new ScrollView
            {
                Orientation = ScrollOrientation.Horizontal,
                HorizontalScrollBarVisibility = ScrollBarVisibility.Never,
                Content = _tabHeaders
            };

            // Create indicator
            _indicator = new BoxView
            {
                HeightRequest = 3,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.End,
                IsVisible = false
            };

            // Create content area
            _contentArea = new ContentView();

            // Setup layout based on tab placement
            SetupLayout();

            Content = _mainGrid;

            // Bind properties
            this.SetBinding(BackgroundColorProperty, new Binding(nameof(TabBarBackground), source: this));
            _indicator.SetBinding(BoxView.ColorProperty, new Binding(nameof(IndicatorBackground), source: this));
        }

        private void SetupLayout()
        {
            _mainGrid.Children.Clear();
            _mainGrid.RowDefinitions.Clear();
            _mainGrid.ColumnDefinitions.Clear();

            if (TabBarPlacement == TabBarPlacement.Top)
            {
                _mainGrid.RowDefinitions.Add(new RowDefinition { Height = 50 });
                _mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });

                var tabContainer = new Grid
                {
                    BackgroundColor = TabBarBackground,
                    Children = { _tabHeaderScrollView, _indicator }
                };

                Grid.SetRow(tabContainer, 0);
                Grid.SetRow(_contentArea, 1);

                _mainGrid.Children.Add(tabContainer);
                _mainGrid.Children.Add(_contentArea);
            }
            else // Bottom placement
            {
                _mainGrid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star });
                _mainGrid.RowDefinitions.Add(new RowDefinition { Height = 50 });

                var tabContainer = new Grid
                {
                    BackgroundColor = TabBarBackground,
                    Children = { _tabHeaderScrollView, _indicator }
                };

                Grid.SetRow(_contentArea, 0);
                Grid.SetRow(tabContainer, 1);

                _mainGrid.Children.Add(_contentArea);
                _mainGrid.Children.Add(tabContainer);
            }
        }

        private void OnItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (TabItem item in e.NewItems)
                {
                    AddTabHeader(item);
                }
            }

            if (e.OldItems != null)
            {
                foreach (TabItem item in e.OldItems)
                {
                    RemoveTabHeader(item);
                }
            }

            // Select first tab if none selected
            if (_selectedItem == null && _items.Count > 0)
            {
                SelectTab(_items[0]);
            }
        }

        private void AddTabHeader(TabItem item)
        {
            var headerLabel = new Label
            {
                Text = item.Header,
                Padding = new Thickness(20, 15),
                FontSize = 14,
                TextColor = Colors.Black,
                VerticalTextAlignment = TextAlignment.Center,
                HorizontalTextAlignment = TextAlignment.Center
            };

            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += (s, e) => SelectTab(item);
            headerLabel.GestureRecognizers.Add(tapGesture);

            item.HeaderLabel = headerLabel;
            _tabHeaders.Children.Add(headerLabel);
        }

        private void RemoveTabHeader(TabItem item)
        {
            if (item.HeaderLabel != null)
            {
                _tabHeaders.Children.Remove(item.HeaderLabel);
                item.HeaderLabel = null;
            }
        }

        private void SelectTab(TabItem item)
        {
            if (_selectedItem == item)
                return;

            // Update previous selected tab
            if (_selectedItem != null && _selectedItem.HeaderLabel != null)
            {
                _selectedItem.HeaderLabel.FontAttributes = FontAttributes.None;
                _selectedItem.HeaderLabel.TextColor = Colors.Black;
            }

            _selectedItem = item;

            // Update new selected tab
            if (_selectedItem != null)
            {
                if (_selectedItem.HeaderLabel != null)
                {
                    _selectedItem.HeaderLabel.FontAttributes = FontAttributes.Bold;
                    _selectedItem.HeaderLabel.TextColor = IndicatorBackground;

                    // Update indicator position
                    UpdateIndicatorPosition();
                }

                // Update content
                _contentArea.Content = _selectedItem.Content;
            }
        }

        private async void UpdateIndicatorPosition()
        {
            if (_selectedItem?.HeaderLabel == null)
                return;

            _indicator.IsVisible = true;

            // Wait for layout to complete
            await Task.Delay(10);

            var headerBounds = _selectedItem.HeaderLabel.Bounds;
            _indicator.TranslationX = headerBounds.X;
            _indicator.WidthRequest = headerBounds.Width;
        }

        public void AddTab(string header, View content)
        {
            var tabItem = new TabItem
            {
                Header = header,
                Content = content
            };
            Items.Add(tabItem);
        }

        public void SelectTabAt(int index)
        {
            if (index >= 0 && index < _items.Count)
            {
                SelectTab(_items[index]);
            }
        }
    }

    /// <summary>
    /// Represents a single tab item
    /// </summary>
    public class TabItem
    {
        public string Header { get; set; }
        public View Content { get; set; }
        internal Label HeaderLabel { get; set; }
    }

    /// <summary>
    /// Tab bar placement options
    /// </summary>
    public enum TabBarPlacement
    {
        Top,
        Bottom
    }
}