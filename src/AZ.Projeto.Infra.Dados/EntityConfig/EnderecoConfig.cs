using AZ.Projeto.Dominio.Model;
using System.Data.Entity.ModelConfiguration;


namespace AZ.Projeto.Infra.Dados.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(20);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();

            Property(e => e.Complemento)
                .HasMaxLength(100);

            HasRequired(e => e.Cliente)//Relacionamento requerido, para existir endereço precisa existir um cliente
                .WithMany(c => c.Enderecos)// N endereços
                .HasForeignKey(e => e.ClienteId); // chave estrangeira

            ToTable("Enderecos");

            //HasOptional(e => e.Cliente)//Relacionamento Opcional
            //    .WithMany(c => c.Enderecos) //WithOptional
            //    .HasForeignKey(e => e.ClienteId); // chave estrangeira

            //ONE TO ONE OR ZERO
            //ONE TO ONE
            //ONE TO MANY
            //MANY TO MANY
        }
    }
}
