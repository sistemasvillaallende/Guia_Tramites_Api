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
    public class TramiteController : Controller
    {
        private ITramitesService _tramiteService;
        public TramiteController(ITramitesService tramiteService)
        {
            _tramiteService = tramiteService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult read(int idUnidadAdministrativa)
        {
            var lst =
                _tramiteService.read(idUnidadAdministrativa);
            return Ok(lst);
        }
        [HttpPost]
        public IActionResult insert(Entities.tramite obj)
        {
            _tramiteService.insert(obj);
            var lst = _tramiteService.read(obj.id_unidad_administrativa);

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult update(Entities.tramite obj)
        {
            _tramiteService.update(obj);
            var lst = _tramiteService.read(obj.id_unidad_administrativa);

            return Ok(lst);
        }
        [HttpPost]
        public IActionResult updateActiva(Entities.tramite obj)
        {
            _tramiteService.updateActiva(obj.id, obj.activa);
            var lst = _tramiteService.read(obj.id_unidad_administrativa);

            return Ok(lst);
        }
    }
}
