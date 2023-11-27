using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
namespace Order_Managment_System
{
    public class Customer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Customer_ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Навигационное свойство для связи с таблицей Order
        
        public List<Order> Orders { get; set; }
    }

    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Product_ID { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }

        // Навигационное свойство для связи с таблицей OrderItem
        
        public List<OrderItem> OrderItems { get; set; }
    }

    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_ID { get; set; }

        public int Customer_ID { get; set; } // Внешний ключ для связи с таблицей Customer

        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }
        public decimal? DeliveryCost { get; set; }

        // Навигационные свойства для связи с таблицами Customer и OrderItem
        
        public Customer Customer { get; set; }

        
        public List<OrderItem> OrderItems { get; set; }
    }

    public class OrderItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Order_Item_ID { get; set; }

        public int Order_ID { get; set; } // Внешний ключ для связи с таблицей Order
        public int Product_ID { get; set; } // Внешний ключ для связи с таблицей Product

        public int Quantity { get; set; }
        public string Description { get; set; }

        // Навигационные свойства для связи с таблицами Order и Product
        
        public Order Order { get; set; }
        
        public Product Product { get; set; }
    }


}
