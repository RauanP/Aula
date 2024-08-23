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

        public async Task<IActionResult> AlteraProduto(int id)
        {
            return View(await _context.Produtos.FindAsync(id));
        }

        //BUSCAR PRODUTO
        public async Task<IActionResult> BuscarProduto(int pagina = 1)
        {
            var QtdeTProdutos = 3;

            var itensP = await _context.Produtos.ToListAsync();
            //var pagedItens = itens.Skip((pagina - 1) * QtdeTClientes).Take(QtdeTClientes).ToList();


            // Passando os dados e informações de paginação para a view
            ViewBag.QtdePaginas = (int)Math.Ceiling((double)itensP.Count() / QtdeTProdutos);
            ViewBag.PaginaAtual = pagina;
            ViewBag.QtdeTProdutos = QtdeTProdutos;

            return View(itensP);
            //return view(Await _context.Clientes.ToListAsync());
        }

        //CADASTRO PRODUTO
        public async Task<IActionResult> CadastroProduto(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(await _context.Produtos.FindAsync(id));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroProduto([Bind("Id, Nome, Marca, Quantidade, Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                if (produto.Id != 0)
                {
                    _context.Update(produto);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = 2;
                }
                else
                {
                    _context.Add(produto);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = "As informações foram salvas com sucesso!";
                }
                return RedirectToAction("BuscarProduto", "Produtos");
            }
            return View(produto);
        }
    }
}
