using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS_Gadget.DalLayer.Repositories.CommonRepositories;
using IMS_Gadget.ServerModel;

namespace IMS_Gadget.DalLayer.Repositories
{
    public class Repository_IMSGadget
    {
        public class Repository_Gadgets : CommonCRUDIMSGadget<GadgetsServerModel>
        {
        }

        public class Repository_Users : CommonCRUDIMSGadget<UsersServerModel>
        {
        }
    }
}
