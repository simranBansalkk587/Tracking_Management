import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Invite } from './invite';

@Injectable({
  providedIn: 'root'
})
export class InviteService {

  constructor(private httpclient:HttpClient) { }
  private apiUrl = 'https://localhost:44365/api/InvitedTable';

  GetInvite():Observable<any>
  {
    return this.httpclient.get<any>("https://localhost:44365/api/InvitedTable")

  }
  approveTrack(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}/approve`;
    return this.httpclient.put(url, null);
  }
  setTrackPending(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}/pending`;
    return this.httpclient.put(url, null);
  }
  disableTrack(id: number): Observable<any> {
    const url = `${this.apiUrl}/${id}/disable`;
    return this.httpclient.put(url, null);
  }
 
  getInvitedTableByEmail(email: string) {
    const url = `https://localhost:44365/api/InvitedTable/api/invited-tables?email=${email}`;
    return this.httpclient.get(url);
  }
  Inviteperson(newinvite:Invite):Observable<Invite>
  {
    return this.httpclient.post<Invite>("https://localhost:44365/api/InvitedTable",newinvite);
 

  }
  getById(userId:number):Observable<any>
  {
    return this.httpclient.get<any>("https://localhost:44365/api/InvitedTable/"+userId);
  }
  Getalluser():Observable<any>
  {
    return this.httpclient.get<any>("https://localhost:44365/api/User")

  }
}
