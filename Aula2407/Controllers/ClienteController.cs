using Aula2407.Data;
using Aula2407.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Aula2407.Controllers
{
    public class ClienteController : Controller
    {
        private readonly AulaContext _context;

        public ClienteController(AulaContext context)
        {
            _context = context;
        }

        //ALTERAR CLIENTE
        public async Task<IActionResult> AlteraCliente(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }

        //BUSCAR CLIENTE ESPECIFICO - DETALHES
        public async Task<IActionResult> DetalhesClientes(int id)
        {
            return View(await _context.Clientes.FindAsync(id));
        }


        //BUSCAR CLIENTE    
        public async Task<IActionResult> BuscarCliente(int pagina = 1)
        {
            var QtdeTClientes = 3;

            var itens = await _context.Clientes.ToListAsync();
            //var pagedItens = itens.Skip((pagina - 1) * QtdeTClientes).Take(QtdeTClientes).ToList();


            // Passando os dados e informações de paginação para a view
            ViewBag.QtdePaginas = (int)Math.Ceiling((double)itens.Count() / QtdeTClientes);
            ViewBag.PaginaAtual = pagina;
            ViewBag.QtdeTClientes = QtdeTClientes;

            return View(itens);
            //return view(Await _context.Clientes.ToListAsync());
        }

        //CADASTRO CLIENTE
        public async Task<IActionResult> CadastroCliente(int? id)
        {
            if (id == null)
            {
                return View();
            }
            else
            {
                return View(await _context.Clientes.FindAsync(id));
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastroCliente([Bind("Id, Nome, RG,CPF,Usuario,Senha,UF,Cidade,Bairro,Rua,Numero,Complemento")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.Id != 0)
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = 2;
                }
                else
                {
                    _context.Add(cliente);
                    await _context.SaveChangesAsync();
                    TempData["msg"] = "As informações foram salvas com sucesso!";
                }
                return RedirectToAction("BuscarCliente", "Cliente");
            }
            return View(cliente);
        }
    }
}
