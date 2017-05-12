using ExemploEntityFramework.DAL;
using ExemploEntityFramework.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ExemploEntityFramework.Controllers
{
    public class ProdutoController
    {
        private ModelsContext contexto;

        public ProdutoController(ModelsContext contexto)
        {
            this.contexto = contexto;
        }

        public void Salvar(Produto produto)
        {
            contexto.Produtos.Add(produto);
            contexto.SaveChanges();
        }

        public Produto BuscaPorId(int id)
        {
            return contexto.Produtos.Find(id);
        }

        public void Remover(int id)
        {
            var produto = contexto.Produtos.First(u => u.Id.Equals(id));
            contexto.Produtos.Remove(produto);
            contexto.SaveChanges();
        }

        public void Atualizar(int id)
        {
            var produto = contexto.Produtos.Find(id);
            contexto.Entry(produto).State = EntityState.Modified;
            contexto.SaveChanges();
        }

        public IList<Produto> BuscaPorNomePrecoCategoria(string nome, decimal preco, string nomeCategoria)
        {
            var produtos = from p in contexto.Produtos select p;

            if (!String.IsNullOrEmpty(nome))
            {
                produtos = from p in produtos
                           where p.Nome.Equals(nome)
                           select p;
            }

            if (preco > 0.0m)
            {
                produtos = from p in produtos
                           where p.Preco.Equals(preco)
                           select p;
            }

            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                produtos = from p in produtos
                           where p.Categoria.Nome.Equals(nomeCategoria)
                           select p;
            }
            return produtos.ToList();
        }
    }
}