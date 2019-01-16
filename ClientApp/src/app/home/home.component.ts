import { Component, OnInit } from '@angular/core';
import { ParkingService } from '../services/parking.service';
import { Parking } from '../models/Parking';
import { first } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
 // currentUser: User;
  //users: User[] = [];
 
  constructor(private parkingService: ParkingService) {
  //  this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
  }
   
  ngOnInit() {
    alert('post parking ');
    const parking = <Parking>{ Id: 1, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle" };

     this.parkingService.register(parking).pipe(first()).subscribe(users => {
      alert('user registered');
      // this.users = users;

    });


    alert('post parking x10');
    const parkiarr = <Parking[]>[
      { Id: 1, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle1" },
      { Id: 2, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle2" },
      { Id: 3, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle3" },
      { Id: 4, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle4" },
      { Id: 5, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle5" },
      { Id: 6, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle6" },
      { Id: 7, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle7" },
      { Id: 8, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle8" },
      { Id: 9, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle9" },
      { Id: 10, Name: "elisha", TicketType: "regular", VehicleHeight: 100, VehicleLength: 150, VehicleWidth: 200, Vehicletype: "motorcycle10" }

    ];

    this.parkingService.registerBulk(parkiarr).pipe(first()).subscribe(users => {
      alert('user registered');
      // this.users = users;

    });
    

  //  this.loadAllUsers();
  }

  deleteUser(id: number) {
    this.parkingService.delete(id).pipe(first()).subscribe(() => {
      this.loadAllUsers()
    });
  }

  private loadAllUsers() {
    this.parkingService.getAll().pipe(first()).subscribe(users => {
      alert('user loaded');
     // this.users = users;
     
    });
  }
}
