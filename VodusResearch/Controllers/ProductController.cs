using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VodusResearch.Context;
using VodusResearch.Models;

namespace VodusResearch.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            if (ModelState.IsValid)
            {
                await _context.Products.AddAsync(product);
                await _context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            else
            {
                return View(product);
            }
        }
    }
}
