using System.Collections.Generic;

namespace ExemploEntityFramework.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
    }
}
