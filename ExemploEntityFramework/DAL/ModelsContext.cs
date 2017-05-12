using ExemploEntityFramework.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ExemploEntityFramework.DAL
{
    public class ModelsContext : DbContext
    {
        public ModelsContext() : base("connDbEntityFramework")
        {
           
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<ProdutoVenda> ProdutoVenda { get; set; }
        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Entity<ProdutoVenda>().HasKey(pv => new { pv.VendaID, pv.ProdutoID });
            base.OnModelCreating(modelBuilder);
        }
    }
}
