using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TP_API.Models;
using TP_API.Models.DBModels;
using TP_API.Models.TransectionModels;
using TP_API.Repository;

namespace TP_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TPController : ControllerBase
    {
        private readonly ITP tP;
        private readonly IConfiguration _config;

        public TPController(ITP TP, IConfiguration config)
        {
            this.tP = TP;
            this._config = config;
        }

        [HttpPost]
        public IActionResult SaveTest(TestDetail testData)
        {
            var response = tP.SaveTest(testData);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult ViewTestById(long Id)
        {
            var response = tP.ViewTestById(Id);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllTests()
        {
            var response = tP.ViewAllTests();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult SaveQuesAns(TestQuesData qSaveReq)
        {
            var response = tP.SaveQuesAns(qSaveReq);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult UpdateQuesAns(TestQuesData qSaveReq)
        {
            var response = tP.UpdateQuesAns(qSaveReq);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult GetQuesOptByTestId(int Id)
        {
            var response = tP.GetQuesOptByTestId(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult SaveUser(User user)
        {
            var response = tP.SaveUser(user);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllUsers()

        {
            var response = tP.GetAllUsers();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CheckLogin(LoginDetail uDetail)
        {
            var response = tP.CheckLogin(uDetail);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult SaveSchCandDetail(SchCandData SCData)
        {
            var response = tP.SaveSchCandDetail(SCData);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult UpdateUser(User uDteail)
        {
            var response = tP.UpdateUser(uDteail);
            return Ok(response);
        }
        [HttpGet]
        public IActionResult GetAllSchedules()
        {
            var response = tP.GetAllSchedules();
            return Ok(response);
        }
        [HttpPost]
        public IActionResult CheckCandidateLogin(CandData candData)
        {
            var response = tP.CheckCandidateLogin(candData);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public IActionResult GetCandQOByTestId(int Id)
        {
            var response = tP.GetCandQOByTestId(Id);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult SaveCandTest(CandTestSubmit CandData)
        {
            var response = tP.SaveCandTest(CandData);
            return Ok(response);
        }
        [HttpPost]
        public IActionResult SendMail(Mail mails)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(mails.ToMail);
            mail.From = new MailAddress(_config.GetValue<string>("Mail:From"));
            mail.Subject = mails.Subject;
            mail.Body = mails.Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.Host = _config.GetValue<string>("Mail:Server");
            smtp.Port = _config.GetValue<int>("Mail:Port");
            smtp.Credentials = new NetworkCredential(
                _config.GetValue<string>("Mail:From"),
                _config.GetValue<string>("Mail:Password")
                );
            smtp.EnableSsl = true;
            smtp.Send(mail);
            return Ok(mail);
        }
        [HttpGet]
        public IActionResult GetAllCandResults()
        {
            var response = tP.GetAllCandResults();
            return Ok(response);
        }


    }
}
