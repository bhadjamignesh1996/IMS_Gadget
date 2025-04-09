using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IMS_Gadget.DalLayer.DbContexts;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.DalLayer.Repositories.CommonRepositories
{
    public class CommonCRUDIMSGadget<AB> where AB : class
    {


        public async Task<AB> Insert(IMSGadgetDB IMSGContext, AB entity)
        {
            try
            {
                IMSGContext.Set<AB>().Add(entity);

                await Task.FromResult(IMSGContext.SaveChanges());

                return entity;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task InsertMultiple(IMSGadgetDB IMSGContext, IList<AB> entity)
        {
            try
            {
                IMSGContext.Set<AB>().AddRange(entity);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task Update(IMSGadgetDB IMSGContext, AB entity)
        {
            try
            {
                IMSGContext.Set<AB>().Update(entity);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }
        public async Task UpdateMultiple(IMSGadgetDB IMSGContext, IList<AB> entity)
        {
            try
            {
                IMSGContext.Set<AB>().UpdateRange(entity);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public async Task Delete(IMSGadgetDB IMSGContext, AB entity)
        {
            try
            {
                IMSGContext.Set<AB>().Remove(entity);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }


        public async Task DeleteAnyWithExpression(IMSGadgetDB IMSGContext, Expression<Func<AB, bool>> expression)
        {
            try
            {
                var vData = IMSGContext.Set<AB>().Where(expression).AsNoTracking();
                IMSGContext.Set<AB>().RemoveRange(vData);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public async Task DeleteData(IMSGadgetDB IMSGContext, List<AB> Data)
        {
            try
            {
                IMSGContext.Set<AB>().RemoveRange(Data);
                await Task.FromResult(IMSGContext.SaveChanges());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        public IQueryable Find(IMSGadgetDB IMSGContext, Expression<Func<AB, bool>> expression)
        {
            return IMSGContext.Set<AB>().Where(expression).AsNoTracking();
        }

        public async Task<IEnumerable<AB>> GetAll(IMSGadgetDB IMSGContext, int RecordLimit = 0)
        {
            try
            {
                IQueryable<AB> vList;
                if (RecordLimit > 0)
                {
                    vList = IMSGContext.Set<AB>().Take(RecordLimit).AsNoTracking();
                }
                else
                {
                    vList = IMSGContext.Set<AB>().AsNoTracking();
                }
                if (vList == null || vList.Count() == 0)
                    throw new SystemExceptions(Message.DataNotFound, StatusCodes.Status204NoContent);

                return await Task.FromResult(vList.ToList());
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

    }
}
