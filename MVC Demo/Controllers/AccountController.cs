using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_Demo.Models;
using MVCCRUDBAL;
using System.Data;

namespace MVC_Demo.Controllers
{
    public class AccountController: Controller
    {
        
        StudentBal student = new StudentBal();
        StudentModel stdmodel = new StudentModel();

        public ActionResult Index()
        {

            stdmodel.FirstName = "Mahesh";
            return View("Login");
        }

        [HttpPost]
        public ActionResult UserLogin(StudentModel studentModel)
        {
            int result = student.LoginInfo(studentModel.Email, studentModel.Password);
            ModelState.Clear();
            if (result == 1)
            {
                
                Session["MailId"] = studentModel.Email.ToString();
                ModelState.Clear();
                return RedirectToAction("Index", "Student");
              
            }
            else
            {
                ViewBag.message = "Invalid User";

                return  View("Index");
            }
            
        }

     
        public ActionResult NewUser()
        {

            return View("index");
        }

        [HttpPost]
        public ActionResult RegisterUser(StudentModel studentModel)
        {

            int result = student.NewREgister(studentModel.FirstName, studentModel.LastName, studentModel.Email, studentModel.Password, studentModel.CPassword);
            if (result == 1)
            {
                ViewBag.message = "Record Saved Sucessfully";
             }
            else
            {
                ViewBag.message = "Something Went Wrong";

            }
            ModelState.Clear();
            return View("NewUser");
        }

        public ActionResult Logout()
        {
            ModelState.Clear();
            Session.Abandon();
            return View("Login");
        }

    }
}