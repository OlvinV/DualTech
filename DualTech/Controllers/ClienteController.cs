using DualTech.Models;
using DualTech.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DualTech.Controllers
{
    public class ClienteController : Controller
    {
        private readonly DbdualTechContext _dbdualtechContext;
        public ClienteController(DbdualTechContext _dbdualtechContext)
        {
            this._dbdualtechContext = _dbdualtechContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var clientes = await _dbdualtechContext.Clientes.ToListAsync();
            return View(clientes);
        }

        [HttpGet]
        public IActionResult CrearC()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearC(Cliente AddClienteRequest)
        {
            var client = new Cliente()
            {
                ClienteId = Guid.NewGuid(),
                Nombre = AddClienteRequest.Nombre,
                Identidad = AddClienteRequest.Identidad,
            };
            await _dbdualtechContext.Clientes.AddAsync(client);
            await _dbdualtechContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var cliente = await _dbdualtechContext.Clientes.FirstOrDefaultAsync(x => x.ClienteId == id);

            if (cliente != null)
            {
                var viewModel = new ActualizacionClienteVista()
                {
                    ClienteId = cliente.ClienteId,
                    Nombre = cliente.Nombre,
                    Identidad = cliente.Identidad
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(ActualizacionClienteVista model)
        {
            var cliente = await _dbdualtechContext.Clientes.FindAsync(model.ClienteId);

            if(cliente != null)
            {
                cliente.Nombre = model.Nombre;
                cliente.Identidad = model.Identidad;

                await _dbdualtechContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(ActualizacionClienteVista model)
        {
            var cliente = await _dbdualtechContext.Clientes.FindAsync(model.ClienteId);

            if(cliente!=null)
            {
                _dbdualtechContext.Clientes.Remove(cliente);
                await _dbdualtechContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
