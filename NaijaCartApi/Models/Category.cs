﻿using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        public required string Name { get; set; }

        public virtual ICollection<Product> Products { get; set;  }
    }
}