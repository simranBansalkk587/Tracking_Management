import { Component } from '@angular/core';
import { LoginService } from './login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Tracking_task_angular';
  constructor(public loginService:LoginService,){}
  logoutClick()
  {
    this.loginService.logout();
  }
}
