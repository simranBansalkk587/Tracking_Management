import { Books } from './books';
export class TrackData {
    Id:number;
    booksId:number;
    books:any;
    change:string;
    trackingdate:any;
    constructor(){
        this.Id=0
        this.booksId=0;
        this.books=null;
        this.change="";
        this.trackingdate=null;
    }

}
