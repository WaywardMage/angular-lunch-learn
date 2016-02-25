using MvcAngular.Models;
using Newtonsoft.Json;
using System.Web.Mvc;

namespace MvcAngular.Controllers
{
    public class PersonController : Controller
    {
        public bool useAngular {
            get
            {
                var useAngular = HttpContext.Request.QueryString["useAngular"];
                return useAngular == "true";
            }
        }

        public ActionResult Index()
        {
            if (useAngular)
            {
                return View("ngIndex", PersonModel.GetPersons());
            }
            else
            {
                return View("Index", PersonModel.GetPersons());
            }
        }

        public ActionResult Details(int id)
        {
            if (useAngular)
            {
                return View("ngDetails", PersonModel.GetPerson(id));
            }
            else
            {
                return View("Details", PersonModel.GetPerson(id));
            }
        }

        public ActionResult Create()
        {
            return View("Create", new PersonModel());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            if (useAngular)
            {
                return View("ngEdit", PersonModel.GetPerson(id));
            }
            else
            {
                return View("Edit", PersonModel.GetPerson(id));
            }
        }

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

        /////////// Angular Methods /////////////////////////////////////
        [HttpPost]
        public string GetPersons()
        {
            return JsonConvert.SerializeObject(PersonModel.GetPersons());
        }

        [HttpPost]
        public string GetPerson(int id)
        {
            return JsonConvert.SerializeObject(PersonModel.GetPerson(id));
        }

        [HttpPost]
        public JsonResult SavePerson(PersonModel person)
        {
            //nothing to do since we're using fake data, but check the data in the debugger.
            return Json(new { success = true, errorMessage = "" });
        }
    }
}
