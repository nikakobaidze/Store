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
    public interface IBookService
    {
        IEnumerable<Books> GetBook(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Books GetBook(int id);
        //Publishers GetPublisher(string name);
        void SaveBook();
        void CreateBook(Books book);
        void UpdateBook(Books book);
        void DeleteBook(Books book);
    }

    public class BookService : IBookService
    {
        private readonly IBooksRepository BookRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IBookAuthorsRepository _bookAuthorsRepository;

        public BookService(IBooksRepository BookRepository, IUnitOfWork unitOfWork, IBookAuthorsRepository bookAuthorsRepository)
        {
            this.BookRepository = BookRepository;
            this.unitOfWork = unitOfWork;
            _bookAuthorsRepository = bookAuthorsRepository;
        }

        #region ICategoryService Members

        public IEnumerable<Books> GetBook(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return BookRepository.GetAll();
            else
                return BookRepository.GetAll().Where(c => c.Title == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Books GetBook(int id)
        {
            var Author = BookRepository.GetById(id);
            return Author;
        }

        public void CreateBook(Books Book)
        {
            var authors = Book.BookAuthors;
            
            foreach (var item in authors)
            {
                _bookAuthorsRepository.Add(item);
            }
            
            BookRepository.Add(Book);
            unitOfWork.Commit();
        }
        public void UpdateBook(Books Book)
        {
            BookRepository.Update(Book);
        }
        public void DeleteBook(Books Book)
        {
            BookRepository.Delete(Book);
        }
        public void SaveBook()
        {
            unitOfWork.Commit();
        }


    }
    #endregion

}