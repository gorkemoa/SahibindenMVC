using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Sahibinden.Data.Models;
using System.Linq.Expressions;

namespace Sahibinden.Repository
{
   
    public class GenericRepository<T> where T:class,new()
	{
        private readonly Context _context = new Context();

        

        public List<T> TList()
        {
            return _context.Set<T>().ToList();
        }

        public void TAdd(T ct)
        {
            _context.Set<T>().Add(ct);
            _context.SaveChanges();
        }

        public void TDelete(T ct)
        {
            _context.Set<T>().Remove(ct);
            _context.SaveChanges();

        }

        public void TUpdate(T ct)
        {
            _context.Set<T>().Update(ct);
            _context.SaveChanges();

        }
        public T GetT(int id)
        {
            return _context.Set<T>().Find(id);
            _context.SaveChanges();

        }
        public List<T> Tlist(string p)
        {
            return _context.Set<T>().Include(p).ToList();
        }

        public List<T> List(Expression<Func<T,bool>>filter)
        {
            return _context.Set<T>().Where(filter).ToList();
        }

    }
}

