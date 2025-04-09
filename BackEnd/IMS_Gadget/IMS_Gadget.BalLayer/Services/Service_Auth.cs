using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using IMS_Gadget.BalLayer.Interfaces;
using IMS_Gadget.DalLayer.DbContexts;
using IMS_Gadget.ServerModel;
using IMS_Gadget.Utility;
using Microsoft.AspNetCore.Http;
using static IMS_Gadget.BalLayer.ViewModel.AuthenticationViewModel;
using static IMS_Gadget.DalLayer.Repositories.Repository_IMSGadget;
using static IMS_Gadget.Utility.CommonEnum;

namespace IMS_Gadget.BalLayer.Services
{
    public class Service_Auth : IAuthentication
    {
        private IMSGadgetDB iMSGadgetDB;
        private readonly Repository_Users repository_Users;
        private readonly Service_Common serviceCommon;

        public Service_Auth(IMSGadgetDB _iMSGadgetDB, Repository_Users _repository_Users, Service_Common _serviceCommon)
        {
            iMSGadgetDB = _iMSGadgetDB;
            repository_Users = _repository_Users;
            serviceCommon = _serviceCommon;
        }

        public async Task<AuthenticationResponseViewModel> SignIn(AuthenticationRequestViewModel ARVM)
        {

            AuthenticationResponseViewModel authenticationResponseViewModel = new AuthenticationResponseViewModel();
            UsersServerModel usersServerModel = new UsersServerModel();
            try
            {
                Expression<Func<UsersServerModel, bool>> expression = x => x.Email == ARVM.UserName.Trim() && x.IsActive;

                usersServerModel = repository_Users.Find(iMSGadgetDB, expression)
                                                                  .Cast<UsersServerModel>().FirstOrDefault();

                if (usersServerModel == null)
                {
                    throw new SystemExceptions(Message.EnterValidUser, StatusCodes.Status203NonAuthoritative);
                }

                if (!usersServerModel.IsActive)
                {
                    throw new SystemExceptions(Message.UserNotActive, StatusCodes.Status203NonAuthoritative);
                }

                if (serviceCommon.Decrypt(usersServerModel.PasswordHash).Result != ARVM.Password)
                {
                    throw new SystemExceptions(Message.EnterValidPassword, StatusCodes.Status203NonAuthoritative);
                }

                authenticationResponseViewModel.UserId = usersServerModel.Id;
                authenticationResponseViewModel.Email = usersServerModel.Email;
                authenticationResponseViewModel.UserName = usersServerModel.Username;
                authenticationResponseViewModel.Token = AuthToken.AuthToken.GenerateJSONWebToken(authenticationResponseViewModel);
            }
            catch
            {
                throw;
            }
            return await Task.FromResult(authenticationResponseViewModel);
        }
    }
}
