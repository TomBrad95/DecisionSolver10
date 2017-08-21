using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Decision10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class More : Page
    {
        public More()
        {
            InitializeComponent();
            bool IsHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (IsHardwareButtonsAPIPresent)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void PercentageFree_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("http://bit.ly/MoreAppsPercentage");
        }

        private async void LaunchSite(string Address)
        {
            try
            {
                Uri uri = new Uri(Address);
                var launched = await Windows.System.Launcher.LaunchUriAsync(uri);
            }
            catch (Exception)
            {
                //handle the exception
            }
        }

        private void MoreApps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(More));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Contact_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private void BillSplit_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("http://bit.ly/BillSplit");
        }

        private void Volume_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("http://bit.ly/HeadphoneRemover");
        }
    }
}
