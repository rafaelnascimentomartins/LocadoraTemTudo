using Locadora.TemTudo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Locadora.TemTudo.Api.Data
{
    // DbContext -> Orquestrador  que conecta com banco de dados, sendo assim não necessário abrir
    // conexão manual com banco.

    /// <summary>
    /// Instalar pacote EntityFrameworkCore.Tools
    /// Como iniciar uma Migration? Tools -> Nuget Package Manager -> Package Manager Console.
    /// Definição sobre Migrations;
    /// Comando de ativação da Migrations Enable-Migrations (obsoleto!)
    /// Comando de criação de Migrations, verificando as classes existentes atreladas com DbSet.
    ///     Apos executar o comando Add-Migration, sera criado uma pasta Migration no projeto e contendo o 
    ///     arquivo principal com as mudanças realizadas e arquivo Snapshot (responsável por alterar propriedades internas 
    ///     entre Entity e SqlServer ex: string -> nvcarchar.
    /// Comando de execução para criação de tabelas e etc.. update-database
    /// Caso não esteja correto, antes de executar o update-database, você pode executar o remove-migration
    /// </summary>
    public class LocadoraContext : DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteEndereco> ClientesEnderecos { get; set; }

        public LocadoraContext(DbContextOptions options) : base(options) { }

        public LocadoraContext(string connectionString) : base() { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Ele serve para definir associações extras entre modelos, chaves primárias,
            // estrangeiras, realizar algumas acções de verificação sobre contexto e etc...
            //SEEDS
            //Possível configurações de tabelas com valores pré carregados.
        }
    }
}
