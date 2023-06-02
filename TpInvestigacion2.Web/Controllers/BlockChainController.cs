using Microsoft.AspNetCore.Mvc;
using TpInvestigacion.Data.Entidades;
using TpInvestigacion.Servicio.Interface;

namespace TpInvestigacion.Web.Controllers
{
    public class BlockChainController : Controller
    {
        readonly IServicio _servicio;

        public BlockChainController(IServicio servicio)   
        {
            _servicio = servicio;
        }

        public IActionResult ListarTodo()
        {
            List<Bloque>? lista = _servicio.ListarTodo();
            return View(lista);
        }

        public IActionResult Agregar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AgregarBloque(IFormCollection formulario)
        {

            _servicio.GuardarBloque(formulario["Dato"]);
            return Redirect("/BlockChain/ListarTodo");
        }

        [HttpGet]
        public IActionResult Eliminar(int Id)
        {
            _servicio.EliminarBloque(Id);
            return Redirect("/BlockChain/ListarTodo");
        }

        public IActionResult Editar(int Id)
        {
            Bloque bloque = _servicio.BuscarBloquePorId(Id);
            return View(bloque);
        }

        [HttpPost]
        public IActionResult Editar(IFormCollection formulario)
        {
            Bloque bloqueEditado = new Bloque();
            bloqueEditado.Id = int.Parse(formulario["Id"]);
            bloqueEditado.Datos = formulario["Datos"];
            bloqueEditado.Hash = formulario["Hash"];
            bloqueEditado.HashAnterior = formulario["HashAnterior"];
            bloqueEditado.Tiempo = DateTime.Parse(formulario["Tiempo"]);
            _servicio.ModificarBloque(bloqueEditado);
            return Redirect("/BlockChain/ListarTodo");
        }

        public IActionResult DefinirIntegridad()
        {
            string resultado = _servicio.VerificarIntegridad();
            return View("DefinirIntegridad", resultado);
        }
    }
}
