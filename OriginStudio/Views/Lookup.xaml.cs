using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using OriginStudio.LookupService;

namespace OriginStudio.Views
{
    public sealed partial class Lookup : Page
    {

        private OR_Lookup _currentLookup;

        #region Constructor

        public Lookup()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Protected Events

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _currentLookup =  (OR_Lookup)e.Parameter;
            showLoading();
            LookupName.Text = _currentLookup.Name;
            getLookupValues();
        }

        #endregion

        #region Private Events

        private void SaveLookupButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddLookupValueButton_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region Private Functions

        private async Task getLookupValues()
        {
            // popolate the listBox with the lookups received from the DB
            LookupServiceClient client = new LookupServiceClient();
            List<OR_LookupValue> lookupValues = new List<OR_LookupValue>(await client.GetValuesByLookupAsync(_currentLookup.OriginId));

            //set the result to UI
            LookupValueListBox.ItemsSource = lookupValues;
            hideLoading();
        }

        private void hideLoading()
        {
            LoadingTextBlock.Visibility = Visibility.Collapsed;
            LookupName.Visibility = Visibility.Visible;
            LookupValueListBox.Visibility = Visibility.Visible;
            AddLookupValueButton.Visibility = Visibility.Visible;
        }

        private void showLoading()
        {
            LoadingTextBlock.Visibility = Visibility.Visible;
            LookupName.Visibility = Visibility.Collapsed;
            LookupValueListBox.Visibility = Visibility.Collapsed;
            AddLookupValueButton.Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
