using MISA.Fresher2025.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.Fresher2025.Core.Interfaces.Repositories
{
    public interface IBaseRepository<T>
    {
        List<T> GetAll();
        T GetById(string id);
        void Create(T entity);
        T Update(string id, T entity);
        void Delete(string id);
    }
}
