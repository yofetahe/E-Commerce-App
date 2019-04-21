using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class StockDetail: BaseDataModel
    {
        [Key]
        public int StokeDetailId { get; set; }
        public int StockId { get; set; }
        public int InitialQuantity { get; set; }
        public int RemainingBalance { get; set; }
        public int ReorderBalance { get; set; }
        public string GRN_Number { get; set; }
        public int ColorId { get; set; }
        public int SizeId { get; set; }

        public Product Product { get; set; }

        public StockDetail(){}
        public StockDetail(NewStock form)
        {
            // StockId = form.StockId;
            InitialQuantity = form.InitialQuantity;
            RemainingBalance = form.InitialQuantity;
            ReorderBalance = form.ReorderBalance;
            GRN_Number = form.GRN_Number;
        }
    }
}