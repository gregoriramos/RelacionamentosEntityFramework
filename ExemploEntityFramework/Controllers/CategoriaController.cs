using ExemploEntityFramework.DAL;
using ExemploEntityFramework.Models;
using System.Data.Entity;
using System.Linq;

namespace ExemploEntityFramework.Controllers
{
    public class CategoriaController
    {
        private ModelsContext contexto;

        public CategoriaController(ModelsContext contexto)
        {
            this.contexto = contexto;
        }

        public void Salvar(Categoria categoria)
        {
            contexto.Categorias.Add(categoria);
            contexto.SaveChanges();
        }

        public Categoria BuscaPorId(int id)
        {
            return contexto.Categorias.Find(id);
        }

        public void Remover(int id)
        {
            var categoria = contexto.Categorias.First(u => u.Id.Equals(id));
            contexto.Categorias.Remove(categoria);
            contexto.SaveChanges();
        }

        public void Atualizar(int id)
        {
            var categoria = contexto.Categorias.Find(id);
            contexto.Entry(categoria).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
