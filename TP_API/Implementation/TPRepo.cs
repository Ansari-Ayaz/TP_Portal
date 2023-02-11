using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using TP_API.Controllers;
using TP_API.Models;
using TP_API.Models.DBModels;
using TP_API.Models.TransectionModels;
using TP_API.Repository;

namespace TP_API.Implementation
{
    public class TPRepo : ITP
    {
        private readonly DBContext db;
        private readonly IConfiguration _config;

        public TPRepo(DBContext db, IConfiguration config)
        {
            this.db = db;
            this._config = config;
        }

        public Response SaveTest(TestDetail testData)
        {

            Response resp = new Response();
            try
            {
                if (testData != null)
                {
                    TestDetail tData = new TestDetail();
                    tData.TestName = testData.TestName;
                    tData.No_Of_Q = testData.No_Of_Q;
                    tData.PerQ_Point = testData.PerQ_Point;
                    tData.PerQ_Time_Min = testData.PerQ_Time_Min;
                    //tData.OwnerId = testData.OwnerId;
                    //tData.CreatedBy = testData.OwnerId;
                    tData.CreatedOn = DateTime.Now;
                    //tData.UpdatedBy = testData.OwnerId;
                    //tData.UpdatedOn = DateTime.Now;
                    tData.IsActive = true;
                    db.TP_TestDetail.Add(tData);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        resp.Resp = true;
                        resp.RespMsg = "Test Saved Successfully";
                        resp.RespObj = tData.TestId;
                        return resp;
                    }
                    else
                    {
                        resp.Resp = false;
                        resp.RespMsg = "Failed to Save Test";
                        return resp;
                    }
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "Please fill All Fields";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public Response UpdateTest(TestDetail testData)
        {
            Response resp = new Response();
            try
            {
                if (testData == null)
                {
                    resp.Resp = false;
                    resp.RespMsg = "Please Fill All Data";
                    return resp;
                }
                var data = db.TP_TestDetail.FirstOrDefault(a => a.TestId == testData.TestId);
                if (data == null)
                {
                    resp.Resp = false;
                    resp.RespMsg = "Id Not Valid";
                    return resp;
                }
                data.No_Of_Q = testData.No_Of_Q;
                data.PerQ_Point = testData.PerQ_Point;
                data.PerQ_Time_Min = testData.PerQ_Time_Min;
                data.OwnerId = testData.OwnerId;
                data.UpdatedBy = Convert.ToInt32(testData.OwnerId);
                data.UpdatedOn = DateTime.Now;
                data.IsActive = testData.IsActive;
                var data1 = db.TP_TestDetail.Attach(data);
                data1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                int i = db.SaveChanges();
                if (i > 0)
                {
                    resp.Resp = true;
                    resp.RespMsg = "Test Updated Successfully";
                }
                return resp;
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }

        public List<TestDetail> ViewAllTests()
        {
            try
            {
                var getTestData = db.TP_TestDetail.ToList();
                if (getTestData != null)
                {
                    return getTestData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Response ViewTestById(long Id)
        {
            Response resp = new Response();
            try
            {
                TestDetail tData = new TestDetail();
                tData = db.TP_TestDetail.FirstOrDefault(z => z.TestId == Id);
                if (tData != null)
                {
                    var testData = db.TP_TestDetail.FirstOrDefault(z => z.TestId == Id);
                    resp.Resp = true;
                    resp.RespMsg = "Test Data Found Successfully";
                    resp.RespObj = testData;
                    return resp;
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "Test Data Not Found";
                    resp.RespObj = null;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public Response DeleteTest(int Id)
        {
            Response resp = new Response();
            if (Id == 0)
            {
                resp.Resp = false;
                resp.RespMsg = "Please Fill Id Field";
                return resp;
            }
            try
            {

                var data = db.TP_TestDetail.FirstOrDefault(z => z.TestId == Id);
                if (data != null)
                {
                    db.TP_TestDetail.Remove(data);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        resp.Resp = true;
                        resp.RespMsg = "Deleted Successfully";
                        return resp;
                    }
                    else
                    {
                        resp.Resp = false;
                        resp.RespMsg = "Something Went Wrong";
                        resp.RespObj = Id;
                        return resp;
                    }
                }
                resp.Resp = false;
                resp.RespMsg = "Id Does Not Exist";
                resp.RespObj = Id;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }

        public Response SaveQuesAns(TestQuesData qoData)
        {
            Response resp = new Response();
            if (qoData == null)
            {
                resp.Resp = false;
                resp.RespMsg = "Please Fill All Field!!";
                resp.RespObj = qoData;
                return resp;
            }
            try
            {
                if (qoData != null)
                {
                    foreach (var quesData in qoData.Questions)
                    {
                        Question ques = new Question();
                        ques.QuestionText = quesData.QuestionText;
                        ques.TestId = qoData.TestId;
                        ques.CreatedBy = qoData.LoggedInUser;
                        ques.CreatedOn = DateTime.Now;
                        ques.UpdatedBy = qoData.LoggedInUser;
                        ques.UpdatedOn = DateTime.Now;
                        ques.IsActive = true;
                        db.TP_Question.Add(ques);
                        db.SaveChanges();
                        foreach (var optData in quesData.Options)
                        {
                            Option opt = new Option();
                            opt.QId = ques.QId;
                            opt.IsCorrect = optData.IsCorrect;
                            opt.OptionText = optData.OptionText;
                            opt.CreatedBy = qoData.LoggedInUser;
                            opt.CreatedOn = DateTime.Now;
                            opt.UpdatedBy = qoData.LoggedInUser;
                            opt.UpdatedOn = DateTime.Now;
                            db.TP_Options.Add(opt);
                            db.SaveChanges();
                        }
                    }
                }
                resp.Resp = true;
                resp.RespMsg = "Questions And Options Save Successfully";
                //resp.RespObj = resp;
                return resp;
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public Response UpdateQuesAns(TestQuesData qoData)
        {
            Response resp = new Response();
            if (qoData == null)
            {
                resp.Resp = false;
                resp.RespMsg = "Id is Not Valid";
                resp.RespObj = null;
                return resp;
            }
            try
            {
                var qoDataFound = db.TP_TestDetail.FirstOrDefault(z => z.TestId == qoData.TestId);
                if (qoDataFound == null)
                {
                    resp.Resp = false;
                    resp.RespMsg = "Test Id is Not Exist";
                    resp.RespObj = null;
                    return resp;
                }
                if (qoDataFound != null)
                {
                    foreach (var question in qoData.Questions)
                    {
                        Question ques = new Question();
                        ques.TestId = qoData.TestId;
                        ques.QId = question.QId;
                        ques.QuestionText = question.QuestionText;
                        ques.UpdatedOn = DateTime.Now;
                        ques.UpdatedBy = qoData.LoggedInUser;
                        ques.IsActive = true;
                        var data = db.TP_Question.Attach(ques);
                        data.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        db.SaveChanges();
                        foreach (var option in question.Options)
                        {
                            Option opt = new Option();
                            opt.OptionText = option.OptionText;
                            opt.OptId = option.OptId;
                            opt.IsCorrect = option.IsCorrect;
                            opt.UpdatedBy = qoData.LoggedInUser;
                            opt.UpdatedOn = DateTime.Now;
                            var data1 = db.TP_Options.Attach(opt);
                            data1.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                            db.SaveChanges();
                        }
                    }
                }
                resp.Resp = true;
                resp.RespMsg = "Updated Successfully";
                return resp;
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }

        }
        public Response GetQuesOptByTestId(int Id)
        {
            Response resp = new Response();
            TestQuesData quesOptData = new TestQuesData();
            try
            {
                var tData = db.TP_TestDetail.FirstOrDefault(z => z.TestId == Id);
                quesOptData.TDetail = tData;
                quesOptData.TestId = tData.TestId;
                quesOptData.LoggedInUser = tData.OwnerId;
                var data = db.TP_Question.FirstOrDefault(z => z.TestId == Id);
                if (data != null)
                {
                    var qList = db.TP_Question.Where(z => z.TestId == Id).ToList();
                    quesOptData.Questions = new List<QuesData>();
                    foreach (var ques in qList)
                    {
                        QuesData quesData = new QuesData();
                        quesData.QId = ques.QId;
                        quesData.QuestionText = ques.QuestionText;
                        quesData.Options = new List<OptData>();
                        var optList = db.TP_Options.Where(z => z.QId == ques.QId).ToList();
                        foreach (var optObj in optList)
                        {
                            OptData optData = new OptData();
                            optData.OptId = optObj.OptId;
                            optData.OptionText = optObj.OptionText;
                            optData.IsCorrect = optObj.IsCorrect;
                            quesData.Options.Add(optData);
                        }
                        quesOptData.Questions.Add(quesData);
                    }
                    resp.Resp = false;
                    resp.RespMsg = "Test Data Found Successfully";
                    resp.RespObj = quesOptData;
                    return resp;
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "Test Data Found Successfully";
                    resp.RespObj = quesOptData;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = "Something Went Wrong";
                resp.RespObj = ex.StackTrace;
                return null;
            }
        }
        public Response SaveUser(User user)
        {
            Response resp = new Response();

            try
            {
                if (user != null)
                {
                    User userObj = new User();
                    userObj.Name = user.Name;
                    userObj.Email = user.Email;
                    userObj.Password = user.Password;
                    userObj.Role = 2;
                    userObj.IsActive = true;
                    userObj.CreatedBy = user.CreatedBy;
                    userObj.CreatedOn = DateTime.Now;
                    userObj.UpdatedBy = user.UpdatedBy;
                    userObj.UpdatedOn = DateTime.Now;
                    db.TP_User.Add(userObj);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        resp.Resp = true;
                        resp.RespMsg = "User Saved Successfully";
                        return resp;
                    }
                    else
                    {
                        resp.RespMsg = "Failed TO Saved";
                        return resp;
                    }
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "User Data Not Received";
                    return resp;
                }

            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public List<User> GetAllUsers()
        {
            try
            {
                var getUsers = db.TP_User.ToList();
                if (getUsers != null)
                {
                    return getUsers;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
        public Response UpdateUser(User uDteail)
        {
            Response resp = new Response();
            try
            {
                if (uDteail != null)
                {
                    User user = db.TP_User.FirstOrDefault(z => z.UserId == uDteail.UserId);
                    if (user == null)
                    {
                        resp.Resp = false;
                        resp.RespMsg = "User not found";
                        return resp;
                    }
                    else
                    {
                        user.Name = uDteail.Name;
                        user.Password = uDteail.Password;
                        user.UpdatedBy = uDteail.UpdatedBy;
                        user.UpdatedOn = DateTime.Now;
                        var data = db.TP_User.Attach(user);
                        data.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        int i = db.SaveChanges();
                        if (i > 0)
                        {
                            resp.Resp = true;
                            resp.RespMsg = "Profile Updated Successfully";
                            return resp;
                        }
                        else
                        {
                            resp.Resp = false;
                            resp.RespMsg = "Failed to update user.";
                            return resp;
                        }
                    }

                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "User data not received";
                    return resp;
                }

            }
            catch (Exception ex)
            {
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public Response CheckLogin(LoginDetail uDetail)
        {
            Response resp = new Response();
            try
            {
                if (uDetail == null)
                {
                    resp.RespMsg = "Please Fill All The Field";
                    resp.RespObj = uDetail;
                    return resp;
                }
                if (string.IsNullOrEmpty(uDetail.Email))
                {
                    resp.RespMsg = "Please fill Email Field";
                    return resp;
                }
                if (string.IsNullOrEmpty(uDetail.Password))
                {
                    resp.RespMsg = "Please fill Password Field";
                    return resp;
                }
                var userData = db.TP_User.Where(z => z.Email == uDetail.Email).FirstOrDefault();
                if (userData != null)
                {
                    if (userData.Password == uDetail.Password)
                    {
                        userData.Password = null;
                        resp.Resp = true;
                        resp.RespMsg = "User Information Found Successfully";
                        resp.RespObj = userData;
                        return resp;
                    }
                    else
                    {
                        resp.RespMsg = "Invalid Cridential";
                        resp.RespObj = uDetail;
                        return resp;
                    }
                }
                else
                {
                    resp.RespMsg = "Email Id is Not Correct";
                    resp.RespObj = uDetail;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }

        public static string GetRandomPassword(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, length).Select(z => z[random.Next(z.Length)]).ToArray());
        }
        public Response SaveSchCandDetail(SchCandData SCData)
        {
            Response resp = new Response();
            try
            {
                if (SCData != null)
                {
                    Schedule schedule = new Schedule();
                    schedule.TestId = SCData.TestId;
                    schedule.TestName = SCData.TestName;
                    schedule.StartTime = SCData.StartTime;
                    schedule.EndTime = SCData.EndTime;
                    schedule.CreatedBy = SCData.UserId;
                    schedule.CreatedOn = DateTime.Now;
                    schedule.UpdatedBy = SCData.UserId;
                    schedule.UpdatedOn = DateTime.Now;
                    schedule.IsActive = true;
                    db.TP_Schedule.Add(schedule);
                    db.SaveChanges();
                    int savedCandidates = 0;
                    foreach (var candidate in SCData.Candidates)
                    {
                        CandidateDetail cand = new CandidateDetail();
                        cand.ScheduleId = schedule.ScheduleId;
                        cand.Email = candidate.Email;
                        cand.Password = GetRandomPassword(8);
                        cand.Name = candidate.Name;
                        cand.CreatedBy = SCData.UserId;
                        cand.CreatedOn = DateTime.Now;
                        cand.UpdatedBy = SCData.UserId;
                        cand.UpdatedON = DateTime.Now;
                        cand.IsActive = true;
                        db.TP_CandidateDetail.Add(cand);
                        int i = db.SaveChanges();
                        this.SendEmail(SCData, cand);
                        if (i > 0) savedCandidates++;
                    }
                    if (SCData.Candidates.Count == savedCandidates)
                    {
                        resp.Resp = true;
                        resp.RespMsg = "All Candidates Saved Successfully";
                        return resp;
                    }
                    else
                    {
                        resp.Resp = true;
                        resp.RespMsg = "Saved Candidates Successfully";
                        return resp;
                    }
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "User Data Not Received";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }


        }
        public Response SendEmail(SchCandData schCandData, CandidateDetail candData)
        {
            Response resp = new Response();
            MailMessage mail = new MailMessage();
            mail.To.Add(candData.Email);
            mail.From = new MailAddress(_config.GetValue<string>("Mail:From"));
            mail.Subject = "Test Scheduled";
            mail.Body = @"Dear " + candData.Name + "<br>Your " + schCandData.TestName + " Test Has Been Scheduled.Test Start From " + schCandData.StartTime + " To " + schCandData.EndTime + " And Your Password :" + candData.Password +
                " <br>Please Click On Below Link For Start Your Test<br>" + "https://localhost:44334/Home/CandidateLogin";
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
            resp.Resp = true;
            resp.RespMsg = "Mail Sent Successfully";
            return resp;
        }
        public List<Schedule> GetAllSchedules()
        {

            try
            {
                var scData = db.TP_Schedule.ToList();
                if (scData != null)
                {

                    return scData;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }
        }
        public Response CheckCandidateLogin(CandData candData)
        {
            Response resp = new Response();
            try
            {
                CandidateDetail cand = db.TP_CandidateDetail.FirstOrDefault(z => z.Email == candData.Email && z.Password == candData.Password);
                if (cand != null)
                {
                    Schedule schedule = db.TP_Schedule.FirstOrDefault(z => z.ScheduleId == cand.ScheduleId);
                    var candTestGiven = db.TP_FResults.FirstOrDefault(z => z.CId == cand.CId && z.ScheduleId == cand.ScheduleId && z.TestId == schedule.TestId);
                    if (candTestGiven == null)
                    {
                        if (schedule != null)
                        {
                            if (schedule.StartTime < DateTime.Now)
                            {
                                if (schedule.EndTime > DateTime.Now)
                                {
                                    CandData cData = new CandData();
                                    var testDetail = db.TP_TestDetail.FirstOrDefault(z => z.TestId == schedule.TestId);
                                    cData.Email = cand.Email;
                                    cData.Name = cand.Name;
                                    cData.TestId = testDetail.TestId;
                                    cData.TestName = testDetail.TestName;
                                    cData.ScheduleId = schedule.ScheduleId;
                                    cData.CId = cand.CId;

                                    resp.Resp = true;
                                    resp.RespMsg = "Login Successfull";
                                    resp.RespObj = cData;
                                    return resp;
                                }
                                else
                                {
                                    resp.RespMsg = "Test is Expired";
                                    return resp;
                                }

                            }
                            else
                            {
                                resp.RespMsg = "Test is Not Start Yet";
                                return resp;
                            }
                        }
                        else
                        {
                            resp.RespMsg = "Schedule is not Create";
                            return resp;
                        }
                    }
                    else
                    {
                        resp.RespMsg = "You Are Already Given Test";
                        return resp;
                    }

                }
                else
                {
                    resp.RespMsg = "Invalid Credential";
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public Response GetCandQOByTestId(int Id)
        {
            Response resp = new Response();
            CandTQO quesOptData = new CandTQO();
            try
            {
                var tData = db.TP_TestDetail.FirstOrDefault(z => z.TestId == Id);
                quesOptData.TDetail = tData;
                quesOptData.TestId = tData.TestId;
                quesOptData.LoggedInUser = tData.OwnerId;
                var data = db.TP_Question.FirstOrDefault(z => z.TestId == Id);
                if (data != null)
                {
                    var qList = db.TP_Question.Where(z => z.TestId == Id).ToList();
                    quesOptData.Questions = new List<CandQO>();
                    foreach (var ques in qList)
                    {
                        CandQO quesData = new CandQO();
                        quesData.QId = ques.QId;
                        quesData.QuestionText = ques.QuestionText;
                        quesData.Options = new List<CandO>();
                        var optList = db.TP_Options.Where(z => z.QId == ques.QId).ToList();
                        foreach (var optObj in optList)
                        {
                            CandO optData = new CandO();
                            optData.OptId = optObj.OptId;
                            optData.OptionText = optObj.OptionText;
                            quesData.Options.Add(optData);
                        }
                        quesOptData.Questions.Add(quesData);
                    }
                    resp.Resp = true;
                    resp.RespMsg = "Test Data Found Successfully";
                    resp.RespObj = quesOptData;
                    return resp;
                }
                else
                {
                    resp.Resp = false;
                    resp.RespMsg = "Test Data Found Successfully";
                    resp.RespObj = quesOptData;
                    return resp;
                }
            }
            catch (Exception ex)
            {
                resp.Resp = false;
                resp.RespMsg = "Something Went Wrong";
                resp.RespObj = ex.StackTrace;
                return null;
            }
        }
        public Response SaveCandTest(CandTestSubmit candData)
        {
            Response resp = new Response();
            try
            {
                if (candData != null)
                {
                    var testData = db.TP_TestDetail.FirstOrDefault(z => z.TestId == candData.TestId);
                    int correctCount = 0;
                    int incorrectCount = 0;
                    int points = 0;
                    foreach (var qo in candData.QOs)
                    {
                        Results r = new Results();
                        var correctOption = db.TP_Options.FirstOrDefault(z => z.QId == qo.QId && z.IsCorrect == true);
                        r.QId = qo.QId;
                        r.AnsId = qo.OptId;
                        r.CId = candData.CandId;
                        r.TestId = candData.TestId;
                        r.ScheduleId = candData.ScheduleId;
                        r.CreatedBy = candData.CandId;
                        r.CreatedOn = DateTime.Now;
                        db.TP_Results.Add(r);
                        if (correctOption.OptId == qo.OptId)
                        {
                            correctCount++;
                            points += testData.PerQ_Point;
                        }
                        else
                        {
                            incorrectCount++;
                        }
                    }

                    FResult fr = new FResult();
                    fr.CId = candData.CandId;
                    fr.TestId = candData.TestId;
                    fr.ScheduleId = candData.ScheduleId;
                    fr.CorrectCount = correctCount * testData.PerQ_Point;
                    fr.IncorrectCount = incorrectCount;
                    fr.Points = points;
                    fr.SubmissionDate = DateTime.Now;
                    db.TP_FResults.Add(fr);
                    int i = db.SaveChanges();
                    if (i > 0)
                    {
                        resp.Resp = true;
                        resp.RespMsg = "Candidate Test Save Successfully";
                        return resp;
                    }
                    else
                    {
                        resp.RespMsg = "Failed To Saved";
                        resp.RespObj = null;
                        return resp;
                    }
                }
                else
                {
                    resp.RespMsg = "Candidate Test Data is Empty";
                    resp.RespObj = candData;
                    return resp;
                }


            }
            catch (Exception ex)
            {
                resp.RespMsg = ex.Message;
                resp.RespObj = ex.StackTrace;
                return resp;
            }
        }
        public List<ViewCandResult> GetAllCandResults()
        {
            List<ViewCandResult> results = new List<ViewCandResult>();
            using (SqlConnection con = new SqlConnection(_config.GetConnectionString("TPDB")))
            {
                string query = @"select TP_FResults.*,TP_CandidateDetail.Name,TP_Schedule.StartTime,TP_Schedule.EndTime,TP_TestDetail.TestName
                                from TP_FResults
                                LEFT JOIN TP_CandidateDetail
                                on TP_FResults.CId  = TP_CandidateDetail.CId
                                left join TP_Schedule
                                on TP_FResults.ScheduleId = TP_Schedule.ScheduleId
                                left join TP_TestDetail
                                on TP_FResults.TestId = TP_TestDetail.TestId;";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                var sdr = cmd.ExecuteReader();
                try
                {
                    while (sdr.Read())
                    {
                        ViewCandResult candResult = new ViewCandResult();
                        candResult.Name = sdr["Name"].ToString();
                        candResult.TestName = sdr["TestName"].ToString();
                        candResult.StartTime = DateTime.Parse(sdr["StartTime"].ToString());
                        candResult.EndTime = DateTime.Parse(sdr["EndTime"].ToString());
                        candResult.SubmissionDate = DateTime.Parse(sdr["SubmissionDate"].ToString());
                        candResult.CorrectCount = int.Parse(sdr["CorrectCount"].ToString());
                        candResult.IncorrectCount = int.Parse(sdr["IncorrectCount"].ToString());
                        candResult.Points = int.Parse(sdr["Points"].ToString());
                        results.Add(candResult);
                    }
                    
                    return results;
                }
                catch (Exception ex)
                {
                    return null;
                }
            }
        }


    }
}
