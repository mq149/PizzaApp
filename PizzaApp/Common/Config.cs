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
        public static string[] pages = { "main", "buyOptions", "menu", "ingredients", "beverage", "recipe", "payment", "thankYou" };
        public static string statusDefaultColor = "#FFFFFFFF";
        public static string statusLabelDefaultColor = "#FF000000";
        public static string statusActiveColor = "#FF63B995";

    }

}
