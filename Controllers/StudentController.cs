using StudentProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentProject.Controllers
{
    public class StudentController : Controller
    {

        public ActionResult GetstudentDetails()
        {
            StudentModelManager studentModelManager = new StudentModelManager();
            List<StudentModel> studentModels = studentModelManager.GetstudentInfo();
            return View(studentModels);
        }
        [HttpGet]

        public ActionResult Ins_Update_Delete_search()
        {
            StudentModel studentModel = new StudentModel();
            ViewResult vr = View("InsStudentDetails", studentModel);
            ActionResult ar = vr;
            return ar;
        }
        [HttpPost]

        public ActionResult Ins_Update_Delete_search(StudentModel studentModel, string x)
        {
            return null;


        }
    } 
}