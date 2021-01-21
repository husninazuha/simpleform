using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using test4.Models;
using Microsoft.Data;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Protocols;
using System.Configuration;
using System.Dynamic;
using System.Net;
using System.Net.Mail;
using FluentEmail.Core;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Data;

namespace test4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration configuration;
        public HomeController(IConfiguration config)
        {
            this.configuration = config;
        }
        ConnectionDBClass dbop = new ConnectionDBClass();
         public IConfigurationRoot GetConnection()

         {

             var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appSettings.json").Build();

             return builder;

         }

        /*
         private readonly ILogger<HomeController> _logger;


             public HomeController(ILogger<HomeController> logger)
         {
             _logger = logger;
         }
 */
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Question ur)
        {

            SqlConnection sqlconn = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);

            string sqlquery = "insert into vSurvey(CheckBoxAnswer1,CheckBoxAnswer2,CheckBoxAnswer3,CheckBoxAnswer4,Remarks1,Remarks2,Remarks3,Remarks4) values ('" + ur.CheckBoxAnswer1 + "','" + ur.CheckBoxAnswer2 + "','" + ur.CheckBoxAnswer3 + "','" + ur.CheckBoxAnswer4 + "','" + ur.Remarks1 + "','" + ur.Remarks2 + "','" + ur.Remarks3 + "','" + ur.Remarks4 + "')";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                    ViewData["Message"] = "Your feeback has been recorded successfully..!";
                }
            
            return View();
        }
/*
        [HttpGet]
        [Route("Home/GetDetails/{custName:string}")]*/
        public IActionResult  GetDetails(Customer cust)
        {
            SqlConnection sqlconn = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);
        
            string sqlquery = "insert into Customer(CustName,EmailAdd) values ('" + cust.CustName + "','" + cust.EmailAdd + "')";
                using (SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn))
                {
                    sqlconn.Open();
                    sqlcomm.ExecuteNonQuery();
                    
                }

            
            return View("Create");
        }

        public int LoginCheck(Ad_Login ad)
        {
            SqlConnection sqlconn = new SqlConnection(GetConnection().GetSection("ConnectionStrings").GetSection("DefaultConnection").Value);

            SqlCommand com = new SqlCommand("Srv_Login", sqlconn);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@UserName", ad.UserName);
            com.Parameters.AddWithValue("@PassWord", ad.PassWord);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@IsValid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            sqlconn.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            sqlconn.Close();
            return res;
        }

        [HttpPost]
        public IActionResult SurveyQuestion([Bind] Ad_Login ad)
        {
            int res = LoginCheck(ad);
            if (res == 1)
            {
                /*TempData["msg"] = "Login Successfully.";*/
                return View("GetDetails");
            }
            else
            {
                TempData["msg"] = "Username or Password is wrong! Please login again later.";
                return View("Index");
            }

        }

        public string SendEmail(string Name, string Email, string Message)
        {

            try
            {
                // Credentials
                var credentials = new NetworkCredential("hanadelisya88@gmail.com", "unieynazuha1234");
                // Mail message
                var mail = new MailMessage()
                {
                    From = new MailAddress("noreply@codinginfinite.com"),
                    Subject = "Email Sender App",
                    Body = Message
                };
                mail.IsBodyHtml = true;
                mail.To.Add(new MailAddress(Email));
                // Smtp client
                var client = new SmtpClient()
                {
                    Port = 587,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Host = "smtp.gmail.com",
                    EnableSsl = true,
                    Credentials = credentials
                };
                client.Send(mail);
                return "Email Sent Successfully!";
            }
            catch (System.Exception e)
            {
                return e.Message;
            }

        }
    

    public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
