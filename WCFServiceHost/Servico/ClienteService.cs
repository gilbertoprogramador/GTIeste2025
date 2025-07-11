using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using WCFServiceHost.Interface;
using System.Runtime.ConstrainedExecution;


public class ClienteService : IClienteService
{
    string connStr = ConfigurationManager.ConnectionStrings["connectionGTI"].ConnectionString;
    /// <summary>
    /// Inclui um novo cliente no banco de dados.
    /// </summary>
    /// <param name="c"></param>
    public void Incluir(Cliente c)
    {
        using (var conn = new SqlConnection(connStr))
        using (var cmd = new SqlCommand("spIncluirCliente", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPF", c.CPF);
            cmd.Parameters.AddWithValue("@Nome", c.Nome);
            cmd.Parameters.AddWithValue("@RG", c.RG);
            cmd.Parameters.AddWithValue("@DataExpedicao", c.DataExpedicao);
            cmd.Parameters.AddWithValue("@OrgaoExpedicao", c.OrgaoExpedicao);
            cmd.Parameters.AddWithValue("@UF_Expedicao", c.UF_Expedicao);
            cmd.Parameters.AddWithValue("@DataNascimento", c.DataNascimento);
            cmd.Parameters.AddWithValue("@Sexo", c.Sexo);
            cmd.Parameters.AddWithValue("@EstadoCivil", c.EstadoCivil);
            cmd.Parameters.AddWithValue("@CEP", c.CEP);
            cmd.Parameters.AddWithValue("@Logradouro", c.Logradouro);
            cmd.Parameters.AddWithValue("@Numero", c.Numero);
            cmd.Parameters.AddWithValue("@Complemento", c.Complemento);
            cmd.Parameters.AddWithValue("@Bairro", c.Bairro);
            cmd.Parameters.AddWithValue("@Cidade", c.Cidade);
            cmd.Parameters.AddWithValue("@UF", c.UF);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    public void Alterar(Cliente c) { /* semelhante ao Incluir */ }
    /// <summary>
    /// Exclui um cliente pelo CPF.
    /// </summary>
    /// <param name="cpf"></param>
    public void Excluir(string cpf)
    {
        using (var conn = new SqlConnection(connStr))
        using (var cmd = new SqlCommand("spExcluirCliente", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPF", cpf);
            conn.Open();
            cmd.ExecuteNonQuery();
        }
    }
    /// <summary>
    /// Busca um cliente pelo CPF.
    /// </summary>
    /// <param name="cpf"></param>
    /// <returns></returns>
    public Cliente BuscarPorCPF(string cpf)
    {
        using (var conn = new SqlConnection(connStr))
        using (var cmd = new SqlCommand("spBuscarClientePorCPF", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@CPF", cpf);
            conn.Open();

            using (var reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    return new Cliente
                    {
                        CPF = reader["CPF"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        RG = reader["RG"].ToString(),
                        DataExpedicao = reader["DataExpedicao"] != DBNull.Value ? Convert.ToDateTime(reader["DataExpedicao"]) : (DateTime?)null,
                        OrgaoExpedicao = reader["OrgaoExpedicao"].ToString(),
                        UF_Expedicao = reader["UF_Expedicao"].ToString(),
                        DataNascimento = reader["DataNascimento"] != DBNull.Value ? Convert.ToDateTime(reader["DataNascimento"]) : (DateTime?)null,
                        Sexo = reader["Sexo"].ToString(),
                        EstadoCivil = reader["EstadoCivil"].ToString(),
                        CEP = reader["CEP"].ToString(),
                        Logradouro = reader["Logradouro"].ToString(),
                        Numero = reader["Numero"].ToString(),
                        Complemento = reader["Complemento"].ToString(),
                        Bairro = reader["Bairro"].ToString(),
                        Cidade = reader["Cidade"].ToString(),
                        UF = reader["UF"].ToString()
                    };
                }
                return null;
            }
        }
    }
    /// <summary>
    ///     Lista todos os clientes cadastrados no banco de dados.
    /// </summary>
    /// <returns></returns>
    public List<Cliente> ListarTodos()
    {
        var clientes = new List<Cliente>();

        using (var conn = new SqlConnection(connStr))
        using (var cmd = new SqlCommand("spBuscarClienteListarTodos", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();

            using (var reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    var cliente = new Cliente
                    {
                        CPF = reader["CPF"].ToString(),
                        Nome = reader["Nome"].ToString(),
                        Cidade = reader["Cidade"].ToString()
                        // inclua os demais campos conforme necessário  
                    };

                    clientes.Add(cliente);
                }
            }
        }

        return clientes;
    }
}
