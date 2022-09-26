using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGentalPracticeInMVC5.Models;


namespace WebGentalPracticeInMVC5.Controllers
{
    public class HomeController : Controller
    {
        StudentServices stuServ = new StudentServices();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
           
            return View(stuServ.GetDataFromDB());
        }
        public ActionResult Details(int id)
        {
            return View(stuServ.GetStudentByID(id));
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(StudentModel obj)
        {
            stuServ.SetDataInDB(obj);
            return RedirectToAction("List");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            stuServ.DeletDataFromDb(id);
            return RedirectToAction("List");
        }
        public ActionResult Edit(int id)
        {            
            return View(stuServ.GetStudentByID(id));
        }
        [HttpPost]
        public ActionResult Edit(int id,StudentModel obj)
        {

            stuServ.EditDataInDB (id,obj);
            return RedirectToAction("List");
        }
        private List<StudentModel> SetStudent()
        {
            var studentlist = new List<StudentModel>();

            StudentModel obj = new StudentModel()
            {
                Sid = 1,
                Sname = "kamran",
                Sage = 25
            };
            StudentModel obj1 = new StudentModel()
            {
                Sid = 2,
                Sname = "Adul Rehman",
                Sage = 25
            };
            StudentModel obj2 = new StudentModel()
            {
                Sid = 3,
                Sname = "Asad Ali",
                Sage = 25
            };
            studentlist.Add(obj);
            studentlist.Add(obj1);
            studentlist.Add(obj2);
            

            return studentlist;
        }


        
        
        
    }
}