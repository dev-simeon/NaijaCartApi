﻿namespace NaijaCartApi.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Product Product { get; set; }
    }
}