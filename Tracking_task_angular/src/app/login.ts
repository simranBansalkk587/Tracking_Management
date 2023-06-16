import { Books } from './books';
export class Login {
     username:string;
    password:string;
    email:string;
   id:any;
   bookid:number;
   
   Books:any
    constructor()
    {
        this.username="";
        this.password="";
        this.email="";
        this.id=null;
        this.bookid=0;
        this.Books=null;
    }
}
