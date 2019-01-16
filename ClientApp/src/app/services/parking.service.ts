
import { Injectable, Inject} from '@angular/core';

import { HttpClient } from '@angular/common/http';


//import { User } from '../models/user';
import {Parking } from '../models/Parking';

@Injectable({
  providedIn: 'root'
})
export class ParkingService {
   
  _base: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this._base = baseUrl;
  }


  getAll() {
    return this.http.get<Parking>(this._base + 'api/parking/chekin');
  }

  getById(id: number) {
    return this.http.get(this._base + `api/parking/` + id);
  }

  register(park: Parking) {
    return this.http.post(this._base + `api/parking/checkin`, park);
  }


  registerBulk(parkarr: Parking[]) {
    return this.http.post(this._base + `api/parking/checkinBulkAsync`, parkarr);
  }

  update(park: Parking) {
    return this.http.put(this._base + `/parking/` + park.Id, park);
  }

  delete(id: number) {
    return this.http.delete(this._base +`api/parking/` + id);
  }
}
