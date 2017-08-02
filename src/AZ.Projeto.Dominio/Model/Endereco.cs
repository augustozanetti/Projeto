using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.Model
{
    //REPRESENTACAO DA REGRA DE NEGOCIO 
    public class Endereco : Entity
    {
        public Endereco()
        {
            Id = new Guid();
        }

        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Complemento { get; set; }

        public string Bairro { get; set; }

        public string CEP { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        //Propriedades para mapeamento do EF
        public Guid ClienteId { get; set; }
        //Propriedade de navegação
        //Virtual por causa do lazyLoading
        public virtual Cliente Cliente { get; set; }
    }
}
