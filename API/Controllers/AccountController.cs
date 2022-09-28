using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var dataLogin = accountRepository.Login(login);
            if (dataLogin != null)
            {
                return Ok(new { message = "Berhasil login", statusCode = 200, data = dataLogin });
            }
            return BadRequest(new { message = "Gagal login", statusCode = 400 });
        }
    }
}
