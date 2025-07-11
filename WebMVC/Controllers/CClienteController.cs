using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WebAPI.Models;
using WebMVC.Services;

namespace WebMVC.Controllers
{
    public class CClienteController : Controller
    {
        private readonly ClienteService _service = new ClienteService();

        public async Task<ActionResult> Index()
        {            
            return View();
        }

        public async Task<ActionResult> RetornarClientes()
        {
            var clientes = await _service.ListarAsync();
            return Json(clientes, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public async Task<ActionResult> Criar(Cliente cliente)
        {
            var clienteExistente = await _service.BuscarPorCpfAsync(cliente.CPF);

            if (clienteExistente != null)
            {
                return Json(new
                {
                    sucesso = false,
                    mensagem = "Este CPF já está cadastrado!"
                });
            }

            await _service.CriarAsync(cliente);

            return Json(new
            {
                sucesso = true,
                mensagem = "Cliente criado com sucesso!"
            });
        }


        public async Task<JsonResult> BuscarPorCPF(string cpf)
        {
            var pessoa = await _service.BuscarPorCpfAsync(cpf);
            return Json(pessoa, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Cliente cliente)
        {            
            await _service.AtualizarAsync(cliente);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<ActionResult> Excluir(string cpf)
        {
            try
            {
                var pessoa = await _service.BuscarPorCpfAsync(cpf);
                if (pessoa == null)
                    return Json(new { sucesso = false, mensagem = "Cliente não encontrado." });

                await _service.ExcluirAsync(cpf); // ou outro método para deletar
                return Json(new { sucesso = true, mensagem = "Cliente excluído com sucesso." });
            }
            catch (Exception ex)
            {
                return Json(new { sucesso = false, mensagem = $"Erro ao excluir: {ex.Message}" });
            }
        }
    }
}