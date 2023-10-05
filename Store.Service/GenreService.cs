using Store.Data.Infrastructure;
using Store.Data.Repositories;
using Store.Model;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service
{
    // operations you want to expose
    public interface IGenreService
    {
        IEnumerable<Genres> GetGenre(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Genres GetGenre(int id);
        //Publishers GetPublisher(string name);
        void SaveGenre();
        void CreateGenre(Genres genre);
        void UpdateGenre(Genres genre);
        void DeleteGenre(Genres genre);
    }

    public class GenreService : IGenreService
    {
        private readonly IGenresRepository GenreRepository;
        private readonly IUnitOfWork unitOfWork;

        public GenreService(IGenresRepository GenreRepository, IUnitOfWork unitOfWork)
        {
            this.GenreRepository = GenreRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Genres> GetGenre(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return GenreRepository.GetAll();
            else
                return GenreRepository.GetAll().Where(c => c.Name == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Genres GetGenre(int id)
        {
            var Genre = GenreRepository.GetById(id);
            return Genre;
        }

        public void CreateGenre(Genres genre)
        {
            GenreRepository.Add(genre);
        }
        public void UpdateGenre(Genres genre)
        {
            GenreRepository.Update(genre);
        }
        public void DeleteGenre(Genres genre)
        {
            GenreRepository.Delete(genre);
        }
        public void SaveGenre()
        {
            unitOfWork.Commit();
        }


    }
    #endregion

}