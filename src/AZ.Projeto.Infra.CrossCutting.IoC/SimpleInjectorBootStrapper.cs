using AZ.Projeto.Aplicacao.Interfaces;
using AZ.Projeto.Aplicacao.Servicos;
using AZ.Projeto.Dominio.Interfaces.Repositorio;
using AZ.Projeto.Dominio.Interfaces.Servico;
using AZ.Projeto.Dominio.Servicos;
using AZ.Projeto.Infra.Dados.Contexto;
using AZ.Projeto.Infra.Dados.Interfaces;
using AZ.Projeto.Infra.Dados.Repositorios;
using AZ.Projeto.Infra.Dados.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AZ.Projeto.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {
        public static void Register(Container container)
        {
            //Lifestyle.Transient => Uma instancia para cada solicitação
            //Lifestyle.Singleton => Uma instancia unica para a classe
            //Lifestyle.Scoped => Uma instancia unica para o request


            //APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);

            //Domain
            container.Register<IClienteServico, ClienteServico>(Lifestyle.Scoped);

            //DATA
            container.Register<IClienteRepositorio, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<ProjetoContext>(Lifestyle.Scoped);
        }
    }
}
