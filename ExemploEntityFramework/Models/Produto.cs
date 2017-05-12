using System.Collections.Generic;

namespace ExemploEntityFramework.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public virtual Categoria Categoria { get; set; }
        public int CategoriaID { get; set; }
        public virtual IList<ProdutoVenda> ProdutoVenda { get; set; }
    }
}
