import { TrackData } from './../track-data';
import { InvitedpersonService } from './../invitedperson.service';
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
  Tracklist:TrackData[]=[];
  Editdata:TrackData=new TrackData();
  EditInvite:Invite=new Invite();
  userId:number|undefined|null|any;

  constructor(private inviteService:InviteService,private invitedpersonService:InvitedpersonService){}
  ngOnInit()
  {
    this.Getall();
this.userId=sessionStorage.getItem('id');
    this.getbyid(this.userId);
this.getTrackdata()

  }
  getbyid(userId:number){
    if(this.userId){
      this.inviteService.getById(this.userId).subscribe(
        (response)=>{
          console.log(response);
          this.InviteList=response;
          console.log(this.EditInvite);
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
    this.inviteService.GetInvitePerson().subscribe(
      (Response)=>{
        // this.InviteList=Response;
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
   alert 
  this.EditInvite=invite;
  }
  DataEdit(TrackData:TrackData)
  {
    this.Editdata=TrackData;

  }
getTrackdata()
{
  this.invitedpersonService.GetTrackData().subscribe(
    (Response)=>{
      this.Tracklist=Response;

    },
    (Error)=>{
    
   console.log(Error);
    }
  )
}


  
}
