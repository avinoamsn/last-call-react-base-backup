using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace LastCallBase.Controllers
{
    [Route("api/[controller]")]
    public class SuppliersController : Controller
    {
        private static MealOffer[] offers =
        {
            new MealOffer {
                ID = 1,
                DateFormatted = DateTime.Now.ToString("d"),
                mealSupplier = "Joe's Pizza",
                qtyAvailable = 45,
                mealName = "Pizza slice",
                foodType = "Pizza",
                mealDetails = "Pepperoni thin crust pizza",
                priceDollars = 2,
                priceCents = 99
           },
            new MealOffer {
                ID = 2,
                DateFormatted = DateTime.Now.ToString("d"),
                mealSupplier = "Inn N Out",
                qtyAvailable = 5,
                mealName = "Cheeseburger",
                foodType = "Burger",
                mealDetails = "World famous cheeseburger",
                priceDollars = 3,
                priceCents = 49
           },
            new MealOffer {
                ID = 3,
                DateFormatted = DateTime.Now.ToString("d"),
                mealSupplier = "Whole Foods",
                qtyAvailable = 10,
                mealName = "Chicken Madras",
                foodType = "Indian",
                mealDetails = "Mild chicken curry",
                priceDollars = 4,
                priceCents = 29
           },
        };

        [HttpGet("[action]")]
        public IEnumerable<MealOffer> RegisterSupplier()
        {
           return Enumerable.Range(0, offers.Length).Select(index => offers[index]);
        }

        public class MealOffer
        {
            public int ID { get; set; }
            public string DateFormatted { get; set; }
            public string mealSupplier { get; set; }
            public int qtyAvailable { get; set; }
            public string mealName { get; set; }
            public string foodType { get; set; }
            public string mealDetails { get; set; }
            public int priceDollars { get; set; }
            public int priceCents { get; set; }
        }
    }
}
