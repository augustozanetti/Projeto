namespace AZ.Projeto.Infra.Dados.Migrations
{
    using System.Data.Entity.Migrations;
    
    internal sealed class Configuration : DbMigrationsConfiguration<Contexto.ProjetoContext>
    {
        public Configuration()
        {
            //AutomaticMigrationsEnabled = false;
            //TRUE = permite atualizar o banco pelo migrations
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Contexto.ProjetoContext context)
        {
            
        }
    }
}
