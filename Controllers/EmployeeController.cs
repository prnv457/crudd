using crudd.Model;
using crudd.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace crudd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepo repo;
        public EmployeeController(IEmployeeRepo repo) {
            this.repo = repo;

        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll() 
        {
            var _list =await this.repo.GetAll();
            if( _list != null) 
            {
                return ok(_list);
            }
            else 
            {
                return NotFound();
            }
        }

        [HttpGet("GetbyCode/{code}")]
        public async Task<IActionResult> GetbyCode(int code)
        {
            var _list = await this.repo.GetbyCode(code);
            if (_list != null)
            {
                Return ok(_list);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] Employee employee) 
        {
            var _result = await this.repo.Create(employee);
            return Ok(_result);
        }
        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] Employee employee,int code)
        {
            var _result = await this.repo.Update(employee, code);
            return Ok(_result);
        }
        [HttpPost("Remove")]
        public async Task<IActionResult> Remove(int code)
        {
            var _result = await this.repo.Remove(code);
            return Ok(_result);
        }
    }
}
