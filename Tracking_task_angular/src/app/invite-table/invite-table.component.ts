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
 status: number=0;
 invitee:Invite=new Invite();
 invite: any;
 
 
 
 email: string="";

 
 constructor(private inviteService:InviteService){}
 ngOnInit()
 {
   this.Getall();
   this.getEmailInvitedTable;
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
 approveTrack(invite: any): void {
  this.status = invite.status;
  this.inviteService.approveTrack(this.status).subscribe(() => {
    // Handle success
  }, (error) => {
    // Handle error
  });
}
setTrackPending(invite: any): void {
  this.status = invite.status;
  this.inviteService.setTrackPending(this.status).subscribe(() => {
  }, (error) => {
    // Handle error
  })
  }
  disableTrack(invite: any): void {
    
    this.status = invite.status;
    this.inviteService.disableTrack(this.status).subscribe(() => {
    }, (error) => {
      // Handle error
    })
    }
    getEmailStatus(email: string) {
      this.invitee=this.invite.email;
      this.inviteService.getInvitedTableByEmail(email)
        .subscribe(
          (response: any) => {
          
            this.invite = response;
           
          },
          (error: any) => {
          
            if (error.status === 400) {
             
            } else if (error.status === 404) {
             
            } else {
             
            }
          }
          
        );
    }
    
  getEmailInvitedTable(invite: any): void {
    this.inviteService.getInvitedTableByEmail(invite.emaiil)
      .subscribe(
        (response) => {
          // Handle the successful response here
          console.log(response);
        },
        (error) => {
          // Handle the error response here
          console.error(error);
        }
      );
      
  }
  // disableTrack(invite: any): void {
    
  //   this.status = invite.status;
  //   this.inviteService.disableTrack(this.status).subscribe(() => {
  //   }, (error) => {
  //     // Handle error
  //   })
  //   }
}
