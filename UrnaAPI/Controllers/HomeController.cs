using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using UrnaAPI.Models;

namespace UrnaAPI.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Swagger()
        {
            return Redirect("https://localhost:44362/swagger");
        }

        public IActionResult Candidate()
        {
            var candidates = GetCandidates();

            return View(candidates);
        }

        public IActionResult Vote()
        {
            var candidates =  GetCandidates();

            return View(candidates);
        }

        private static IEnumerable<Candidate> GetCandidates()
        {
            var webRequest = WebRequest.CreateHttp("https://localhost:44362/api/Candidates");

            webRequest.Method = "GET";
            webRequest.UserAgent = "GetCandidates";

            using (var response = webRequest.GetResponse())
            {
                var data = response.GetResponseStream();
                StreamReader reader = new StreamReader(data);
                object objResponse = reader.ReadToEnd();
                var candidates = JsonConvert.DeserializeObject<IEnumerable<Candidate>>(objResponse.ToString());
                return candidates;
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}