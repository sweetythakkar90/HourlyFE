using HourlyFE.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace HourlyFE.Controllers
{
    public class CompanyController : Controller
    {
        
        string Baseurl = "http://localhost:37716/";
        // GET: Company
        public async Task<ActionResult> Index()
        {
            List<EmployeeModel> EmployeeInfo = new List<EmployeeModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();

                // Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllComapnies using HttpClient 
                HttpResponseMessage Res = await client.GetAsync("api/employees");

                //Checking the response is successful or not which is sent using HttpClient
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api 
                    var EmployeeResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Company list  
                    EmployeeInfo = JsonConvert.DeserializeObject<List<EmployeeModel>>(EmployeeResponse);
                }

                //returning the company list to view  
                return View(EmployeeInfo);
            }
        }
    }
}