using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guia_Tramites_Api.Services;
namespace Guia_Tramites_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FontAwesomeController : Controller
    {
        private IFontAwesomeService _fontAwesome;
        public FontAwesomeController(IFontAwesomeService fontAwesome)
        {
            _fontAwesome = fontAwesome;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _fontAwesome.read();
            return Ok(lst);
        }
    }
}
