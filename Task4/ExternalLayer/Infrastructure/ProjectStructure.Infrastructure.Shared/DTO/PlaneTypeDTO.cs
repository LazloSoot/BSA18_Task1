﻿namespace ProjectStructure.Infrastructure.Shared.DTO
{
    public class PlaneTypeDTO
    {
        public long Id { get; set; }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public int CargoCapacity { get; set; }
    }
}