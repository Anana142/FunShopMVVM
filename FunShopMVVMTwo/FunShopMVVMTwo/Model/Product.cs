﻿using System;
using System.Collections.Generic;
using System.Text;


namespace FunShopMVVMTwo.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int IdCategory { get; set; }
        public string PathImage { get; set; }

        
    }
}
