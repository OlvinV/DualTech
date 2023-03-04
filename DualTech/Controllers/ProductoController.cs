using DualTech.Models.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DualTech.Models;

namespace DualTech.Controllers
{
    public class ProductoController : Controller
    {
        private readonly DbdualTechContext _dbdualtechContext;
        public ProductoController(DbdualTechContext _dbdualtechContext)
        {
            this._dbdualtechContext = _dbdualtechContext;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var productos = await _dbdualtechContext.Productos.ToListAsync();
            return View(productos);
        }

        [HttpGet]
        public IActionResult CrearP()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CrearP(Producto AddProductRequest)
        {
            var product = new Producto()
            {
                ProductoId = Guid.NewGuid(),
                Nombre = AddProductRequest.Nombre,
                Descripcion = AddProductRequest.Descripcion,
                Precio = AddProductRequest.Precio,
                Existencia = AddProductRequest.Existencia
            };
            await _dbdualtechContext.Productos.AddAsync(product);
            await _dbdualtechContext.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var producto = await _dbdualtechContext.Productos.FirstOrDefaultAsync(x => x.ProductoId == id);

            if (producto != null)
            {
                var viewModel = new ActualizacionProductoVista()
                {
                    ProductoId = producto.ProductoId,
                    Nombre = producto.Nombre,
                    Descripcion = producto.Descripcion,
                    Precio = producto.Precio,
                    Existencia = producto.Existencia
                };

                return await Task.Run(() => View("View", viewModel));
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(ActualizacionProductoVista model)
        {
            var producto = await _dbdualtechContext.Productos.FindAsync(model.ProductoId);

            if (producto != null)
            {
                producto.Nombre = model.Nombre;
                producto.Descripcion = model.Descripcion;
                producto.Precio = model.Precio;
                producto.Existencia = model.Existencia;

                await _dbdualtechContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Eliminar(ActualizacionProductoVista model)
        {
            var producto = await _dbdualtechContext.Productos.FindAsync(model.ProductoId);

            if (producto != null)
            {
                _dbdualtechContext.Productos.Remove(producto);
                await _dbdualtechContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
