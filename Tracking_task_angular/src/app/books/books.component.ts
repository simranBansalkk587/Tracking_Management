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
  book: any = {};
  userid:number|undefined|null|any;
  constructor(private BooksService:BooksService){}
  ngOnInit()
  {
    this.userid=sessionStorage.getItem('id');
    this.getidBybook(this.userid);
  }
  getidBybook(userid:number)
  {
    debugger;
    if(this.userid){
      this.BooksService.getById(this.userid).subscribe(
        (response)=>{
          console.log(response);
          
          this.BooksList=response;
          console.log(this.NewBooks);
          
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
 this.NewBooks.userId=0;

      }
    )
  }
  addBook(): void {
    this.BooksService.addBook(this.book).subscribe(() => {
      // Book added successfully, handle any success logic
    }, error => {
      // Handle error response from the API
    });
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
