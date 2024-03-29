﻿using CarWash.Core.Entity;

namespace CarWash.Entity.Entities
{
    public class Vehicle : EntityBase
    {
        public int BrandId { get; set; }
        public int CustomerId { get; set; }
        public int Model { get; set; }
        public string PlateNumber { get; set; }
        public DateTime LastWashDate { get; set; }
        public Customer Customer { get; set; }
        public Brand Brand { get; set; }
    }
}
