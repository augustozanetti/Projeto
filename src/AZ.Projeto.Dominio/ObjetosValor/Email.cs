using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AZ.Projeto.Dominio.ObjetosValor
{
    public class Email
    {
        public string Endereco { get; set; }

        public static bool Validar(string email)
        {
            return Regex.IsMatch(email, @"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*");
        }
    }
}
