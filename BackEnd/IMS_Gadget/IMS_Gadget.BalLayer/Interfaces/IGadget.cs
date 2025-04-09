using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IMS_Gadget.BalLayer.ViewModel;
using IMS_Gadget.ServerModel;

namespace IMS_Gadget.BalLayer.Interfaces
{
    public interface IGadget
    {
        Task<List<GadgetsServerModel>> GetGadgets();

        Task<GadgetsServerModel> GetGadgetById(int id);

        Task<string> UpsertGadget(GadgetsViewModel gadgetsViewModel);

        Task<string> DeleteGadget(string ids);
    }
}
