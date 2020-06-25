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

        Page mainPage = new MainPage();
        Page buyOptionPage = new BuyOptionPage();
        Page menuPage = new MenuPage();
        Page beveragePage = new BeveragePage();
        Page recipePage = new RecipePage();
        Page paymentPage = new PaymentPage();
        Page thankYouPage = new ThankYouPage();

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = getCurrentPage(currentPageIndex);

            this.Loaded += new RoutedEventHandler(mainPage_orderButtonClick);
        }

        private void backButtonClick(object sender, RoutedEventArgs e)
        {
            backPage(BuyOption.makePizza);
            Main.Content = getCurrentPage(currentPageIndex);
 
        }

        private void nextButtonClick(object sender, RoutedEventArgs e)
        {
            nextPage(BuyOption.makePizza);
            Main.Content = getCurrentPage(currentPageIndex);
        }

        void mainPage_orderButtonClick(object sender, RoutedEventArgs e)
        {

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
            }
        }

        private void backPage(BuyOption option)
        {
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
            switch (Config.pages[currentPageIndex])
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
    }
}
