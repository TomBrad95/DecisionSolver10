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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Decision10
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        BitmapImage coinImage = new BitmapImage();
        BitmapImage DiceImage = new BitmapImage();
        BitmapImage RPSImage = new BitmapImage();
        string Choice;
        string MultipleChoice;
        public MainPage()
        {
            InitializeComponent();
            bool IsHardwareButtonsAPIPresent = Windows.Foundation.Metadata.ApiInformation.IsTypePresent("Windows.Phone.UI.Input.HardwareButtons");
            if (IsHardwareButtonsAPIPresent)
            {
                Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
            }

            CurrencyCB.Visibility = Visibility.Visible;
            CurrencyCB.Visibility = Visibility.Visible;
            DiceColour.Visibility = Visibility.Visible;
            DiceColour.Visibility = Visibility.Visible;
            MultipleDice.Visibility = Visibility.Visible;
            MultipleDice.Visibility = Visibility.Visible;
            RPSDesign.Visibility = Visibility.Visible;
            RPSDesign.Visibility = Visibility.Visible;
        }

        private void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                Frame.GoBack();
                e.Handled = true;
            }
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

        private void MoreApps_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(More));
        }

        private void btn_randomCoin_Click(object sender, RoutedEventArgs e)
        {
            RandomButton("Coin");
        }

        private void CurrencyCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = CurrencyCB.SelectedItem as ComboBoxItem;
            if (cbi != null)
            {
                Choice = cbi.Content.ToString();
            }
        }

        private void btn_randomDice_Click(object sender, RoutedEventArgs e)
        {
            RandomButton("Dice");
        }

        private void DiceColour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = DiceColour.SelectedItem as ComboBoxItem;
            if (cbi != null)
            {
                Choice = cbi.Content.ToString();
            }
        }

        private void MultipleDice_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = MultipleDice.SelectedItem as ComboBoxItem;
            if (cbi != null)
            {
                MultipleChoice = cbi.Content.ToString();
            }
        }

        private void btn_randomRPS_Click(object sender, RoutedEventArgs e)
        {
            RandomButton("RPS");
        }

        private void RPSDesign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem cbi = RPSDesign.SelectedItem as ComboBoxItem;
            if (cbi != null)
            {
                Choice = cbi.Content.ToString();
            }
        }

        public void RandomButton(String selection)
        {
            if (selection == "Coin")
            {
                Random CR = new Random();
                int CoinRandom = CR.Next(1, 3);
                if (Choice == "Great British Pounds")
                {
                    if (CoinRandom == 1)
                    {
                        txt_responseCoin.Text = "Heads";
                        coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Heads-GB.png");
                    }
                    if (CoinRandom == 2)
                    {
                        txt_responseCoin.Text = "Tails";
                        coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Tails-GB.png");
                    }
                }
                else
                {
                    if (Choice == "US Dollar")
                    {
                        if (CoinRandom == 1)
                        {
                            coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Heads-US.png");
                            txt_responseCoin.Text = "Heads";
                        }
                        if (CoinRandom == 2)
                        {
                            txt_responseCoin.Text = "Tails";
                            coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Tails-US.png");
                        }
                    }
                    else
                    {
                        if (CoinRandom == 1)
                        {
                            coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Heads.png");
                            txt_responseCoin.Text = "";
                        }
                        if (CoinRandom == 2)
                        {
                            txt_responseCoin.Text = "";
                            coinImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Tails.png");
                        }
                    }
                }
                img_coin.Source = coinImage;
            }
            else if (selection == "Dice")
            {
                int DiceRandom;
                Random DR = new Random();
                if (MultipleChoice == "1-12")
                {
                    DiceRandom = DR.Next(1, 13);
                }
                else
                {
                    if (MultipleChoice == "1-18")
                    {
                        DiceRandom = DR.Next(1, 19);
                    }
                    else
                    {
                        DiceRandom = DR.Next(1, 7);
                    }
                }
                if (Choice == "Black on White")
                {
                    if (DiceRandom == 1)
                    {
                        txt_responseDice.Text = "1";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/one_invert.png");
                    }
                    if (DiceRandom == 2)
                    {
                        txt_responseDice.Text = "2";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/two_invert.png");
                    }
                    if (DiceRandom == 3)
                    {
                        txt_responseDice.Text = "3";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/three_invert.png");
                    }
                    if (DiceRandom == 4)
                    {
                        txt_responseDice.Text = "4";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/four_invert.png");
                    }
                    if (DiceRandom == 5)
                    {
                        txt_responseDice.Text = "5";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/five_invert.png");
                    }
                    if (DiceRandom == 6)
                    {
                        txt_responseDice.Text = "6";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/six_invert.png");
                    }
                    if (DiceRandom == 7)
                    {
                        txt_responseDice.Text = "7";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/seven_invert.png");
                    }
                    if (DiceRandom == 8)
                    {
                        txt_responseDice.Text = "8";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eight_invert.png");
                    }
                    if (DiceRandom == 9)
                    {
                        txt_responseDice.Text = "9";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/nine_invert.png");
                    }
                    if (DiceRandom == 10)
                    {
                        txt_responseDice.Text = "10";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/ten_invert.png");
                    }
                    if (DiceRandom == 11)
                    {
                        txt_responseDice.Text = "11";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eleven_invert.png");
                    }
                    if (DiceRandom == 12)
                    {
                        txt_responseDice.Text = "12";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/twelve_invert.png");
                    }
                    if (DiceRandom == 13)
                    {
                        txt_responseDice.Text = "13";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/thirteen_invert.png");
                    }
                    if (DiceRandom == 14)
                    {
                        txt_responseDice.Text = "14";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/fourteen_invert.png");
                    }
                    if (DiceRandom == 15)
                    {
                        txt_responseDice.Text = "15";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/fifteen_invert.png");
                    }
                    if (DiceRandom == 16)
                    {
                        txt_responseDice.Text = "16";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/sixteen_invert.png");
                    }
                    if (DiceRandom == 17)
                    {
                        txt_responseDice.Text = "17";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/seventeen_invert.png");
                    }
                    if (DiceRandom == 18)
                    {
                        txt_responseDice.Text = "18";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eighteen_invert.png");
                    }
                }
                else
                {
                    if (DiceRandom == 1)
                    {
                        txt_responseDice.Text = "1";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/one.png");
                    }
                    if (DiceRandom == 2)
                    {
                        txt_responseDice.Text = "2";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/two.png");
                    }
                    if (DiceRandom == 3)
                    {
                        txt_responseDice.Text = "3";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/three.png");
                    }
                    if (DiceRandom == 4)
                    {
                        txt_responseDice.Text = "4";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/four.png");
                    }
                    if (DiceRandom == 5)
                    {
                        txt_responseDice.Text = "5";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/five.png");
                    }
                    if (DiceRandom == 6)
                    {
                        txt_responseDice.Text = "6";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/six.png");
                    }
                    if (DiceRandom == 7)
                    {
                        txt_responseDice.Text = "7";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/seven.png");
                    }
                    if (DiceRandom == 8)
                    {
                        txt_responseDice.Text = "8";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eight.png");
                    }
                    if (DiceRandom == 9)
                    {
                        txt_responseDice.Text = "9";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/nine.png");
                    }
                    if (DiceRandom == 10)
                    {
                        txt_responseDice.Text = "10";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/ten.png");
                    }
                    if (DiceRandom == 11)
                    {
                        txt_responseDice.Text = "11";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eleven.png");
                    }
                    if (DiceRandom == 12)
                    {
                        txt_responseDice.Text = "12";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/twelve.png");
                    }
                    if (DiceRandom == 13)
                    {
                        txt_responseDice.Text = "13";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/thirteen.png");
                    }
                    if (DiceRandom == 14)
                    {
                        txt_responseDice.Text = "14";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/fourteen.png");
                    }
                    if (DiceRandom == 15)
                    {
                        txt_responseDice.Text = "15";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/fifteen.png");
                    }
                    if (DiceRandom == 16)
                    {
                        txt_responseDice.Text = "16";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/sixteen.png");
                    }
                    if (DiceRandom == 17)
                    {
                        txt_responseDice.Text = "17";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/seventeen.png");
                    }
                    if (DiceRandom == 18)
                    {
                        txt_responseDice.Text = "18";
                        DiceImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/eighteen.png");
                    }
                }
                img_dice.Source = DiceImage;
            }
            else if (selection == "RPS")
            {
                Random RPSR = new Random();
                int RPSRandom = RPSR.Next(1, 4);
                if (Choice == "Hands")
                {
                    if (RPSRandom == 1)
                    {
                        txt_responseRPS.Text = "Rock";
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/rockHand.png");
                    }
                    if (RPSRandom == 2)
                    {
                        txt_responseRPS.Text = "Paper";
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/paperHand.png");
                    }
                    if (RPSRandom == 3)
                    {
                        txt_responseRPS.Text = "Scissors";
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/ScissorsHand.png");
                    }
                }
                else
                {
                    if (RPSRandom == 1)
                    {
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/rock.png");
                    }
                    if (RPSRandom == 2)
                    {
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/paper.png");
                    }
                    if (RPSRandom == 3)
                    {
                        RPSImage.UriSource = new Uri(this.BaseUri, "/Assets/additionals/Scissors.png");
                    }
                }
                img_RPS.Source = RPSImage;
            }
        }

        private void Coin_Click(object sender, RoutedEventArgs e)
        {
            MainPivot.SelectedItem = CoinFrame;
        }

        private void Dice_Click(object sender, RoutedEventArgs e)
        {
            MainPivot.SelectedItem = DiceFrame;
        }

        private void RPS_Click(object sender, RoutedEventArgs e)
        {
            MainPivot.SelectedItem = RPSFrame;
        }
    }
}
