import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InviteService {

  constructor(private httpclient:HttpClient) { }

  GetInvite():Observable<any>
  {
    return this.httpclient.get<any>("https://localhost:44365/api/InvitedTable")

  }
}
