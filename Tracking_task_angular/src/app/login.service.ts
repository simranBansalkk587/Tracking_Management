import { Books } from './books';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from './login';
import { Observable, map } from 'rxjs';
import { Invite } from './invite';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  CurrentUsername:any="";
  Invite:any;
Books:any;
  constructor(private httpClient:HttpClient,private router:Router) { }
  CheckUser(login:Login):Observable<any>
  {
    return this.httpClient.post<any>(" https://localhost:44365/api/User/authenticate",login).pipe(map(u=>{

    
    if(u)
    {
      this.CurrentUsername=u.username;
      sessionStorage["currentUser"]=JSON.stringify(u);//retrun username all infomation and session pass the jwt token 
      sessionStorage["role"]=JSON.stringify(u.role);  
      sessionStorage["id"]=JSON.stringify(u.id);  
     
    }
    return u;
 
    }))
    
   
  
  // CheckUser(login: Login): Observable<any> {
  // return this.httpClient.post<any>("https://localhost:44365/api/User/authenticate", login).pipe(
  //   map(u => {
  //     if (u) {
  //       this.CurrentUsername = u.username;
  //       sessionStorage.setItem("currentUser", JSON.stringify(u)); // Store user information as a string
  //       sessionStorage.setItem("role", JSON.stringify(u.role));
  //       sessionStorage.setItem("id", JSON.stringify(u.id));

  //       if (u.bookid) {
  //         sessionStorage.setItem("bookid", JSON.stringify(u.bookid));
  //       } else {
  //         sessionStorage.removeItem("bookid"); // Remove the property if it doesn't exist
  //       }

  //       if (u.Books) {
  //         sessionStorage.setItem("books", JSON.stringify(u.Books));
  //       } else {
  //         sessionStorage.removeItem("books"); // Remove the property if it doesn't exist
  //       }
  //     }

  //     return u;
  //   })
  // );
  
}

  
  logout()//session remove the login 
  {
    this.CurrentUsername="";
    sessionStorage.removeItem("currentUser");
    this.router.navigateByUrl("/login");
  }
}
