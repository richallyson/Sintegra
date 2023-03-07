using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SintegraMVC.Models;
using SintegraMVC.Util;

namespace SintegraMVC.Controllers
{
    [Route("sintegra")]
    public class SintegraController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("validar-inscricao-estadual")]
        public ActionResult ValidarInscricaoEstadual([FromBody] SintegraViewModel sintegraViewModel)
        {
            var validar = SintegraUtil.ValidarInscricaoEstadual(sintegraViewModel.InscricaoEstadual, sintegraViewModel.Uf);
            return Json(validar);
        }
    }
}