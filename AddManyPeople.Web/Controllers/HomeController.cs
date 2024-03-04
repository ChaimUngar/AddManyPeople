using AddManyPeople.Data;
using AddManyPeople.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AddManyPeople.Web.Controllers
{
    public class HomeController : Controller
    {
        private string _conStr = "Data Source=.\\sqlexpress; Initial Catalog=PeopleAndCars; Integrated Security=true;";

        public IActionResult Index()
        {
            var db = new PeopleDb(_conStr);

            return View(new HomePageViewModel
            {
                People = db.GetPeople()
            });
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(List<Person> ppl)
        {
            var db = new PeopleDb(_conStr);

            ppl = ppl.Where(p => p.FirstName != null && p.LastName != null && p.Age.ToString() != null).ToList();

            db.AddManyPeople(ppl);
            return Redirect("/");
        }
    }
}