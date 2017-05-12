using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExemploEntityFramework.Models
{
    public class Venda
    {
        public int Id { get; set; }
        public virtual Usuario Usuario { get; set; }
        public int UsuarioID { get; set; }
        public virtual IList<ProdutoVenda> ProdutoVenda { get; set; }
    }
}
