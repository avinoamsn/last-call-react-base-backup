using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace LastCallBase.Controllers
{
    [Route("api/[controller]")]
    public class SubscribersController : Controller
    {
        private static MealOffer[] offers =
        {
            new MealOffer {
                ID = 1,
                DateFormatted = DateTime.Now.ToString("d"),
                MealSupplier = "Joe's Pizza",
                QtyAvailable = 45,
                MealName = "Pizza slice",
                FoodType = "Pizza",
                MealDetails = "Pepperoni thin crust pizza",
                PriceDollars = 2,
                PriceCents = 99
           },
            new MealOffer {
                ID = 2,
                DateFormatted = DateTime.Now.ToString("d"),
                MealSupplier = "Inn N Out",
                QtyAvailable = 5,
                MealName = "Cheeseburger",
                FoodType = "Burger",
                MealDetails = "World famous cheeseburger",
                PriceDollars = 3,
                PriceCents = 49
           },
            new MealOffer {
                ID = 3,
                DateFormatted = DateTime.Now.ToString("d"),
                MealSupplier = "Whole Foods",
                QtyAvailable = 10,
                MealName = "Chicken Madras",
                FoodType = "Indian",
                MealDetails = "Mild chicken curry",
                PriceDollars = 4,
                PriceCents = 29
           },
        };

        [HttpGet("[action]")]
        public IEnumerable<MealOffer> RegisterSubscriber()
        {
           return Enumerable.Range(0, offers.Length).Select(index => offers[index]);
        }

        public class MealOffer
        {
            public int ID { get; set; }
            public string DateFormatted { get; set; }
            public string MealSupplier { get; set; }
            public int QtyAvailable { get; set; }
            public string MealName { get; set; }
            public string FoodType { get; set; }
            public string MealDetails { get; set; }
            public int PriceDollars { get; set; }
            public int PriceCents { get; set; }
        }
    }
}
