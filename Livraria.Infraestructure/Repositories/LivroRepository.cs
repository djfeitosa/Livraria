using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Livraria.Domain.Abstractions;
using Livraria.Domain.Entities;
using Livraria.Infraestructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Infraestructure.Repositories
{
    public class LivroRepository(ApplicationDbContext context) : ILivroRepository
    {
        private readonly ApplicationDbContext _context = context;

        public async Task<Livro> AdicionarLivro(Livro livro)
        {
            if (_context is not null && _context.Livros is not null && livro is not null)
            {
                _context.Livros.Add(livro);
                await _context.SaveChangesAsync();
                return livro;
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos.");
            }
        }

        public async Task AtualizarLivro(Livro livro)
        {
            if (livro is not null)
            {
                _context.Entry(livro).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new ArgumentNullException("Dados inválidos");
            }
        }

        public async Task DeletarLivro(int id)
        {
            var livro = await ObterLivro(id);
            if (livro is not null && _context.Livros is not null)
            {
                _context.Livros.Remove(livro);
                await _context.SaveChangesAsync();
            }
            else
            {
                throw new InvalidOperationException("Dados inválidos");
            }
        }

        public async Task<Livro?> ObterLivro(int id)
        {
            var livro = await _context.Livros.FindAsync(id);

            if (livro is not null)
            {
                throw new InvalidOperationException($"Livro com ID {id} não encontrato.");
            }
            return livro;
        }

        public async Task<IEnumerable<Livro>> ObterLivros()
        {
            if (_context is not null && _context.Livros is not null)
            {
                var livros = await _context.Livros.ToListAsync();
                return livros;
            }
            else
            {
                return new List<Livro>();
            }
        }
    }
}