using System.Collections.Generic;
using System.Threading.Tasks;
using Estocando.Models;
using Microsoft.EntityFrameworkCore;

namespace Estocando.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly EstocandoContexto _contexto;

        public ProdutoRepository(EstocandoContexto contexto)
        {
            _contexto = contexto;
        }

        public void Alterar(Produto produto)
        {
            _contexto.Produtos.Update(produto);
            _contexto.SaveChanges();
        }

        public async Task<IEnumerable<Produto>> ConsultarTodos()
        {
          return await _contexto.Produtos.AsNoTracking().ToListAsync();
        }

        public async Task<Produto> ConsultarUnidade(int id)
        {
            return await _contexto.Produtos.FindAsync(id);
        }

        public void Deletar(Produto produto)
        {
            _contexto.Produtos.Remove(produto);
            _contexto.SaveChanges();
        }

        public void Inserir(Produto produto)
        {
            _contexto.Produtos.Add(produto);
            _contexto.SaveChanges();
        }
    }
}