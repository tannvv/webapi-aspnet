using DemoWebAPIApp.Data;
using DemoWebAPIApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = DemoWebAPIApp.Data.Type;

namespace DemoWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TypesController(AppDbContext context) {
            _context = context;
        }
        /*[HttpGet]
        public IActionResult GetAll() {
            var listType = _context.Types.ToList();
            return Ok(listType);
        }

        [HttpGet("{id}")]
        public IActionResult GetByID(int id) {
            var type = _context.Types.SingleOrDefault(item =>
                item.ID == id
            );
            if (type != null)
            {
                return Ok(type);
            }
            else {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult CreateType(TypeModel model) {
            try
            {
                var type = new Type
                {
                    TypeName = model.TypeName
                };
                _context.Add(type);
                _context.SaveChanges();
                return Ok(type);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateType(int id, TypeModel model)
        {
            try
            {
                var type = _context.Types.SingleOrDefault(item => item.ID == id);
                if (type != null)
                {
                    type.TypeName = model.TypeName;
                    _context.SaveChanges();
                    return Ok(type);
                }
                else {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }*/
    }
}
