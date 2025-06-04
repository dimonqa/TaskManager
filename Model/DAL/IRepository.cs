using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Model.Domain;

namespace Model.DAL
{
    public interface IRepository<T> where T : IDomainObject, new()
    {
        IEnumerable<T> GetAll();

        void Add(T entity);
        void Update (T entity);
        void Delete(T entity);
        void Save();
    }
}
