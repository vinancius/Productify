using Microsoft.EntityFrameworkCore;
using Productify.Context;
using Productify.Models;

namespace Productify.Repositories
{
    public class ProdutoRepository
    {
        private readonly ModelContext _context;

        public ProdutoRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ListProdutos(int page, int pageSize)
        {
            var produtos = await _context.Produtos.Skip((page - 1) * pageSize)
                .Take(pageSize).ToListAsync();
            return produtos ?? Enumerable.Empty<Produto>();
        }

        public async Task<Produto> ListProdutoById(int id)
        {
            return await _context.Produtos.FindAsync(id);
        }

        public async Task AdicionarProduto(Produto produto)
        {
            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarProduto(Produto produto)
        {
            _context.Entry(produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeletarProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto != null)
            {
                _context.Produtos.Remove(produto);
                await _context.SaveChangesAsync();
            }
        }
    }
}
