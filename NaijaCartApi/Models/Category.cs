using System.ComponentModel.DataAnnotations;

namespace NaijaCartApi.Models
{
    public class Category
    {
        public Category()
        {
            // Take the first, middle, and last characters of the name
            char first = Name[0];
            char middle = Name[Name.Length / 2];
            char last = Name[Name.Length - 1];

            // Assign the Id property with the concatenated characters
            Id = first.ToString() + middle.ToString() + last.ToString();
            Id.ToUpper();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set;  }
    }
}
