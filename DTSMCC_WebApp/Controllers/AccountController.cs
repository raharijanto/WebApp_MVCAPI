using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DTSMCC_WebApp.Controllers
{
    public class AccountController : Controller
    {
        HttpClient httpClient;
        string address;

        public AccountController()
        {
            this.address = "https://localhost:44332/api/Account/";
            httpClient = new HttpClient
            {
                BaseAddress = new Uri(address)
            };
            
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(login), Encoding.UTF8, "application/json");
            var resultLogin = httpClient.PostAsync(address, content).Result;
            if (resultLogin.IsSuccessStatusCode)
            {
                var data = JsonConvert.DeserializeObject<ResponseClient>(await resultLogin.Content.ReadAsStringAsync());
                HttpContext.Session.SetString("Role", data.data.Role);
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}
