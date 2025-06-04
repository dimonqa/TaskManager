using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Model.Domain;

namespace Model.DAL
{
    public class EFRepository<T> : IRepository<T>
                where T : class, IDomainObject, new()
    {
        private Context _context = new Context();
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);  
            // Пишем сразу в базу
            Save(); 
        }

        public void Delete(T entity)
        {
            foreach (var item in _context.Set<T>())
            {
                if (item.Id == entity.Id)
                {
                    _context.Remove(item);
                    break;                   
                }
            }
            Save();
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>();
        }

        public void Save()
        {            
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            foreach (var item in _context.Set<T>())
            {
                if (item.Id == entity.Id)
                {
                   if(entity is MyTask redTask && item is MyTask dbTask)
                   {
                        dbTask.Title = redTask.Title;
                        dbTask.Description = redTask.Description;
                        dbTask.Executers = redTask.Executers;                       
                        dbTask.PlanCost = redTask.PlanCost;

                        dbTask.State = redTask.State;
                        // DateReg не будет изменятся
                   }                                      
                    break;
                }
            }
            Save();
        }
    }

}
