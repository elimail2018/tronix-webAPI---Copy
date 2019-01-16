//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace unitronicsWebApi
//{

//    public interface IVehicle { };

//    public class ParkingLot
//    {
//        Dictionary<int, string> _parkingSpots;
//        public ParkingLot()
//        {
//            _parkingSpots = new Dictionary<int, string>();
//            _parkingSpots.Add(1, "car");
//            _parkingSpots.Add(1, "car");
//            // 10 parking spots; 2 free; 6 Regular Paid; 2 Handicapped Free
//            //2 free    
//            // for (int i = 0;i<=60;i++)   _parkingSpots.IsFree == true && _parkingSpots.IsAvailable) ;
//        }
//        public ParkingSpot FindPaidSpot()
//        {
//            return this._parkingSpots.Find(p => p.IsFree == false && p.IsAvailable);
//        }
//        public int GetAvailableSpotsCount()
//        {
//            return this._parkingSpots.Count(p => p.IsAvailable);
//        }
//        public int GetTotalSpots()
//        {
//            return this._parkingSpots.Count;
//        }
//    }
//    public class ParkingSpot    
//    {
//        public bool IsAvailable { get; set; }
//        public bool IsFree { get; set; }
//        public IVehicle ParkedVehicle { get; set; }
//        public ParkingMeter Meter { get; set; }
//        public void Park(IVehicle vehicle)
//        {
//            if (this.ParkedVehicle == null)
//            {
//                this.ParkedVehicle = vehicle;
//                this.IsAvailable = false;
//            }
//            else
//            {
//                throw new Exception("Parking Spot is Taken. Cannot Park here!");
//            }
//        }
//        public ParkingSpot()
//        {
//            this.IsAvailable = true;
//            this.IsFree = true;
//        }
//        public ParkingSpot(bool isFree)
//        {
//            this.IsAvailable = true;
//            this.IsFree = isFree;
//            if (!this.IsFree)
//            {
//                this.Meter = new ParkingMeter();
//            }
//        }
//    }
//    public class HandicappedParkingSpot : ParkingSpot
//    {
//    }
//    public class ParkingMeter
//    {
//        public DateTime EndTime { get; set; }
//        public int MinutesRemaining
//        {
//            get
//            {
//                if (DateTime.Now >= EndTime)
//                    return 0;
//                else
//                    return (EndTime - DateTime.Now).Minutes;
//            }
//        }
//        public int ParkingIntervalMins
//        {
//            get
//            {
//                return 1;
//            }
//        }
//        public void Pay(int quarters)
//        {
//            EndTime = DateTime.Now.AddMinutes(quarters * ParkingIntervalMins);
//        }
//    }

//}
