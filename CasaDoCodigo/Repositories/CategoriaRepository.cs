using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICategoriaRepository
    {
        Task SaveCategoria(string nome);
        Categoria GetCategoria(string nome);
        List<Categoria> GetCategorias();
    }

    public class CategoriaRepository : BaseRepository<Categoria>, ICategoriaRepository
    {
        public CategoriaRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Categoria GetCategoria(string nome)
        {
            return dbSet.Where(c => c.Nome == nome)
                .SingleOrDefault(); 
        }
        public List<Categoria> GetCategorias()
        {
            return dbSet.ToList();
        }

        public async Task SaveCategoria(string nome)
        {
            var categoriaDB = dbSet.Where(c => c.Nome == nome)
                .SingleOrDefault();

            if (categoriaDB == null)
            {
                dbSet.Add(new Categoria(nome));
            }
            await contexto.SaveChangesAsync();
        }
    }
}
