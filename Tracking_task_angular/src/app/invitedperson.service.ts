import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InvitedpersonService {

  constructor(private httpClient:HttpClient) { }
 
  // GetInvitePerson():Observable<any>
  // {
  //   return this.httpClient.get<any>("https://localhost:44365/api/InvitedTable/approved")
  // }
  GetTrackData():Observable<any>
  {
    return this.httpClient.get<any>("https://localhost:44365/api/TrackDetails")
  }
}
