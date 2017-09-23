using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace OriginStudio
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            MainFrame.Navigate(typeof(Views.Dashboard));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            SideSplitView.IsPaneOpen = !SideSplitView.IsPaneOpen;
        }

        private void IconItemListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListBoxItem selectedItem = (ListBoxItem)IconItemListBox.SelectedItem;
            switch(selectedItem.Name)
            {
                case "Lookups":
                    ViewsTitle.Text = "Lookups";
                    MainFrame.Navigate(typeof(Views.Lookups));
                    break;
                default:
                    ViewsTitle.Text = "Dashboard";
                    MainFrame.Navigate(typeof(Views.Dashboard));
                    break;
            }
        }

    }
}
