using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using unitronicsWebApi.Model;

namespace unitronicsWebApi.parking
{


 
   
     
      public interface IParkingMAnager 
        {

        string  chekIn(Parking parking);
        string getParkingLaters(DateTime statusTime);
        //string chekInDB(Parking parking);


        //UserData checkOutDB();


    }
   
    public class ParkingMAnager : IParkingMAnager
    {
        private Parking parking;

        public ParkingMAnager()
        {

          

        }

        public string getParkingLaters( DateTime statusTime)
        {
            //exex stored procedure fo this time
            return "good status";
        }



            public string chekIn(Parking parking)
        {
            Console.WriteLine("checkin user " + parking.Id);
            //after all validations pass - the checkout precess is written to DB
            using (var context = new UnitronicsContext())
            {

                try
                {
                    var exsists = context.Parkings.Where(w => w.Id == parking.Id).FirstOrDefault();
                    if (exsists == null)
                    {
                        //add new row
                        //calculateExpirationTime 
                        //get Timelimit from -> parking.TicketType
                        //add TimeLimit to checkInTime
                        //and insert it to ExpirationDate 
                        //int limit - (parking) ticket.getTimeLimit




                        int limit = 24;
                        parking.CheckInTime = DateTime.UtcNow;
                        parking.ExpirationTime = parking.CheckInTime.AddHours(limit);
                        context.Parkings.Add(parking);

                        context.SaveChanges();

                    }
                    //else
                    //{
                    //    context.Parkings.Update(parking);
                    //    //update 
                    //}
                    

                }
                catch (Exception ex)
                {

                    throw new Exception("cant checkin this ID:" + parking.Id);
                }


             


                // var blogs = context.Students .ToList();
            }

            return "ok";

        }



        //ASYNC VERSION

       


        public string checkOut(string ID)
        {

            using (var context = new UnitronicsContext())
            {

                try
                {

                    if (context.Parkings.Where(w => w.Id == parking.Id).FirstOrDefault() != null)
                    {
                        DateTime  checkoutTime = DateTime.UtcNow;
                        //   creta new vehicle object with  -checkouttime: current time  
                    }
                }
                catch (Exception ex)
                {

                    throw new Exception( ex.InnerException.ToString());
                }

            }
                    //add new row



                    //1. get ID details from DB
                    //2. cretaeVehicle object ->vechiletype
                    //3. creatTicketObject ->ticketType
                    //4. call calculate payment on vehicle - aagainst ticketType cost- and expiration value 
                    //5. if user in time - say thank you . if user late - show the extra payment  25$ +2x Ticket cost.

                    return " ok";
        }
    }

       
      
    
    }

   

