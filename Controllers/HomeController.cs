using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using app_mvc_core_identity.Models;
using Microsoft.AspNetCore.Authorization;
using app_mvc_core_identity.Extensions;

namespace app_mvc_core_identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new Exception("Error");
            return View();
        }

        [Authorize(Roles = "Admin, Gestor")]
        public IActionResult Secret()
        {
            ViewData["Title"] = "Secret";
            return View();
        }

        [Authorize(Policy = "PodeExcluir")]
        public IActionResult SecretClaim()
        {
            ViewData["Title"] = "Secret Claim";
            return View("Secret");
        }

        [Authorize(Policy = "PodeEscrever")]
        public IActionResult SecretClaimPodeEscreverLer()
        {
            ViewData["Title"] = "Secret Claim Escrever e Ler";
            return View("Secret");
        }

        [Authorize(Roles = "Funcionario")]
        public IActionResult AcessoNegado()
        {
            ViewData["Title"] = "Acesso Negado";
            return View("Secret");
        }

        [ClaimAuthorize("Produtos", "Ler")]
        public IActionResult CaimsCustom()
        {
            ViewData["Title"] = "CaimsCustom";
            return View("Secret");
        }

        [Route("erro/{id:length(3,3)}")]
        public IActionResult Error(int id)
        {
            var modelErro = new ErrorViewModel();
            ErrorStatusCode(id, modelErro);
            return View("Error", modelErro);
        }

        private void ErrorStatusCode(int id, ErrorViewModel modelErro)
        {
            if (id == 500)
            {
                modelErro.Mensagem = "Ocorreu um erro! Tente novamente mais tarde ou contate nosso suporte";
                modelErro.Titulo = "Ocorreu um erro!";
                modelErro.ErroCode = id;
            }
            else if (id == 404)
            {
                modelErro.Mensagem = "A página que você esta procurando não existe !";
                modelErro.Titulo = "Ops! Página não encontrada";
                modelErro.ErroCode = id;
            }
            else if (id == 403)
            {
                modelErro.Mensagem = "Você não tem permissão para fazer isso !";
                modelErro.Titulo = "Acesso negado";
                modelErro.ErroCode = id;
            }
            else
            {
                StatusCode(404);
            }
        }

    }
}
