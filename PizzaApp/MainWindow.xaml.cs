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
        BuyOption option = BuyOption.buyPizza;

        Page mainPage = new MainPage();
        Page buyOptionPage = new BuyOptionPage();
        Page menuPage = new MenuPage();
        Page ingredientPage = new IngredientPage();
        Page beveragePage = new BeveragePage();
        Page recipePage = new RecipePage();
        Page paymentPage = new PaymentPage();
        Page thankYouPage = new ThankYouPage();

        public MainWindow()
        {
            InitializeComponent();
            Main.Content = getCurrentPage(currentPageIndex);
            updateWindow();
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
            if (Config.pages[currentPageIndex] == "buyOptions")
            {
                makePizzaCheckbox.Visibility = Visibility.Visible;
            } else
            {
                makePizzaCheckbox.Visibility = Visibility.Hidden;
            }
            BuyPizzaStatusGrid.Visibility = Visibility.Hidden;
            MakePizzaStatusGrid.Visibility = Visibility.Hidden;
            if (option == BuyOption.buyPizza)
            {
                if (Config.pages[currentPageIndex] == "menu")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                }
                else if (Config.pages[currentPageIndex] == "beverage")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                }
                else if (Config.pages[currentPageIndex] == "payment")
                {
                    BuyPizzaStatusGrid.Visibility = Visibility.Visible;
                    rb01.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb02.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb03.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb01.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb02.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb03.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
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
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                }
                else if (Config.pages[currentPageIndex] == "beverage")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                }
                else if (Config.pages[currentPageIndex] == "recipe")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusDefaultColor);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusLabelDefaultColor);
                }
                else if (Config.pages[currentPageIndex] == "payment")
                {
                    MakePizzaStatusGrid.Visibility = Visibility.Visible;
                    rb11.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb12.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb13.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    rb14.Background = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb11.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb12.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb13.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
                    statuslb14.Foreground = (Brush)new BrushConverter().ConvertFrom(Config.statusActiveColor);
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

        private void MakePizzaCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            option = (makePizzaCheckbox.IsChecked ?? false) ? BuyOption.makePizza : BuyOption.buyPizza;
        }
    }
}
