﻿namespace Fashion_Flex.Models
{
	public class Product
	{
		public int Id { get; set; }
		public string Product_Name { get; set; }
		public string Description { get; set; }
		public decimal Price { get; set; }
		public int Available_Quantity { get; set;}
		public string Category { get; set; }
		public string Color { get; set; }
		public int Discount { get; set; }
		public DateTime Date_Added { get; set; }

        //Relations
        public virtual List<Order_Item> OrderItems { get; set; }  // Product can be ordered multiple times in different Orders

        public virtual List<Review> Reviews { get; set; }
    }
}
