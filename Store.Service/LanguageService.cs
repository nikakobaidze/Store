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
    public interface ILanguageService
    {
        IEnumerable<Languages> GetLanguage(string name = null);
        Languages GetLanguage(int id);
        void SaveLanguage();
        void CreateLanguage(Languages language);
        void UpdateLanguage(Languages language);
        void DeleteLanguage(Languages language);
    }

    public class LanguageService : ILanguageService
    {
        private readonly ILanguagesRepository LanguagesRepository;
        private readonly IUnitOfWork unitOfWork;

        public LanguageService(ILanguagesRepository LanguagesRepository, IUnitOfWork unitOfWork)
        {
            this.LanguagesRepository = LanguagesRepository;
            this.unitOfWork = unitOfWork;
        }


        public IEnumerable<Languages> GetLanguage(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return LanguagesRepository.GetAll();
            else
                return LanguagesRepository.GetAll().Where(c => c.Language == name);
        }
        //public IEnumerable<Users> GetUserName(string name)
        //{
        //    var User = UsersRepository.GetUserByUserName(name);

        //    return User;
        //}

        public Languages GetLanguage(int id)
        {
            var language = LanguagesRepository.GetById(id);
            return language;
        }

        public void CreateLanguage(Languages language)
        {
            LanguagesRepository.Add(language);
        }
        public void UpdateLanguage(Languages language)
        {
            LanguagesRepository.Update(language);
        }
        public void DeleteLanguage(Languages language)
        {
            LanguagesRepository.Delete(language);
        }
        public void SaveLanguage()
        {
            unitOfWork.Commit();
        }



    }
}