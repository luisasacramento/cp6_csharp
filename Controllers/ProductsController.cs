using Microsoft.AspNetCore.Mvc;
using SimpleStoreApi.Models;
using SimpleStoreApi.Services;

namespace SimpleStoreApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly IProductService _service;

    public ProductsController(IProductService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Product>> GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public ActionResult<Product> GetById(Guid id)
    {
        var product = _service.GetById(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    [HttpPost]
    public ActionResult<Product> Create([FromBody] Product product)
    {
        var created = _service.Create(product);
        return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult Update(Guid id, [FromBody] Product product)
    {
        var updated = _service.Update(id, product);
        if (!updated) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        var deleted = _service.Delete(id);
        if (!deleted) return NotFound();
        return NoContent();
    }
}