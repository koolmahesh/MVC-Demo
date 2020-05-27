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
    public class StudentController : Controller
    {
        StudentBal student = new StudentBal();
        StudentModel stdmodel = new StudentModel();
        // GET: StudentS
        public ActionResult  Index()
        {
        
            if (Session["MailId"] == null)
            {
                return RedirectToAction("Index", "Account");
            }
            else
            {
                stdmodel.FirstName = "Mahesh";
                return View();
            }

        }
        [HttpPost]
        public ActionResult SaveRegistration(StudentModel studentModel)
        {
            int result = student.SaveRegistration(studentModel.FirstName, studentModel.MiddleName, studentModel.LastName, studentModel.Gender, studentModel.DateOfBirth, studentModel.IsActive);
            if (result == 1)
            {
                ViewBag.message = "Record Saved Sucessfully";
            }else
            {
                ViewBag.message = "Something Went Wrong";

            }

            return View("Index");
        }

        public ActionResult GetRecord()
        {
            DataSet ds = new DataSet();
            ds = student.GetRecord();
            List<StudentModel> studentmodel = new List<StudentModel>();
            var epmlist = ds.Tables[0].AsEnumerable().Select(DataRow => new StudentModel
            {
                StudentId = DataRow.Field<int>("ID"),
                FirstName = DataRow.Field<string>("FirstName"),
                MiddleName = DataRow.Field<string>("MiddleName"),
                LastName = DataRow.Field<string>("LastName"),
                Gender = DataRow.Field<string>("Gender"),
                DateOfBirth = DataRow.Field<DateTime>("DateOfBirth"),
                IsActive = DataRow.Field<bool>("IsActive")
            }).ToList();
            studentmodel = epmlist;
            return View(studentmodel);
        }

        public ActionResult EditRecord(int id)
        {
            DataSet ds = new DataSet();
            StudentModel smodel = new StudentModel();
            ds = student.GetStudentByID(id);
            var studentt = ds.Tables[0].AsEnumerable().Select(DataRow => new StudentModel
            {
                StudentId = DataRow.Field<int>("ID"),
                FirstName =DataRow.Field<String>("FirstName"),
                MiddleName = DataRow.Field<string>("MiddleName"),
                LastName = DataRow.Field<string>("LastName"),
                DateOfBirth = DataRow.Field<DateTime>("DateOfBirth"),
                Gender = DataRow.Field<string>("Gender"),
                IsActive = DataRow.Field<bool>("IsActive")
            }).FirstOrDefault();
            smodel = studentt;
            return View(smodel);
        }
        [HttpPost]
        public ActionResult EditRecord(StudentModel studentmodel)
        {
            int result = student.UpdateRegistrationFoam(studentmodel.StudentId,studentmodel.FirstName,studentmodel.MiddleName,studentmodel.LastName,studentmodel.Gender,studentmodel.DateOfBirth,studentmodel.IsActive);
            if(result ==1)
            {
                ViewBag.Message = "Record Sucessfully Updated";
            }
            else
            {
                ViewBag.Message = "Something Wrong Happen";

            }
            return View();
        }

        public ActionResult DeleteRecord(int id)
        {
            int result = student.DeleteStudentRecord(id);
            if (result == 1)
            {
                ViewBag.Message = "Record Sucessfully Deleted";
            }
            else
            {
                ViewBag.Message = "Something Wrong Happen";
            }
            return RedirectToAction("GetRecord");
        }

    }
}