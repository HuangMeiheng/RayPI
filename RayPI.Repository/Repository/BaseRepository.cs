﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
//
using SqlSugar;
using RayPI.Model.ReturnModel;
using RayPI.Entity;
using RayPI.IRepository;
using RayPI.Treasury.Enums;
using RayPI.Treasury.Models;
using System.Linq;

namespace RayPI.SqlSugarRepository.Repository
{
    /// <summary>
    /// 服务层基类
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : EntityBase, new()
    {
        protected readonly MySqlSugarClient _sugarClient;

        public BaseRepository(MySqlSugarClient sugarClient)
        {
            _sugarClient = sugarClient;
        }

        #region CRUD
        public TableModel<T> GetPageList(int pageIndex, int pageSize)
        {
            PageModel p = new PageModel() { PageIndex = pageIndex, PageSize = pageSize };
            Expression<Func<T, bool>> ex = (it => 1 == 1);
            List<T> data = _sugarClient.SimpleClient.GetPageList(ex, p);
            var t = new TableModel<T>
            {
                Code = 0,
                Count = p.PageCount,
                Data = data,
                Msg = "成功"
            };
            return t;
        }

        public T Get(long id)
        {
            return _sugarClient.SimpleClient.GetById<T>(id);
        }

        public bool Add(T entity)
        {
            return _sugarClient.SimpleClient.Insert(entity);
        }

        public bool Update(T entity)
        {
            return _sugarClient.SimpleClient.Update(entity);
        }

        public bool Dels(dynamic[] ids)
        {
            return _sugarClient.SimpleClient.DeleteByIds<T>(ids);
        }
        #endregion


        public IQueryable<T> GetAllMatching(Expression<Func<T, bool>> filter = null, bool exceptDeleted = true)
        {
            ISugarQueryable<T> re = _sugarClient.Client.Queryable<T>();
            if (filter != null)
                re = re.Where(filter);
            if (exceptDeleted)
                re = re.Where(x => x.IsDeleted == false);
            return (IQueryable<T>)re;
        }

        public PageResult<T> GetPageList<TK>(int pageIndex, int pageSize, bool exceptDeleted, Expression<Func<T, bool>> filterExpression, Expression<Func<T, TK>> orderByExpression, SortEnum sortOrder)
        {
            throw new NotImplementedException();
        }

        public bool Any(Expression<Func<T, bool>> filter, bool exceptDeleted)
        {
            throw new NotImplementedException();
        }

        public T Find(Expression<Func<T, bool>> filter, bool exceptDeleted)
        {
            throw new NotImplementedException();
        }

        public T FindById(long id, bool exceptDeleted)
        {
            throw new NotImplementedException();
        }

        long IBaseRepository<T>.Add(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<long> Add(IEnumerable<T> entityList)
        {
            throw new NotImplementedException();
        }

        void IBaseRepository<T>.Update(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(IQueryable<T> entityList)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Remove(IQueryable<T> entityList)
        {
            throw new NotImplementedException();
        }

        public void Remove(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Remove(long id)
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(IQueryable<T> entityList)
        {
            throw new NotImplementedException();
        }

        public void Delete(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}
