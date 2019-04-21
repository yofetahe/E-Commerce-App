using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Models
{
    public class Stock: BaseDataModel
    {
        [Key]
        public int StokeId { get; set; }
        public int ProductId { get; set; }
        public int InitialQuantity { get; set; }
        public int RemainingBalance { get; set; }
        public int ReorderBalance { get; set; }
        public string GRN_Number { get; set; }
        public double UnitePrice { get; set; }
        // public int ColorId { get; set; }
        // public int SizeId { get; set; }

        public Product Product { get; set; }

        public Stock(){}
        public Stock(NewStock form)
        {
            ProductId = form.ProductId;
            UnitePrice = form.UnitePrice;
            InitialQuantity = form.InitialQuantity;
            RemainingBalance = form.InitialQuantity;
            ReorderBalance = form.ReorderBalance;
            GRN_Number = form.GRN_Number;
        }
    }
}