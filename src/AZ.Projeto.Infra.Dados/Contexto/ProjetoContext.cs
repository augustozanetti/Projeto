using AZ.Projeto.Dominio.Model;
using AZ.Projeto.Infra.Dados.EntityConfig;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AZ.Projeto.Infra.Dados.Contexto
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a pluralização dos nomes das tabelas
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //Remove a deleção em cascata para 1-n
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Remove a deleção em cascata para n-n
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //Tudo que for string(nvarchar) passará a ser varchar
            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            //Tamanho maximo do varchar será 100
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ClienteConfig());//Adicionando a configuração para gerar o banco corretamente
            modelBuilder.Configurations.Add(new EnderecoConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}
