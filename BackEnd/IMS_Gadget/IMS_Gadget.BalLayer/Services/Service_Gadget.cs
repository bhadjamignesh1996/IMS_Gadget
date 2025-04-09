using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS_Gadget.BalLayer.Interfaces;
using IMS_Gadget.BalLayer.ViewModel;
using IMS_Gadget.DalLayer.DbContexts;
using IMS_Gadget.ServerModel;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Http;
using static IMS_Gadget.DalLayer.Repositories.Repository_IMSGadget;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.BalLayer.Services
{
    public class Service_Gadget : IGadget
    {
        private IMSGadgetDB iMSGadgetDB;
        private readonly Repository_Gadgets repository_Gadgets;
        private readonly Service_Common serviceCommon;

        public Service_Gadget(IMSGadgetDB _iMSGadgetDB, Repository_Gadgets _repository_Gadgets, Service_Common _serviceCommon)
        {
            iMSGadgetDB = _iMSGadgetDB;
            repository_Gadgets = _repository_Gadgets;
            serviceCommon = _serviceCommon;
        }

        public async Task<List<GadgetsServerModel>> GetGadgets()
        {
            try
            {
                var result = repository_Gadgets.Find(iMSGadgetDB, x => x.Id > 0)
                    .Cast<GadgetsServerModel>().ToList();

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GadgetsServerModel> GetGadgetById(int id)
        {
            try
            {
                var result = repository_Gadgets.Find(iMSGadgetDB, x => x.Id == id)
                    .Cast<GadgetsServerModel>().FirstOrDefault();

                return await Task.FromResult(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpsertGadget(GadgetsViewModel gadgetsViewModel)
        {
            try
            {
                iMSGadgetDB.BeginTransaction();

                GadgetsServerModel gadgetsSM = repository_Gadgets.Find(iMSGadgetDB, x => x.Name == gadgetsViewModel.Name && x.Id != gadgetsViewModel.Id)
                    .Cast<GadgetsServerModel>().FirstOrDefault();

                if (gadgetsSM != null)
                {
                    throw new SystemExceptions(Message.DuplicateNotAllowed, StatusCodes.Status409Conflict);
                }

                if (gadgetsViewModel.Id > 0)
                {
                    gadgetsSM = repository_Gadgets.Find(iMSGadgetDB, x => x.Id == gadgetsViewModel.Id)
                    .Cast<GadgetsServerModel>().FirstOrDefault();
                    gadgetsSM.Name = gadgetsViewModel.Name;
                    gadgetsSM.Category = gadgetsViewModel.Category;
                    gadgetsSM.Brand = gadgetsViewModel.Brand;
                    gadgetsSM.Description = gadgetsViewModel.Description;
                    gadgetsSM.Price = gadgetsViewModel.Price;
                    gadgetsSM.Quantity = gadgetsViewModel.Quantity;
                    gadgetsSM.SecretInfo = gadgetsViewModel.SecretInfo;
                    gadgetsSM.UpdatedAt = DateTime.Now;
                    repository_Gadgets.Update(iMSGadgetDB, gadgetsSM);
                }
                else
                {
                    gadgetsSM = new GadgetsServerModel
                    {
                        Name = gadgetsViewModel.Name,
                        Category = gadgetsViewModel.Category,
                        Brand = gadgetsViewModel.Brand,
                        Description = gadgetsViewModel.Description,
                        Price = gadgetsViewModel.Price,
                        Quantity = gadgetsViewModel.Quantity,
                        SecretInfo = gadgetsViewModel.SecretInfo
                    };
                    repository_Gadgets.Insert(iMSGadgetDB, gadgetsSM);
                }



                iMSGadgetDB.CommitTransaction();


                return await Task.FromResult(Message.SavedSuccessfully);

            }
            catch (Exception)
            {
                iMSGadgetDB.RollBackTransaction();

                throw;
            }
        }

        public async Task<string> DeleteGadget(string ids)
        {
            try
            {
                iMSGadgetDB.BeginTransaction();

                var GadgetIds = ids.Split(',').Select(int.Parse).ToList();
                List<GadgetsServerModel> gadgets = repository_Gadgets.Find(iMSGadgetDB, x => GadgetIds.Contains(x.Id))
                 .Cast<GadgetsServerModel>().ToList();
                if (gadgets.Any())
                {
                    await repository_Gadgets.DeleteData(iMSGadgetDB, gadgets);
                }
                iMSGadgetDB.CommitTransaction();

                return await Task.FromResult(Message.DeletedSuccessfully);
            }
            catch (Exception)
            {
                iMSGadgetDB.RollBackTransaction();

                throw;
            }
        }

    }
}
