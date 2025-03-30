using Microsoft.AspNetCore.Mvc;
using projetinho.Repositorio;
using projetinho.Models;
using projeto1.Repositorio;

namespace projetinho.Controllers
{
    public class ProdutoController : Controller
    {
        //contrutor
        private readonly UsuarioRepositorio _usuarioRepositorio;

        public ProdutoController(UsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Cadastro(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _usuarioRepositorio.AdicionarUsuario(usuario);
                return RedirectToAction("Login");
                //possivel erro
            }
            return View(usuario);
        }
    }
}
