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
        public static string[] pages = { "main", "buyOptions", "menu", "beverage", "recipe", "payment", "thankYou" };
    }

}
