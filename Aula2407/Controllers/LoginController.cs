using Aula2407.Data;
using Aula2407.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Aula2407.Controllers
{
    public class LoginController : Controller
    {
        private readonly AulaContext _context;
        public LoginController(AulaContext context)
        {
            _context = context;
        }

        // GET: Account/Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model)
        {
            if (ModelState.IsValid)
            {
                // Substitua pela lógica de autenticação real
                if (ValidarUsuario(model.Senha, model.Usuario))
                {
                    // Simulação de redirecionamento para uma página inicial após login bem-sucedido
                    return RedirectToAction("BuscarCliente", "Cliente");
                }
                else
                {
                    ModelState.AddModelError("", "Login inválido. Verifique o e-mail e a senha.");
                }
            }

            // Se chegamos aqui, algo falhou; mostre o formulário novamente com os erros
            return View(model);
        }

        // Este método deve ser substituído pela sua lógica de autenticação real
        private bool ValidarUsuario(string s, string u)
        {
            // Simulação de verificação de usuário
            // Aqui, você pode usar seu banco de dados, API, ou qualquer outro método para validar o usuário
            var usuario = _context.Usuarios.SingleOrDefault(p => p.Usuario == u);

            if (usuario == null || usuario.Senha != s)
                return false;
            else
                return true;

        }

        // GET: Account/Logout
        [HttpGet]
        public ActionResult Logout()
        {
            // Lógica de logout
            // Exemplo: Session.Clear(); ou FormsAuthentication.SignOut();

            return View("Login");
        }
    }
}