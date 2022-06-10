using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Guia_Tramites_Api.Services;
using Newtonsoft.Json;

namespace Guia_Tramites_Api.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UnidadAdministrativaController : Controller
    {
        private IUnidadAdministrativaService _unidadAdministrativa;
        public UnidadAdministrativaController(IUnidadAdministrativaService unidadAdministrativa)
        {
            _unidadAdministrativa = unidadAdministrativa;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult read()
        {
            var lst =
                _unidadAdministrativa.read();
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.unidad_administrativa obj)
        {
            _unidadAdministrativa.insert(obj);
            var lst = _unidadAdministrativa.read();

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.unidad_administrativa obj)
        {
            _unidadAdministrativa.update(obj);
            var lst = _unidadAdministrativa.read();

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateActiva(Entities.unidad_administrativa obj)
        {
            _unidadAdministrativa.updateActiva(obj.id, obj.activa);
            var lst = _unidadAdministrativa.read();

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult delete(Entities.unidad_administrativa obj)
        {
            _unidadAdministrativa.delete(obj.id);
            var lst = _unidadAdministrativa.read();

            return Ok(lst);
        }
        public IActionResult reordenar(string json)
        {
            List<Entities.Reordenar> lst =
                JsonConvert.DeserializeObject<List<Entities.Reordenar>>(json);
            _unidadAdministrativa.reordenar(lst);
            var live = _unidadAdministrativa.read();

            return Ok(live);

        }
    }
}
