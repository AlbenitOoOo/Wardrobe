using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Wardrobe.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using Wardrobe.Data;
using Microsoft.AspNetCore.Identity;

namespace Wardrobe.Controllers
{
    public class HomeController : Controller
    {
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        SqlConnection con = new SqlConnection();
        List<LoginModel> loginModels = new List<LoginModel>();
        List<Cloths> cloths = new List<Cloths>();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            con.ConnectionString = Wardrobe.Properties.Resources.ConnectionString;
           
            
        }

        public IActionResult Index()
        {
            FatchDate();
            return View(loginModels);
        }


        private void FatchDate()
        {
            if(loginModels.Count > 0)
            {
                loginModels.Clear();
            }
            try
            {
                con.Open();
                com.Connection = con;
                com.CommandText = "SELECT TOP (1000) * FROM[Clothes].[dbo].[AspNetUsers] INNER JOIN [Clothes].[dbo].[Cloths] On Cloths.Category = AspNetUsers.Email"; ;
                dr = com.ExecuteReader();
                while (dr.Read())
                {
                    loginModels.Add(new LoginModel()
                    {
                        Id = dr["Id"].ToString(),
                        UserName = dr["UserName"].ToString(),
                        NormalizedUserName = dr["NormalizedUserName"].ToString(),
                        Email = dr["Email"].ToString(),
                        
                        
                    });

                         //cloths.Add(new Cloths()
                         //{
                         //    Category = dr["Category"].ToString(),
                         //    //ColorId = dr["ColorId"].ToString(),
                         //    //KindId = dr["KindId"].ToString(),
                         //    CoverImageUrl = dr["CoverImageUrl"].ToString()
                         //}));

                }
            
                
               
                con.Close();
            }
            catch(Exception)
            {
                throw;
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
