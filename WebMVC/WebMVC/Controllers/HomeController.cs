using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebMVC.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace WebMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult BeginFormsExample(BeginFormsExampleModel? model = null)
        {
            if (model?.Name == null)
            {
                model = new BeginFormsExampleModel();
                model.Name = System.DateTime.Now.ToString();
                model.CheckBox_number_1 = false;
                model.CheckBox_number_2 = false;
            }   

            return View("BeginFormsExample",model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost]
        public async Task<ActionResult>ButtonPush(BeginFormsExampleModel model)
        {
            try
            {
                model.CheckBox_number_1 = true;
                model.CheckBox_number_2 = true;
                model.Name = "ButtonPush";

                return (ActionResult) BeginFormsExample(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        [HttpPost]
        public async Task<ActionResult> CheckBox1Push(BeginFormsExampleModel model)
        {
            try
            {
                model.CheckBox_number_1 = true;
                model.CheckBox_number_2 = false;
                model.Name = "CheckBox1Push";

                return (ActionResult)BeginFormsExample(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> CheckBox2Push(BeginFormsExampleModel model)
        {
            try
            {
                model.CheckBox_number_1 = false;
                model.CheckBox_number_2 = true;
                model.Name = "CheckBox2Push";

                return (ActionResult)BeginFormsExample(model);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
