using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MoneyVeo.Web.Extensions;
using MoneyVeo.Web.Models;
using MoneyVeo.Web.Services.Imp;
using MoneyVeo.Web.Services.Mdl;
using MoneyVeo.Web.Services.Services.Int;

namespace MoneyVeo.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMatrixService _matrixService;

        public HomeController(IHostingEnvironment environment, IMatrixService matrixService)
        {
            _hostingEnvironment = environment;
            _matrixService = matrixService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("GetRandomMatrix")]
        public IActionResult GetRandomMatrix(int length = 10)
        {
            var srvResponce = _matrixService.GetRandomMatrix(length);
            return Json(srvResponce);
        }

        [HttpPost]
        [Route("GetCsvMatrix")]
        public IActionResult GetCsvMatrix([FromForm]string matrix)
        {
            var stream = matrix.ToStream();
            return File(stream, "application/octet-stream");
        }

        [HttpPost]
        [Route("RotateMatrix")]
        public IActionResult RotateMatrix([FromBody]MatrixModel matrix)
        {
            return Json(_matrixService.Degree90Matrix(matrix.Matrix));
        }

        [HttpPost]
        [Route("UploadMatrix")]
        public async Task<IActionResult> UploadMatrix(IFormFile file)
        {
            if (file == null)
            {
                return RedirectToAction("Index");
            }
            else
            {   //strange
                var csv = "<div class=\"matrix-row\">" + (await file.ToStringAsync())
                    .Replace("\n\r", "</div><div class=\"matrix-row\">") + "</div>";
                TempData.Add("csv", csv);
                return RedirectToAction("Index");
            }
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
