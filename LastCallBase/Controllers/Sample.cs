using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using LastCallBase.LastCallDatabase;
using Microsoft.EntityFrameworkCore;

namespace LastCallBase.Controllers
{
    [Route("api/[controller]")]
    public class SampleController : Controller
    {
        public class BaseData
        {
            public int ID { get; set; }
            public string Name { get; set; }
        }

        private static BaseData[] data =
        {
            new BaseData {
                ID = 1,
                Name = "Item 1"

           },
            new BaseData {
                ID = 2,
                Name = "Item 2"
           },
            new BaseData {
                ID = 3,
                Name = "Item 3"
           }
        };

        [HttpGet("[action]")]
        public IEnumerable<BaseData> BaseService()
        {
            return Enumerable.Range(0, data.Length).Select(index => data[index]);
        }

        public class Preference
        {
            public int Id { get; set; }
            public int Preftype { get; set; }
            public string Prefname { get; set; }
        }

        // A subscriber and their food preferences
        public class SubscriberAndPrefs: Subscribers
        {
            public SubscriberAndPrefs(Subscribers person)
            {
                Id = person.Id;
                Email = person.Email;
                Phone = person.Phone;
                Friendlyname = person.Friendlyname;
                Onmailinglist = person.Onmailinglist;
                Textoffers = person.Textoffers;
                Emailoffers = person.Emailoffers;
                Deliveryaddress = person.Deliveryaddress;
            }
            public Preference [] Preferences { get; set; }
        }

        [HttpGet("[action]")]
        public SubscriberAndPrefs FetchSubscriberAndPreferences()
        {
            lastcallContext c = new LastCallDatabase.lastcallContext();

            Subscribers person = c.Subscribers.Where(x => x.Id == 1).FirstOrDefault();
            if (person == null)
                return null;

            Foodpreferences[] prefs = (from x in c.Foodpreferences where x.Subscriberid == person.Id select x).Include(x => x.Preference).ToArray();

            SubscriberAndPrefs result = new SubscriberAndPrefs(person);
            result.Preferences = new Preference[prefs.Length];

            for (int i = 0; i < prefs.Length; i++)
                result.Preferences[i] = new Preference() { Id = prefs[i].Id, Preftype = prefs[i].Preferenceid, Prefname = prefs[i].Preference.Foodtype };

            return result;
        }

        [HttpPost("[action]")]
        public ServerError PostService()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];

            DBCheck();

            if (CheckUserRegistered(username))
                return new ServerError { ErrorCode = 1, ErrorMessage = "Email address is already in use", ErrorDescription = "", StatusMessage = "" };

            (bool result, string msg) = CreateNewSubscriber(username, password);
            if (!result)
                return new ServerError { ErrorCode = 2, ErrorMessage = "Failed to add subscriber", ErrorDescription = "Exception in CreateNewSuscriber" + msg, StatusMessage = "" };

            return new ServerError { ErrorCode = 0, ErrorMessage = "OK", ErrorDescription = msg, StatusMessage = "" };
        }

        // https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core-scaffold-example.html
        private bool CheckUserRegistered(string email)
        {
            lastcallContext c = new LastCallDatabase.lastcallContext();
            Subscribers subscriber = c.Subscribers.Where((x) => x.Email == email).FirstOrDefault();

            return (subscriber != null);
        }

        private (bool, string) CreateNewSubscriber(string email, string password)
        {
            try
            {
                lastcallContext c = new LastCallDatabase.lastcallContext();
                Subscribers subscriber = new Subscribers() { Email = email };
                c.Add(subscriber);
                c.SaveChanges();

                return (true, "Success");
            }
            catch (Exception X)
            {
                return (false, X.Message);
            }
        }

        // https://docs.microsoft.com/en-us/ef/ef6/fundamentals/relationships
        // https://docs.microsoft.com/en-us/ef/ef6/querying/related-data
        // http://foreverframe.net/when-use-include-with-entity-framework/
        private void DBCheck()
        {
            lastcallContext c = new LastCallDatabase.lastcallContext();

            // Explicit loading
            //Foodpreferences[] prefs = (from x in c.Foodpreferences where x.Subscriberid == 1 select x).ToArray<Foodpreferences>();
            //c.Entry(prefs[0]).Reference(x => x.Preference).Load();

            // Eager loading
            // Requires "using Microsoft.EntityFrameworkCore;"
            // See also .ThenInclude()
            Foodpreferences[] prefs = c.Foodpreferences.Where(x => x.Subscriberid == 1).Include(x => x.Preference).ToArray<Foodpreferences>();

            string s = prefs[0].Preference.Foodtype;
            s = s.ToUpper();

        }
    }
}
