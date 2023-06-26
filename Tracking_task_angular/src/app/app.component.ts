import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tracking_task_angular';
  isLoggedIn:boolean=true;
  constructor(public loginService:LoginService,private router:Router){}
  ngOnInit(): void {
    

    this.router.events.subscribe(event=>{
      this.isLoggedIn=sessionStorage.getItem('isLoggedIn')==='true';
      if(event instanceof NavigationEnd){
 let role = sessionStorage.getItem('role');
 
      }
    })
  }

  logoutClick()
  {
    this.loginService.logout();
  }
}
