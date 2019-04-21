using System;

namespace E_Commerce.Models
{
    public abstract class BaseDataModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }
}