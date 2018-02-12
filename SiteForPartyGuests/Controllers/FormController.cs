using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using SiteForPartyGuests.BusinessLogic;
using SiteForPartyGuests.Models;
using SiteForPartyGuests.Service;

namespace SiteForPartyGuests.Controllers
{
    public class FormController : Controller
    {
        private readonly EmailService _emailService;

        public FormController()
        {
            _emailService = new EmailService();
        }
        // GET: Form
        public ActionResult Index()
        {
            return View();
        }

        // GET: Form/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Form/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Form/Create
        [HttpPost]
        public ActionResult Create(Form model)
        {
            var validator = new FormValidator();
            var result = validator.Validate(model);

            if (result.IsValid)
            {
                var message = _emailService.CreateMailMessage(model);
                _emailService.SendEmail(message);
                message = _emailService.CreateMailMessage(model, true);
                // sendEmail(model);
                return View("~/Views/Form/Thanks.cshtml", model);
            }
            ModelState.Clear();
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.ErrorMessage);
            }
            return View(model);
        }

        

        // GET: Form/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Form/Edit/5
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

        // GET: Form/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Form/Delete/5
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
