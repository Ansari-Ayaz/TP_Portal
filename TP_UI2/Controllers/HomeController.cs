using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TP_UI2.Models;

namespace TP_UI2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration config;

        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Tests()
        {
            return View();
        }
        public IActionResult Questions()
        {
            return View();
        }
        public IActionResult ManageUsers()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Riz()
        {
            int azaza=0;
            int gfgfg=0;
            string on;
            string off;
            return View();
        }
        public IActionResult CandidateLogin
            ()
        {
            return View();
        }
        public IActionResult CandidateHome()
        {
            return View();
        }
        public IActionResult CandidateTest()
        {
            return View();
        }
        public IActionResult Results()
        {
            return View();
        }

        public IActionResult Results1()
        {
            return View();
        }
        public IActionResult LoginPost(string email, string password)
        {

            LoginDetail uDetail = new LoginDetail()
            {
                Email = email,
                Password = password
            };
            var client = new RestClient(config["config:Api"]);
            var request = new RestRequest("TP/CheckLogin/", Method.Post);
            request.AddJsonBody(uDetail);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<Response>(request).Data;

            if (response.Resp)
            {
                User u = JsonConvert.DeserializeObject<User>(response.RespObj.ToString());
                HttpContext.Session.SetObjectAsJson("user", u);
                return View("Index");
            }
            else
            {
                ViewData["Error"] = response.RespMsg;
                return View("Login");
            }

        }
        public IActionResult CandLoginPost(string email, string password)
        {

            LoginDetail uDetail = new LoginDetail()
            {
                Email = email,
                Password = password
            };
            var client = new RestClient(config["Config:Api"]);
            var request = new RestRequest("TP/CheckCandidateLogin/", Method.Post);
            request.AddJsonBody(uDetail);
            request.RequestFormat = DataFormat.Json;
            var response = client.Execute<Response>(request).Data;

            if (response.Resp)
            {
                CandData u = JsonConvert.DeserializeObject<CandData>(response.RespObj.ToString());
                HttpContext.Session.SetObjectAsJson("Canduser", u);
                return RedirectToAction("CandidateHome");
            }
            else
            {
                //ViewData["Error"] = response.RespMsg;
                ViewData["Success"] = response.RespMsg;
                return View("CandidateLogin");
            }

        }

        
        public IActionResult ViewSchedules()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult CreateSchedule()
        {
            return View();
        }
    }
    public class LoginDetail
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class Response
    {
        public bool Resp { get; set; }
        public string RespMsg { get; set; }
        public object RespObj { get; set; }
    }
}
