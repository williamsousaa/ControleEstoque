using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estocando.Models
{
    public interface IProdutoRepository
    {
        void Inserir(Produto produto);
        void Alterar(Produto produto);
        Task<IEnumerable<Produto>> ConsultarTodos();
        Task<Produto> ConsultarUnidade(int id);
        void Deletar(Produto produto);
    }
}