﻿namespace Server.UnitTest
{
    public class ProductRepository : IProductRepository
    {
        public string GetName()
        {
            return "Product";
        }
    }
    public class Product2Repository : IProductRepository
    {
        public string GetName()
        {
            return "Product2";
        }
    }
}