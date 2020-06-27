using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaApp
{

    enum BuyOption
    {
        buyPizza,
        makePizza
    }

    class Config
    {
        public static string[] pages = { "buyOptions", "menu", "ingredients", "beverage", "recipe", "payment", "thankYou" };
        public static string white = "#FFFFFFFF"; // white
        public static string black = "#FF000000"; // black
        public static string green = "#FF63B995"; // green
        public static string red = "#FF8D0101"; // red

    }

}
