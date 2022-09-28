using API.Context;
using API.Models;
using API.Repositories.Data;
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
    public class JobsController : ControllerBase
    {
        JobsRepository jobsRepository;

        public JobsController(JobsRepository jobsRepository)
        {
            this.jobsRepository = jobsRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var dataGet = jobsRepository.Get();
            if (dataGet.Count == 0)
            {
                return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = "null" });
            }
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = dataGet });
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var dataGet = jobsRepository.Get(id);
            if (dataGet == null)
            {
                return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = "null" });
            }
            return Ok(new { message = "Sukses mengambil data", statusCode = 200, data = dataGet });
        }

        [HttpPut]
        public IActionResult Put(Jobs jobs)
        {
            var resultPut = jobsRepository.Put(jobs);
            if (resultPut > 0)
            {
                return Ok(new { message = "Sukses memperbarui data", statusCode = 200 });
            }
            return BadRequest(new { message = "Gagal memperbarui data", statusCode = 400});
        }

        [HttpPost]
        public IActionResult Post(Jobs jobs)
        {
            var resultPost = jobsRepository.Post(jobs);
            if (resultPost > 0)
            {
                return Ok(new { message = "Sukses menambahkan data", statusCode = 200 });
            }
            return BadRequest(new { message = "Gagal menambahkan data", statusCode = 400 });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultDelete = jobsRepository.Delete(id);
            if (resultDelete > 0)
            {
                return Ok(new { message = "Sukses menghapus data", statusCode = 200 });
            }
            return BadRequest(new { message = "Gagal menghapus data", statusCode = 400 });
        }
    }
}
