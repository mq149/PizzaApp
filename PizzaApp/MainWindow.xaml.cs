using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        int currentPageIndex = 0;
        bool isCartPageShowing = false;
        BuyOption option = BuyOption.buyPizza;

        Page mainPage = new MainPage();
        Page buyOptionPage = new BuyOptionPage();
        Page menuPage = new MenuPage();
        Page ingredientPage = new IngredientPage();
        Page beveragePage = new BeveragePage();
        Page recipePage = new RecipePage();
        Page paymentPage = new PaymentPage();
        Page thankYouPage = new ThankYouPage();
        Page cartPage = new CartPage();

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = getCurrentPage(currentPageIndex);
            updateWindow();
        }

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                nextPage(option);
                Main.Content = getCurrentPage(currentPageIndex);
            } else if (e.Key == Key.Left)
            {
                backPage(option);
                Main.Content = getCurrentPage(currentPageIndex);
            }
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            backPage(option);
            Main.Content = getCurrentPage(currentPageIndex);
 
        }

        private void nextButtonClick(object sender, RoutedEventArgs e)
        {
            nextPage(option);
            Main.Content = getCurrentPage(currentPageIndex);
        }

        private void nextPage(BuyOption option)
        {
            if (currentPageIndex >= Config.pages.Length - 1)
            {
                currentPageIndex = 0;
            } else
            {
                currentPageIndex += 1;
            }
            if (option == BuyOption.buyPizza)
            {
                if (Config.pages[currentPageIndex] == "recipe")
                {
                    currentPageIndex += 1;
                }
                if (Config.pages[currentPageIndex] == "ingredients")
                {
                    currentPageIndex += 1;
                }
            }
            if (option == BuyOption.makePizza)
            {
                if (Config.pages[currentPageIndex] == "menu")
                {
                    currentPageIndex += 1;
                }
            }
            updateWindow();
        }

        private void backPage(BuyOption option)
        {
            if (isCartPageShowing)
            {
                Main.Content = getCurrentPage(currentPageIndex);
                isCartPageShowing = false;
                nextButton.Visibility = Visibility.Visible;
                updateWindow();
                return;
            }
            if (currentPageIndex == 0)
            {
                //currentPageIndex = Config.pages.Length - 1;
            } else
            {
                currentPageIndex -= 1;
            }
            if (option == BuyOption.buyPizza)
            {
                if (Config.pages[currentPageIndex] == "recipe")
                {
                    currentPageIndex -= 1;
                }
                if (Config.pages[currentPageIndex] == "ingredients")
                {
                    currentPageIndex -= 1;
                }
            }
            if (option == BuyOption.makePizza)
            {
                if (Config.pages[currentPageIndex] == "menu")
                {
                    currentPageIndex -= 1;
                }
            }
            updateWindow();
        }

        private void updateWindow()
        {
            // back and next Button
            backButton.Visibility = Visibility.Hidden;
            nextButton.Visibility = Visibility.Hidden;
            if (Config.pages[currentPageIndex] == "menu" || Config.pages[currentPageIndex] == "ingredients" ||
                Config.pages[currentPageIndex] == "beverage" || Config.pages[currentPageIndex] == "recipe" || Config.pages[currentPageIndex] == "payment")
            {
                backButton.Visibility = Visibility.Visible;
                nextButton.Visibility = Visibility.Visible;
                backButton.Background = (Brush)new BrushConverter().ConvertFrom(Config.red);
                backButton.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.white);
                nextButton.Background = (Brush)new BrushConverter().ConvertFrom(Config.red);
                nextButton.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.white);
                backButton.Content = "Quay lại";
                nextButton.Content = "Tiếp tục";
                if (isCartPageShowing)
                {
                    backButton.Visibility = Visibility.Hidden;
                    nextButton.Visibility = Visibility.Hidden;
                }
                if (Config.pages[currentPageIndex] == "recipe")
                {
                    backButton.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    backButton.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    nextButton.Content = "Hoàn thành";
                } 
                if (Config.pages[currentPageIndex] == "payment")
                {
                    backButton.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    backButton.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    nextButton.Visibility = Visibility.Hidden;
                }
            }
            
            // buyOptions Grid 
            if (Config.pages[currentPageIndex] == "buyOptions")
            {
                buyOptionsGrid.Visibility = Visibility.Visible;
            } else
            {
                buyOptionsGrid.Visibility = Visibility.Hidden;
            }
            // pay Button
            if (Config.pages[currentPageIndex] == "payment")
            {
                payButton.Visibility = Visibility.Visible;
            }
            else
            {
                payButton.Visibility = Visibility.Hidden;
            }
            // backToMenu Button
            if (Config.pages[currentPageIndex] == "thankYou")
            {
                backToMenuButton.Visibility = Visibility.Visible;
            }
            else
            {
                backToMenuButton.Visibility = Visibility.Hidden;
            }
            // status Grid
            BuyPizzaStatusGrid.Visibility = Visibility.Hidden;
            MakePizzaStatusGrid.Visibility = Visibility.Hidden;
            // cart Button
            if (isCartPageShowing)
            {
                cartButton.Visibility = Visibility.Hidden;
                return;
            }
            else
            {
                cartButton.Visibility = Visibility.Visible;
            }
            if (Config.pages[currentPageIndex] == "menu" || Config.pages[currentPageIndex] == "beverage" || Config.pages[currentPageIndex] == "ingredients")
            {
                cartButton.Visibility = Visibility.Visible;
            } else
            {
                cartButton.Visibility = Visibility.Hidden;
            }
            // status Grid
            if (option == BuyOption.buyPizza)
            {
                if (Config.pages[currentPageIndex] == "menu")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                }
                else if (Config.pages[currentPageIndex] == "beverage")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                }
                else if (Config.pages[currentPageIndex] == "payment")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                }
                else
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Hidden;
                }
            }
            if (option == BuyOption.makePizza)
            {
                if (Config.pages[currentPageIndex] == "ingredients")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                }
                else if (Config.pages[currentPageIndex] == "beverage")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                }
                else if (Config.pages[currentPageIndex] == "recipe")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.white);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.black);
                }
                else if (Config.pages[currentPageIndex] == "payment")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.green);
                }
                else
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Hidden;
                }
            }
        }

        private Page getCurrentPage(int currentPageIndex)
        {
            switch (Config.pages[currentPageIndex])
            {
                case "main":
                    return mainPage;
                case "buyOptions":
                    return buyOptionPage;
                case "menu":
                    return menuPage;
                case "beverage":
                    return beveragePage;
                case "ingredients":
                    return ingredientPage;
                case "recipe":
                    return recipePage;
                case "payment":
                    return paymentPage;
                case "thankYou":
                    return thankYouPage;
                default:
                    break;
            }
            return new Page();
        }

        public void goToPage(string pageId)
        {
            switch (pageId)
            {
                case "main":
                    Main.Content = mainPage;
                    break;
                case "buyOptions":
                    Main.Content = buyOptionPage;
                    break;
                case "menu":
                    Main.Content = menuPage;
                    break;
                case "ingredients":
                    Main.Content = ingredientPage;
                    break;
                case "beverage":
                    Main.Content = beveragePage;
                    break;
                case "recipe":
                    Main.Content = recipePage;
                    break;
                case "payment":
                    Main.Content = paymentPage;
                    break;
                case "thankYou":
                    Main.Content = thankYouPage;
                    break;
                default:
                    break;
            }
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = cartPage;
            isCartPageShowing = true;
            nextButton.Visibility = Visibility.Hidden;
            updateWindow();
            backToMenuButton.Visibility = Visibility.Visible;
        }

        private void buyPizzaButton_Click(object sender, RoutedEventArgs e)
        {
            option = BuyOption.buyPizza;
            nextPage(option);
            Main.Content = getCurrentPage(currentPageIndex);

        }

        private void MakePizzaButton_Click(object sender, RoutedEventArgs e)
        {
            option = BuyOption.makePizza;
            nextPage(option);
            Main.Content = getCurrentPage(currentPageIndex);
        }

        private void BackToMenuButton_Click(object sender, RoutedEventArgs e)
        {
            if (isCartPageShowing)
            {
                backPage(option);
                Main.Content = getCurrentPage(currentPageIndex);
                backToMenuButton.Visibility = Visibility.Visible;
            } else
            {
                nextPage(option);
                Main.Content = getCurrentPage(currentPageIndex);
            }
        }

        private void PayButton_Click(object sender, RoutedEventArgs e)
        {
            nextPage(option);
            Main.Content = getCurrentPage(currentPageIndex);
        }
    }
}
