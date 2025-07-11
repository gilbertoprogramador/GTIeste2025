using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;


namespace WCFServiceHost.Interface
{
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract] void Incluir(Cliente c);
        [OperationContract] void Alterar(Cliente c);
        [OperationContract] void Excluir(string cpf);
        [OperationContract] Cliente BuscarPorCPF(string cpf);
        [OperationContract] List<Cliente> ListarTodos();
    }
}



