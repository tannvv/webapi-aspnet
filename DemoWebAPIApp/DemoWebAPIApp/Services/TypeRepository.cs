using DemoWebAPIApp.Data;
using DemoWebAPIApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Type = DemoWebAPIApp.Data.Type;

namespace DemoWebAPIApp.Services
{
    public class TypeRepository : ITypeRepository
    {
        private readonly AppDbContext _context;
        public TypeRepository(AppDbContext context) {
            _context = context;
        }
        public TypeVM Add(TypeModel model)
        {
            var _type = new Type
            {
                TypeName = model.TypeName
            };
            _context.Types.Add(_type);
            _context.SaveChanges();
            return new TypeVM
            {
                TypeID = _type.ID,
                TypeName = _type.TypeName
            };
        }

        public void Delete(int id)
        {
            var _type = _context.Types.SingleOrDefault(type => type.ID == id);
            if (_type != null) {
                _context.Types.Remove(_type);
                _context.SaveChanges();
            }
        }

        public List<TypeVM> GetAll()
        {
            var types = _context.Types.Select(type => new TypeVM
            {
                TypeID = type.ID,
                TypeName = type.TypeName
            });
            return types.ToList();
        }

        public TypeVM GetById(int id)
        {
            var type = _context.Types.SingleOrDefault(type => type.ID == id);
            if (type != null)
            {
                return new TypeVM
                {
                    TypeID = type.ID,
                    TypeName = type.TypeName
                };
            }
            else {
                return null;
            }
        }

        public void Update(TypeVM model)
        {
            Type _type = _context.Types.SingleOrDefault(type => type.ID == model.TypeID);
            if (_type != null) {
                _type.TypeName = model.TypeName;
                _context.SaveChanges();
            }
        }
    }
}
