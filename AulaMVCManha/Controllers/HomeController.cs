using AulaMVCManha.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AulaMVCManha.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Calcula()
        {
            ViewBag.Nome = "Jorge";
            ViewBag.Idade = 35;
            ViewBag.Cpf = "12545512378";

            Pessoa pes = new Pessoa
            {
                Nome = "Luiz Gustavo",
                Idade = 29,
                Cpf = "12385278963"
            };

            return View(pes);
        }

        [HttpPost]
        public IActionResult AuthCadastro(string numeroConta, string saldo)
        {
            // Ações do BD
            if (!string.IsNullOrEmpty(numeroConta) &&
               !string.IsNullOrEmpty(saldo))
            {
                DBFunctions.InsereConta(numeroConta, saldo);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("Calcula", "Home");    
            }


        }

    }
}
