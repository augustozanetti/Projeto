using AZ.Projeto.Dominio.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace AZ.Projeto.Infra.Dados.EntityConfig
{
    //Configuração FLUENT API para as classes POCO(CLASSES DE DOMINIO)
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c => c.Id);
            //HasKey(c => new { c.Id, c.CPF }); CHAVE COMPOSTA

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new IndexAttribute("IX_CPF") { IsUnique = true} )); //CRIAÇÃO DO INDEX

            Property(c => c.Email)
                .IsRequired();

            Property(c => c.DataNascimento)
                .IsRequired();

            Property(c => c.Ativo)
                .IsRequired();

            Property(c => c.Excluido)
                .IsRequired();

            Ignore(c => c.ValidationResult);

            ToTable("Clientes");

            //ToTable("Clientes", "Sistema"); Schema
        }
    }
}
