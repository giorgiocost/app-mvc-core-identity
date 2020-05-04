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

        [ClaimAuthorize("Produtos", "Ler")]
        public IActionResult CaimsCustom()
        {
            ViewData["Title"] = "CaimsCustom";
            return View("Secret");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
