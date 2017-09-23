using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using System.Threading.Tasks;
using System.Collections.Generic;
using OriginStudio.LookupService;

namespace OriginStudio.Views
{
    public sealed partial class Lookups : Page
    {
        #region Construnctor

        public Lookups()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Protected Events

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            showLoading();
            setLookups();
        }

        #endregion

        #region Private Events

        private void AddLookupButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LookupListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OR_Lookup selectedLookup = (OR_Lookup)LookupListBox.SelectedItem;
            Frame.Navigate(typeof(Lookup), selectedLookup);
        }

        #endregion

        #region Private Functions

        private async Task setLookups()
        {
            // popolate the listBox with the lookups received from the DB
            LookupServiceClient client = new LookupServiceClient();
            List<OR_Lookup> lookups = new List<OR_Lookup>(await client.GetLookupsAsync());

            //set the result to UI
            LookupListBox.ItemsSource = lookups;
            hideLoading();
        }

        private void hideLoading()
        {
            LookupListBox.Visibility = Visibility.Visible;
            LoadingTextBlock.Visibility = Visibility.Collapsed;
        }

        private void showLoading()
        {
            LookupListBox.Visibility = Visibility.Collapsed;
            LoadingTextBlock.Visibility = Visibility.Visible;
        }

        #endregion
    }
}