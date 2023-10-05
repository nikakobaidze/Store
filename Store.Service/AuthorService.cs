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
    public interface IAuthorService
    {
        IEnumerable<Authors> GetAuthor(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Authors GetAuthor(int id);
        //Publishers GetPublisher(string name);
        void SaveAuthor();
        void CreateAuthor(Authors author);
        void UpdateAuthor(Authors author);
        void DeleteAuthor(Authors author);
    }

    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository AuthorRepository;
        private readonly IUnitOfWork unitOfWork;

        public AuthorService(IAuthorRepository AuthorRepository, IUnitOfWork unitOfWork)
        {
            this.AuthorRepository = AuthorRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Authors> GetAuthor(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return AuthorRepository.GetAll();
            else
                return AuthorRepository.GetAll().Where(c => c.FirstName == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Authors GetAuthor(int id)
        {
            var Author = AuthorRepository.GetById(id);
            return Author;
        }

        public void CreateAuthor(Authors Author)
        {
            AuthorRepository.Add(Author);
        }
        public void UpdateAuthor(Authors Author)
        {
            AuthorRepository.Update(Author);
        }
        public void DeleteAuthor(Authors Author)
        {
            AuthorRepository.Delete(Author);
        }
        public void SaveAuthor()
        {
            unitOfWork.Commit();
        }


    }
    #endregion

}