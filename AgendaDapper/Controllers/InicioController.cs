using AgendaDapper.Models;
using AgendaDapper.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AgendaDapper.Controllers
{
    public class InicioController : Controller
    {
        public readonly IRepositorio _repo;

        public InicioController(IRepositorio repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_repo.GetClientes());
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear([Bind("IdCliente, Nombres, Apellidos, Telefono, Email, Pais, FechaCreacion")] Cliente cliente)
        {
            if(ModelState.IsValid)
            {
                _repo.AgregarCliente(cliente);  
                //SI SE INSERT CORRECTAMETE SEW REDIRECCIONE AL INDEX 
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);

        }

        //Obtengo el cliente para Editar
        [HttpGet]
        public IActionResult Editar(int? id)
        {
            var cliente = _repo.GetCliente(id.GetValueOrDefault());
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, [Bind("IdCliente, Nombres, Apellidos, Telefono, Email, Pais, FechaCreacion")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {
                _repo.ActualizarCliente(cliente);
                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }


        //Obtengo el cliente para Borrar
        [HttpGet]
        public IActionResult Borrar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            _repo.BorrarCliente(id.GetValueOrDefault());
            return RedirectToAction(nameof(Index));
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
