using DemoWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebAPIApp.Services
{
    public interface ITypeRepository
    {
        List<TypeVM> GetAll();
        TypeVM GetById(int id);
        TypeVM Add(TypeModel model);
        void Update(TypeVM model);
        void Delete(int id);
    }
}
