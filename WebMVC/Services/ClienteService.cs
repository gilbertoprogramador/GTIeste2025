using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WebAPI.Models;

namespace WebMVC.Services
{
    public class ClienteService
    {
        private readonly string _url = "http://localhost:51456/api/Cliente";

        public async Task<List<Cliente>> ListarAsync()
        {
            using (var client = new HttpClient())
            {
                var resposta = await client.GetAsync(_url);
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<Cliente>>(json);
            }
        }

        public async Task<Cliente> BuscarPorCpfAsync(string cpf)
        {
            using (var client = new HttpClient())
            {
                var resposta = await client.GetAsync($"{_url}/cpf/{cpf}/");
                var json = await resposta.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Cliente>(json);
            }
        }

        public async Task CriarAsync(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PostAsync(_url, content);
            }
        }

        public async Task AtualizarAsync(Cliente cliente)
        {
            using (var client = new HttpClient())
            {
                var json = JsonConvert.SerializeObject(cliente);
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                await client.PutAsync($"{_url}/{cliente.CPF}", content);
            }
        }

        public async Task<bool> ExcluirAsync(string cpf)
        {
            using (var client = new HttpClient())
            {
                HttpResponseMessage resposta = await client.DeleteAsync($"{_url}?cpf={cpf}");

                if (resposta.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    // Você pode logar o erro ou lançar exceção personalizada
                    string detalheErro = await resposta.Content.ReadAsStringAsync();
                    Console.WriteLine($"Erro ao excluir CPF: {cpf}. Detalhes: {detalheErro}");

                    return false;
                }
            }
        }

    }
}