using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AQR.BusinessLayer;
using AQR.UserManagement.Models;
using AQR.DomainModels;

namespace AQR.UserManagement.Controllers
{
    public class UserController : Controller
    {
        private IUserService userService { get; set; }
        private IDepartmentService  departmentService { get; set; }


        public UserController(IUserService _userService, IDepartmentService _departmentService)
        {
            this.userService = _userService;
            this.departmentService = _departmentService;
        } 


        public ActionResult Index()
        {
            if (Session[Constants.UserId] == null) return RedirectToAction("Login");

            var users = userService.GetAllUsers();
            return View(users);
        }

        public ActionResult Details(int id = 0)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), Constants.Departmentid, Constants.DepartmentName);
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            ValidateInputs(user);

            if (ModelState.IsValid)
            {
                userService.Add(user);
                return RedirectToAction("Index");
            }
           ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), Constants.Departmentid, Constants.DepartmentName, user.Department.DepartmentId);
            return View(user);
        }

        public ActionResult Edit(int id = 0)
        {
            var user = userService.GetUser(id);

            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), Constants.Departmentid, Constants.DepartmentName, user.Department.DepartmentId);
            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            ValidateInputs(user);

            if (ModelState.IsValid)
            {
                userService.Edit(user);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAllDepartments(), Constants.Departmentid, Constants.DepartmentName, user.Department.DepartmentId);
            return View(user);
        }

        public ActionResult Delete(int id = 0)
        {
            var user = userService.GetUser(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var user = userService.GetUser(id);
            if (user == null) return RedirectToAction("Index");

            userService.Delete(user);

            return RedirectToAction("Index");
        }


        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {

            if (string.IsNullOrEmpty(user.FirstName))
            {
                ModelState.AddModelError("FirstName", string.Format(Constants.RequiredFieldMessage, "First Name"));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", string.Format(Constants.RequiredFieldMessage, "Password"));
            }

            var validUser = userService.ValidateCredentials(user.FirstName, user.Password);

            if (validUser == null) return View(user);

            Session[Constants.UserId] = validUser.UserId.ToString();
            Session[Constants.FirstName] = validUser.FirstName;
            Session[Constants.LastName] = validUser.LastName;
            return RedirectToAction("Index");
        }

        public ActionResult Exception()
        {
            throw new Exception(Constants.ErrorMessage);
        }

        public ActionResult PageNotFound()
        {
            return View();
        }
        private void ValidateInputs(User user)
        {
            if (string.IsNullOrEmpty(user.FirstName))
            {
                ModelState.AddModelError("FirstName", string.Format(Constants.RequiredFieldMessage, "First Name"));
            }

            if (string.IsNullOrEmpty(user.LastName))
            {
                ModelState.AddModelError("LastName", string.Format(Constants.RequiredFieldMessage, "Last Name"));
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", string.Format(Constants.RequiredFieldMessage, "Password"));
            }

            if (string.IsNullOrEmpty(user.City))
            {
                ModelState.AddModelError("City", string.Format(Constants.RequiredFieldMessage, "City"));
            }

            if (string.IsNullOrEmpty(user.Gender))
            {
                ModelState.AddModelError("Gender", string.Format(Constants.RequiredFieldMessage, "Gender"));
            }
        }
    }
}