using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Model
{
    //REPRESENTACAO DA REGRA DE NEGOCIO 
    public class Cliente : Entity
    {
        public Cliente()
        {
            Id = new Guid();
            Enderecos = new List<Endereco>();
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }

        public DateTime DataNascimento { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public bool Excluido { get; set; }

        //Virtual por causa do lazyLoadignhotm
        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
