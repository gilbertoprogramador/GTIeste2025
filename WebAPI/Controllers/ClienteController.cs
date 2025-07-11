using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using WebAPI.Models;


namespace WebAPI.Controllers
{
    
    public class ClienteController : ApiController
    {
        private readonly GTIDbContext db = new GTIDbContext();

        // Inclusão
        [HttpPost]
        public IHttpActionResult Post(Cliente cliente)
        {
            cliente.CPF = Regex.Replace(cliente.CPF, "[^0-9]", "");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            db.Clientes.Add(cliente);
            db.SaveChanges();
            return Ok("Cliente incluída com sucesso.");
        }

        // Alteração
        [HttpPut]
        public IHttpActionResult Put(Cliente cliente)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
            return Ok("Cliente atualizada.");
        }

        // Exclusão
        [HttpDelete]
        public IHttpActionResult Delete(string cpf)
        {
            var cliente = db.Clientes.Find(cpf);
            if (cliente == null) return NotFound();

            db.Clientes.Remove(cliente);
            db.SaveChanges();
            return Ok("Cliente excluída.");
        }

        // Consulta
        [HttpGet]
        public IHttpActionResult Get()
        {
            var clientes = db.Clientes.ToList();

            if (clientes == null || !clientes.Any())
                return NotFound();

            return Ok(clientes);
        }

        [HttpGet]
        [Route("api/cliente/cpf/{cpf}")]
        public IHttpActionResult GetByCpf(string cpf)
        {
            try
            {
                var cliente = db.Clientes.Find(Regex.Replace(cpf, "[^0-9]", ""));
                if (cliente == null) return NotFound();
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }

}