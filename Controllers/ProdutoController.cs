using System.Collections.Generic;
using System.Threading.Tasks;
using Estocando.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Estocando.Controllers
{
    [ApiController]
    public class ProdutoController : Controller
    {
        private readonly IProdutoRepository _produtoRepository;
       
        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("produto/inserir")] 
        public void Inserir(Produto produto)
        {
            _produtoRepository.Inserir(produto);
        }

        [HttpGet("produto/consultartodos")]
        public Task<IEnumerable<Produto>> ConsultarTodos()
        {
            return _produtoRepository.ConsultarTodos();
        }

        [HttpGet("produto/consultarUnidade/{id}")]
        public Task<Produto> ConsultarUnidade(int id)
        {
            return _produtoRepository.ConsultarUnidade(id);
        }

        [HttpPut("produto/alterar")]
        public void Alterar(Produto produto)
        {
            _produtoRepository.Alterar(produto);
        }

        [HttpDelete("produto/deletar")]
        public void Deletar(Produto produto)
        {
            _produtoRepository.Deletar(produto);
        }
    }
}