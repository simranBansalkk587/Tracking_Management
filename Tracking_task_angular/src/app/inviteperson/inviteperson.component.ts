import { Component } from '@angular/core';
import { Invite } from '../invite';
import { InviteService } from '../invite.service';

@Component({
  selector: 'app-inviteperson',
  templateUrl: './inviteperson.component.html',
  styleUrls: ['./inviteperson.component.scss']
})
export class InvitepersonComponent {
  InviteList:Invite[]=[];
  EditInvite:Invite=new Invite();

  constructor(private inviteService:InviteService){}
  ngOnInit()
  {
    this.Getall();

  }
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
  EditClick(invite:Invite)
  {
    
   //alert(invite.title)
  this.EditInvite=invite;
  }
  
}
