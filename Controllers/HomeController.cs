using k181297_k180326.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace k181297_k180326.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            string message = DatabaseManager.Connect();
            ViewBag.msg = message;
            ViewBag.alertVisible = "hidden";
            ViewBag.Visible = "visble";
            ViewBag.GreetingVisible = "hidden";
            ViewBag.Greetings = "None";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application's features description page.";
            ViewBag.alertVisible = "hidden";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.alertVisible = "hidden";
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //[ActionName("Contact")]
        [HttpPost]
        public ActionResult Contact(string email, string password, string message)
        {
            string complaint_id = "CID03";
            string user_id = "UID02";
            string date_str = DateTime.Now.ToString();

            ViewBag.Message = DatabaseManager.AddComplaint(complaint_id, user_id, message, date_str);
            
            if(ViewBag.Message == "Success!")
            {
                ViewBag.alertVisible = "visible";
            }

            return View("Contact");
        }

        public ActionResult Signup()
        {
            ViewBag.alertVisible = "hidden";
            ViewBag.Message = "Your signup page.";

            return View();
        }
        [HttpPost]
        public ActionResult Signup(string cnic, string name, string email, string password, string acoountNo)
        {
            ViewBag.alertVisible = "hidden";

            ViewBag.Message = DatabaseManager.AddUser(cnic, name, email, password, acoountNo);

            return View();
        }

        public ActionResult Login()
        {
            ViewBag.alertVisible = "hidden";
            ViewBag.Message = "Your Login page.";

            return View();
        }
        [HttpPost]
        public ActionResult Login(string cnic, string password)
        {
            ViewBag.alertVisible = "hidden";
            ViewBag.Message = "Your Login page.";

            Users user = DatabaseManager.LoginUser(cnic, password);
            ViewBag.Name = user.full_name;
            return View();
        }
        public ActionResult ExpenseTracking()
        {
            IDictionary<string, float> expenses = new Dictionary<string, float>();
            ViewBag.Expenses = expenses;
            return View();
        }
        [HttpPost]
        public ActionResult ExpenseTracking(string expenseName, float expenseAmount)
        {
            IDictionary<string, float> expenses = new Dictionary<string, float>();
            expenses.Add(expenseName, expenseAmount);
            ViewBag.Expenses = expenses;
            return View();
        }
    }
}