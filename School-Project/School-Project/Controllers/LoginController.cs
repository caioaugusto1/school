﻿using School_Project.BLL;
using School_Project.Entities;
using School_Project.Models.Login;
using System;
using System.Web.Mvc;

namespace School_Project.Controllers
{
    public class LoginController : Controller
    {
        private readonly LoginBLL _loginBLL;

        public LoginController(LoginBLL loginBLL)
        {
            _loginBLL = loginBLL;
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SingIn(string username, string password)
        {
            ViewBag.Error = false;

            Login login = _loginBLL.SingIn(username, password);

            if (login == null)
            {
                ViewBag.Error = true;
                return View("Index");
            }

            return RedirectToAction("Index", "Home");
        }


        public ActionResult Logout()
        {
            Session.Abandon();
            Session.RemoveAll();
            return RedirectToAction("Index", "Home");
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Create(CreateLoginVM newLogin)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _loginBLL.CreateLogin(newLogin);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
