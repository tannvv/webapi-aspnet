using DemoWebAPIApp.Models;
using DemoWebAPIApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private readonly ITypeRepository _typeRepository;

        public TypeController(ITypeRepository typeRepository)
        {
            _typeRepository = typeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_typeRepository.GetAll());
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var _type = _typeRepository.GetById(id);
                if (_type != null)
                {
                    return Ok(_type);
                }
                else
                {
                    return NotFound();
                }
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, TypeVM typeVM)
        {
            try
            {
                if (id != typeVM.TypeID)
                {
                    return BadRequest();
                }
                _typeRepository.Update(typeVM);
                return NoContent();
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _typeRepository.Delete(id);

                return NoContent();

            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }

}
