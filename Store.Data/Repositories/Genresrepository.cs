using Store.Data.Infrastructure;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Repositories
{
    public class GenresRepository : RepositoryBase<Genres>, IGenresRepository
    {
        public GenresRepository(IDbFactory dbFactory)
            : base(dbFactory) { }
        public Genres GetGenreByName(string GenreName)
        {
            var Genre=this.DbContext.Genres.Where(x => x.Name == GenreName).FirstOrDefault();
            return Genre;
        }
    }

    public interface IGenresRepository : IRepository<Genres>
    {
        Genres GetGenreByName(string GenreName);

    }
}
