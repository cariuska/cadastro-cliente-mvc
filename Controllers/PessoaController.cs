using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cadastro_cliente_mvc.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace cadastro_cliente_mvc.Controllers
{
    public class PessoaController : Controller
    {
        private readonly ILogger<PessoaController> _logger;
        private readonly PessoaContexto _pessoaContext;

        public PessoaController(PessoaContexto pessoaContext, ILogger<PessoaController> logger)
        {
            _pessoaContext = pessoaContext;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_pessoaContext.Pessoa.OrderBy(x => x.pessoaId).ToList());
        }
        public ActionResult Add()
        {            
            ViewBag.tipos = new List<TipoPessoa> {
                new TipoPessoa {tipoPessoa = "F", Nome="Física" },
                new TipoPessoa {tipoPessoa = "J", Nome="Jurídica" }
            };

            return View();
        }

        [HttpPost]
        public ActionResult Add(Pessoa pessoa)
        {
            _pessoaContext.Pessoa.Add(pessoa);
            _pessoaContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int Id)
        {
            var pessoa = _pessoaContext.Pessoa.Where(x => x.pessoaId == Id).FirstOrDefault();

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Delete(Pessoa pessoa)
        {
            _pessoaContext.Pessoa.Remove(pessoa);
            _pessoaContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int Id)
        {

            ViewBag.tipos = new List<TipoPessoa> {
                new TipoPessoa {tipoPessoa = "F", Nome="Física" },
                new TipoPessoa {tipoPessoa = "J", Nome="Jurídica" }
            };

            var pessoa = _pessoaContext.Pessoa.Where(x => x.pessoaId == Id).FirstOrDefault();

            return View(pessoa);
        }
        public ActionResult Details(int Id)
        {
            var pessoa = _pessoaContext.Pessoa.Where(x => x.pessoaId == Id).FirstOrDefault();

            return View(pessoa);
        }

        [HttpPost]
        public ActionResult Edit(Pessoa pessoa)
        {
            if (pessoa.tipoPessoa == "F")
            {
                pessoa.CNPJ = "";
                pessoa.RazaoSocial = "";
                pessoa.NomeFantasia = "";
            }
            else
            {
                pessoa.CPF = "";
                pessoa.DataNascimento = null;
                pessoa.Nome = "";
                pessoa.Sobrenome = "";
            }


            _pessoaContext.Entry(pessoa).State = EntityState.Modified;            
            _pessoaContext.SaveChanges();
            return RedirectToAction("Index");
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
