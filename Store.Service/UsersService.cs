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
    public interface IUsersService
    {
        IEnumerable<Users> GetUsers(string name = null);
        //IEnumerable<Users> GetUserName(string name );
        Users GetUser(int id);
        Users GetUser(string name);
        Users GetUserByEmail(string email);
        //Users GetUserByUsername(string username);
        //Users GetUserByPassword(string password);
        void CreateUser(Users category);
        void SaveUser();
        void SaveConfirmationToken(int userId, string token);
        bool VerifyConfirmationToken(int userId, string token);
        void UpdateUser(Users user);
    }

    public class UsersService : IUsersService
    {
        private readonly IUsersRepository UsersRepository;
        private readonly IUnitOfWork unitOfWork;

        public UsersService(IUsersRepository UsersRepository, IUnitOfWork unitOfWork)
        {
            this.UsersRepository = UsersRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Users> GetUsers(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return UsersRepository.GetAll();
            else
                return UsersRepository.GetAll().Where(c => c.UserName == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Users GetUser(int id)
        {
            var User = UsersRepository.GetById(id);
            return User;
        }

        public Users GetUser(string name)
        {
            var User = UsersRepository.GetUserByUserName(name);
            return User;
        }

        public void CreateUser(Users User)
        {
            UsersRepository.Add(User);
        }
        public void UpdateUser(Users user)
        {
            UsersRepository.Update(user);
        }

        public void SaveUser()
        {
            unitOfWork.Commit();
        }

        public Users GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        //public Users GetUserByUsername(string username)
        //{
        //    throw new NotImplementedException();
        //}

        //public Users GetUserByPassword(string password)
        //{
        //    throw new NotImplementedException();
        //}

        public void SaveConfirmationToken(int userId, string token)
        {
            var user = UsersRepository.GetById(userId);
            if (user != null)
            {
                user.ConfirmationToken = token;
                UsersRepository.Update(user);
            }
        }

        public bool VerifyConfirmationToken(int userId, string token)
        {
            var user = UsersRepository.GetUserByConfirmationToken(token);
            return user != null && user.ConfirmationToken == token;
        }
    }
    #endregion

}