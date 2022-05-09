using DemoWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Type = DemoWebAPIApp.Data.Type;

namespace DemoWebAPIApp.Services
{
    public class TypeRepositoryInMemory : ITypeRepository
    {
        public static List<Type> Types = new List<Type> { 
            new Type{ ID = 1, TypeName = "Acer"},
            new Type { ID = 2, TypeName = "HP" },
            new Type { ID = 3, TypeName = "Apple" },
            new Type { ID = 4, TypeName = "Asus" },
        };

        public TypeVM Add(TypeModel model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<TypeVM> GetAll()
        {
            return Types.Select(type => new TypeVM {
                TypeID = type.ID,
                TypeName = type.TypeName
            }).ToList();
        }

        public TypeVM GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TypeVM model)
        {
            throw new NotImplementedException();
        }
    }
}
