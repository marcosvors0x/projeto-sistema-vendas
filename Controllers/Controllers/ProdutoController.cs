using Microsoft.AspNetCore.Mvc;
using projeto_sistema_vendas.Data;
using projeto_sistema_vendas.Models;

namespace projeto_sistema_vendas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ProdutosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/produtos
        [HttpGet]
        public IActionResult GetProdutos()
        {
            var produtos = _context.Produtos.ToList();
            return Ok(produtos);
        }

        // GET: api/produtos/1
        [HttpGet("{id}")]
        public IActionResult GetProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        // POST: api/produtos
        [HttpPost]
        public IActionResult CriarProduto([FromBody] Produto produto)
        {
            _context.Produtos.Add(produto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetProduto), new { id = produto.Id }, produto);
        }

        // PUT: api/produtos/1
        [HttpPut("{id}")]
        public IActionResult AtualizarProduto(int id, [FromBody] Produto produto)
        {
            if (id != produto.Id)
                return BadRequest();

            _context.Produtos.Update(produto);
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/produtos/1
        [HttpDelete("{id}")]
        public IActionResult DeletarProduto(int id)
        {
            var produto = _context.Produtos.Find(id);

            if (produto == null)
                return NotFound();

            _context.Produtos.Remove(produto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}