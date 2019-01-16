using System;
using System.Collections.Generic;

namespace unitronicsWebApi.Model
{
    public partial class Parking
    {
        public int Id { get; set; }
        public DateTime CheckInTime { get; set; }
        public string Name { get; set; }
        public int? CurrentLot { get; set; }
        public string TicketType { get; set; }
        public string Vehicletype { get; set; }
        public int VehicleHeight { get; set; }
        public int VehicleWidth { get; set; }
        public int VehicleLength { get; set; }
        public DateTime? ExpirationTime { get; set; }
    }
}