import { User } from './../user';
import { InviteService } from './../invite.service';
import { Component } from '@angular/core';
import { Invite } from '../invite';
import { RegisterService } from '../register.service';

@Component({
  selector: 'app-invite-table',
  templateUrl: './invite-table.component.html',
  styleUrls: ['./invite-table.component.scss']
})
export class InviteTableComponent {
 InviteList:Invite[]=[];
 userlist:User[]=[];
 status: number=0;
 newinvite:Invite=new Invite();

 invite: any;
 email:string="";
 
 userId:number|undefined|null|any;
 
 

 
 constructor(private inviteService:InviteService,private registerService:RegisterService){}
 ngOnInit()
 {
  this.userId=sessionStorage.getItem('id');
  this.getbyid(this.userId);
//  this.Getall();
this.getdep();
 }
 getbyid(userId:number){
  if(this.userId){
    this.inviteService.getById(this.userId).subscribe(
      (response)=>{
        console.log(response);
        this.InviteList=response;
        console.log(this.newinvite);
      },
   
    (error)=>{
      console.log(error);
      this.Getall();

    }
    )
  }
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
   
  }, (error) => {
   
  });
}
setTrackPending(invite: any): void {
  this.status = invite.status;
  this.inviteService.setTrackPending(this.status).subscribe(() => {
  }, (error) => {
   
  })
  }
  disableTrack(invite: any): void {
    
    this.status = invite.status;
    this.inviteService.disableTrack(this.status).subscribe(() => {
    }, (error) => {
      
    })
    }
    getEmailStatus(email: string) {
      this.newinvite=this.invite.email;
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
        
          console.log(response);
        },
        (error) => {
         
          console.error(error);
        }
      );
      
  }
  fetchInvitedTableByEmail(invite: any) {
    this.inviteService.getInvitedTableByEmail(invite).subscribe(
      (response) => {
       
        console.log(response);
      },
      (error) => {
        
        console.error(error);
      }
    );
  }
  
  inviteClick() {
    this.inviteService.Inviteperson(this.newinvite).subscribe(
      (response) => {
        this.Getall();
        this.newinvite.userId = 0;
        this.newinvite.status = null;
      },
      (error) => {
        // Handle error, if any
      }
    );
  }
  
  getdep()
{
  this.inviteService.Getalluser().subscribe(

    (respone)=>{
      this.userlist=respone;
    },
    (error)=>{
      console.log(error);
    }
  );
}
onSubmit(id:number) {
    debugger
  this.invite.userId=id;
  const userid = sessionStorage.getItem('Id')as string;
if (userid) {
const users = JSON.parse(userid);
this.invite.userid = users;
  this.inviteService.Inviteperson(this.invite).subscribe(
    (response)=>{
alert("Invite Successfuly");
    },
    (error)=>{
    console.log(error);
    alert("Not invite")
    }
    
  )
   
  }
  
}

// saveSelectedUser(this.user) {
//   this.inviteService.SaveUser(user).subscribe(
//     (response) => {
//       console.log('User saved successfully:', response);
//       Perform any additional actions after saving the user
//     },
//     (error) => {
//       console.log('Error saving user:', error);
//     }
//   );
// }
   }
  

