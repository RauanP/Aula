using Aula2407.Data;
using Aula2407.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Aula2407.Controllers
{
    public class ProdutosController : Controller
    {
        private readonly AulaContext _context;

        public ProdutosController(AulaContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> DetalhesProdutos(int id)
        {
            return View(await _context.Produtos.FindAsync(id));
        }
        
        //BUSCAR PRODUTO
        public async Task<IActionResult> BuscarProduto()
        {
            return View(await _context.Produtos.ToListAsync());
        }

        //CADASTRO PRODUTO
        public IActionResult CadastroProduto()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroProduto([Bind("Id, Nome, Marca, Quantidade, Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(produto);
                await _context.SaveChangesAsync();
                return RedirectToAction("BuscarProduto", "Produtos");
            }
            return View(produto);
        }
    }
}
