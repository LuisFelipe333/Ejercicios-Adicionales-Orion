using Ejercicio5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio5.Controllers
{
    public class NController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult X([FromBody] RequestData data)
        {
            //Simulamos un proceso que se ejecuta exitosamente y devuelve un resultado
            var respuesta = new List<string>
            {
                 data.dataA,
                 data.dataB,
                 data.dataC,
                "Se ejecuta proceso X exitosamente"
            };

            return Json(respuesta);
        }

    }
}
