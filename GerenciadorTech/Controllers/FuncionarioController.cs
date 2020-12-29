using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorTech.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GerenciadorTech.Controllers
{
    public class FuncionarioController : Controller
    {
        
        private static List<Funcionario> _banco = new List<Funcionario>();

        //Listar todos os funcionários cadastrados
        public IActionResult Index()
        {
            //Enviar a lista de funcionários para a view
            return View(_banco);
        }

        
        [HttpPost]
        public IActionResult Remover(int id)
        {
            //Remover da lista (remove pelo index
            _banco.RemoveAt(_banco.FindIndex(f => f.Codigo == id));
            //Mensagem de sucesso
            TempData["msg"] = "Funcionário demitido";
            //Redirect
            return RedirectToAction("Index");
        }

        //Método que atualiza o funcionário no "banco"
        [HttpPost]
        public IActionResult Editar(Funcionario funcionario) {

            //Editar o funcionario (pesquisa o index do funcionário e substitui o objeto
            _banco[ _banco.FindIndex(f => f.Codigo == funcionario.Codigo)] = funcionario;

            
            TempData["msg"] = "Funcionário atualizado";

            //Redirect para a listagem
            return RedirectToAction("Index");
        }

        //Método que recebe o id do funcionário e retorna os valores do funcionario para a view
        [HttpGet]
        public IActionResult Editar(int id)
        {
            //Envia os valores para preencher o select
            CarregarDepartamentos();
            //Pesquisar o funcionário com o código informado
            var funcionario = _banco.Find(f => f.Codigo == id);
            //Enviar o funcionário para a view
            return View(funcionario);
        }

        //Cadastrar o funcionário na lista e reotrnar uma msg de sucesso
        
        [HttpPost]
        public IActionResult Cadastrar(Funcionario funcionario)
        {
            //Valida se existe elemento na lista
            if (_banco.Any())
            {
                funcionario.Codigo = _banco[_banco.Count - 1].Codigo + 1; //Count = size()
            }
            else
            {
                funcionario.Codigo = 1;
            }

            _banco.Add(funcionario);
            TempData["msg"] = "Funcionário registrado!";
            return RedirectToAction("Cadastrar");
        }
        //Ajusta a listagem e edição para exibir e modificar o departamento
        public ActionResult Editarf(Funcionario funcionario)
        {
            //Editar o departamento do funcionário
            TempData["msg"] = "Setor atualizado!";
            //Redirect para a listagem
            return RedirectToAction("Index");
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            CarregarDepartamentos();

            return View();
        }

        private void CarregarDepartamentos()
        {
            //Enviar os dados para preencher o select de setores da empresa
            List<string> lista = new List<string>();
            lista.Add("Tecnologia");
            lista.Add("Financas");
            lista.Add("RH");
            lista.Add("Comercial");
            lista.Add("Juridico");
            
            ViewBag.departamentos = new SelectList(lista);
        }
        /*Tecnologia, Financas, RH, Comercial, Juridico */
    }
}
