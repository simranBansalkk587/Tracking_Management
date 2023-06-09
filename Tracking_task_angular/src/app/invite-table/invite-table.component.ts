import { InviteService } from './../invite.service';
import { Component } from '@angular/core';
import { Invite } from '../invite';

@Component({
  selector: 'app-invite-table',
  templateUrl: './invite-table.component.html',
  styleUrls: ['./invite-table.component.scss']
})
export class InviteTableComponent {
 InviteList:Invite[]=[];
 constructor(private inviteService:InviteService){}
 Getall()
 {
   this.inviteService.GetInvite().subscribe(
     (Response)=>{
       this.InviteList=Response;
       // console.log(this.EmployeeList);
     },
     (Error)=>{
       console.log(Error);
     }
   );
 }

}
