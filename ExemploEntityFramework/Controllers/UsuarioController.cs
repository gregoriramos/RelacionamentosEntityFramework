using ExemploEntityFramework.DAL;
using ExemploEntityFramework.Models;
using System.Data.Entity;
using System.Linq;

namespace ExemploEntityFramework.Controllers
{
    public class UsuarioController
    {
        private ModelsContext contexto;

        public UsuarioController(ModelsContext contexto)
        {
            this.contexto = contexto;
        }

        public void Salvar(Usuario usuario)
        {
            contexto.Usuarios.Add(usuario);
            contexto.SaveChanges();
        }

        public Usuario BuscaPorId(int id)
        {
            return contexto.Usuarios.Find(id);
        }

        public void Remover(int id)
        {
            var usuario = contexto.Usuarios.First(u => u.Id.Equals(id));
            contexto.Usuarios.Remove(usuario);
            contexto.SaveChanges();
        }

        public void Atualizar(int id)
        {
            var usuario = contexto.Usuarios.Find(id);
            contexto.Entry(usuario).State = EntityState.Modified;
            contexto.SaveChanges();
        }
    }
}
