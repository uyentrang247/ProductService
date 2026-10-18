using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductService.Data;
using ProductService.Models;

namespace ProductService.Controllers;

[ApiController]
[Route("products")]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly ProductDbContext _context;

    public ProductsController(ProductDbContext context)
    {
        _context = context;
    }

    // GET /products
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
    {
        var products = await _context.Products
            .AsNoTracking()
            .OrderBy(p => p.Id)
            .ToListAsync();

        return Ok(products);
    }

    // GET /products/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Product>> GetProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound(new
            {
                message = $"Không tìm thấy sản phẩm có ID {id}"
            });

        return Ok(product);
    }

    // POST /products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(
        [FromBody] Product request)
    {
        var product = new Product
        {
            Name = request.Name,
            Description = request.Description,
            Price = request.Price,
            Quantity = request.Quantity,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetProduct),
            new { id = product.Id },
            product);
    }

    // PUT /products/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateProduct(
        int id,
        [FromBody] Product request)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound(new
            {
                message = $"Không tìm thấy sản phẩm có ID {id}"
            });

        product.Name = request.Name;
        product.Description = request.Description;
        product.Price = request.Price;
        product.Quantity = request.Quantity;
        product.UpdatedAt = DateTime.UtcNow;

        await _context.SaveChangesAsync();

        return Ok(product);
    }

    // DELETE /products/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _context.Products.FindAsync(id);

        if (product == null)
            return NotFound(new
            {
                message = $"Không tìm thấy sản phẩm có ID {id}"
            });

        _context.Products.Remove(product);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}