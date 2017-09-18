using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Infra.Dados.Contexto;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.Dados.Repositorios
{
    public class ClienteRepository : Repository<Cliente>, IClienteRepositorio
    {
        public ClienteRepository(ProjetoContext context) : base(context)
        {

        }

        public Cliente ObterPorCpf(string cpf)
        {
            return Buscar(c => c.CPF == cpf).FirstOrDefault();
        }

        public Cliente ObterPorEmail(string email)
        {
            return Buscar(c => c.Email == email).FirstOrDefault();
        }

        public IEnumerable<Cliente> ObterAtivos()
        {
            var sql = @"SELECT * FROM Clientes c " +
                       "WHERE c.Excluido = 0 AND c.Ativo = 1";

            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override IEnumerable<Cliente> ObterTodos()
        {
            var sql = @"SELECT * FROM Clientes c " +
                       "WHERE c.Excluido = 0";

            return Db.Database.Connection.Query<Cliente>(sql);
        }

        public override Cliente ObterPorId(Guid id)
        {
            var sql = @"SELECT * FROM Clientes a " +
                       "LEFT JOIN Enderecos e "+
                       "ON a.Id = e.ClienteId " +
                       "WHERE a.Id = @uid";
                                               //Parametros anonimos
                                               //Seleciona cliente, endereco e retorna cliente
            return Db.Database.Connection.Query<Cliente, Endereco, Cliente>(sql, 
                (c, e) => { c.Enderecos.Add(e); return c; }, new { uid = id}).FirstOrDefault();
        }
        
        public override void Remover(Guid id)
        {
            var cliente = ObterPorId(id);
            cliente.Ativo = false;
            cliente.Excluido = true;

            Atualizar(cliente);
        }
    }
}
