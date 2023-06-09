import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { Books } from './books';

@Injectable({
  providedIn: 'root'
})
export class BooksService {

  constructor(private httpClient:HttpClient,private router:Router) { }
  getAllBooking():Observable<any>
  {
   // jwt
    // var currentuser={token:""};
    // var headers=new HttpHeaders();
    // headers=headers.set("Authorization","Bearer ");
    // var CurrentUserSession=sessionStorage.getItem("currentuser");
    // if(CurrentUserSession !=null)
    // {
    //   currentuser=JSON.parse(CurrentUserSession);
    //   headers=headers.set("Authorization","Bearer "+ currentuser.token); 

    // }
    
    return this.httpClient.get<any>("https://localhost:44365/api/Book");
    
  
  }
  saveBooks(newBooks:Books):Observable<Books>
  {

    return this.httpClient.post<Books>("https://localhost:44365/api/Book",newBooks);
 

  }
  UpdateBooks(EditBooks:Books):Observable<Books>
  {
    debugger
    return this.httpClient.put<Books>("https://localhost:44365/api/Book",EditBooks);
  
  }
  DeleteBooks(id:number):Observable<any>
  {
    return this.httpClient.delete<any>("https://localhost:44365/api/Book/"+id);
  }
}
// "https://localhost:44372/api/Ticket?id="+id);