using System.ComponentModel.DataAnnotations;

namespace IMS_Gadget.ServerModel
{
    public class GadgetsServerModel : BaseServerModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string SecretInfo { get; set; }
    }
}
