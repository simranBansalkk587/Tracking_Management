import { Books } from './../books';
import { Component } from '@angular/core';
import { BooksService } from '../books.service';

@Component({
  selector: 'app-books',
  templateUrl: './books.component.html',
  styleUrls: ['./books.component.scss']
})
export class BooksComponent {
  BooksList:Books[]=[];
  NewBooks:Books=new Books();
  EditBooks:Books=new Books();

  constructor(private BooksService:BooksService){}
  ngOnInit()
  {
    this.Getall();
  }
  Getall()
  {
    this.BooksService.getAllBooking().subscribe(
      (Response)=>{
        this.BooksList=Response;
        // console.log(this.EmployeeList);
      },
      (Error)=>{
        console.log(Error);
      }
    );
  }
  SaveClick()
  {

    // if(this.from.invalid){
    //   this.submitted=true
    //   return;
    // }
    
    this.BooksService.saveBooks(this.NewBooks).subscribe(
      (response)=>{
this.Getall();
this.NewBooks.title="";
this.NewBooks.author="";
this.NewBooks.isbn="";
this.NewBooks.userid=0;

      }
    )
  }
  EditClick(books:Books)
  {
    
   alert(books.title)
  this.EditBooks=books;
  }
  UpdateClick()
  {
    alert()
    debugger
    this.BooksService.UpdateBooks(this.EditBooks).subscribe(
      (response)=>{
        this.Getall();
      },
      (error)=>{
         console.log(error);
      }
      ) 

  }
  DeleteClick(id:number)
  {
    
    // alert(id);
     let ans=window.confirm('Do you want to delete data !!');
     if(!ans) return;

    this.BooksService.DeleteBooks(id).subscribe(
      (response)=>{
        this.Getall();
      },
      (error)=>{
       // console.log(error);
      },
    );
      
   
  }
  
}
