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
    public sealed partial class About : Page
    {
        public About()
        {
            InitializeComponent();
            bool IsHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (IsHardwareButtonsAPIPresent)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }
            GraphicsDetails.Visibility = Visibility.Visible;
            NBCreative.Visibility = Visibility.Visible;
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
        }

        private void Home_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void ContactMe_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(About));
        }

        private async void Mail()
        {
            var mailto = new Uri("mailto:?to=DSW10+issue@TomBrad95.yodizemail.com&subject=&body=");
            await Windows.System.Launcher.LaunchUriAsync(mailto);
        }

        private void email_Click(object sender, RoutedEventArgs e)
        {
            Mail();
        }

        private void Twitter_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("https://twitter.com/TomBrad95");
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

        private void NBCreative_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("http://www.nb-creative.co.uk/");
        }

        private void MoreApps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(More));
        }

        private void TwitterHashtag_Click(object sender, RoutedEventArgs e)
        {
            LaunchSite("http://bit.ly/DecisionHash");
        }
    }
}