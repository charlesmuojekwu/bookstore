using Microsoft.AspNetCore.Mvc;

namespace bookstoreproject.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }

        public ViewResult Index()
        {
            Title = "Home";
            
            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "About Us";

            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contact Us";

            return View();
        }
    }
}
