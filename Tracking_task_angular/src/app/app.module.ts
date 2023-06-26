import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { BooksComponent } from './books/books.component';
import { InviteTableComponent } from './invite-table/invite-table.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { InvitepersonComponent } from './inviteperson/inviteperson.component';
import { TrackDetailsComponent } from './track-details/track-details.component';
import { JwtintercapterService } from './jwtintercapter.service';
import { JwtModule } from '@auth0/angular-jwt';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    AboutComponent,
    ContactComponent,
    BooksComponent,
    InviteTableComponent,
    LoginComponent,
    RegisterComponent,
    InvitepersonComponent,
    TrackDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
   FormsModule,
   ReactiveFormsModule,
   JwtModule.forRoot({
    config:{
      tokenGetter:()=>{
        return sessionStorage.getItem("currentUser")? JSON.parse(sessionStorage.getItem("currentUser")as string).token:null;
      }
    }
     })
  ],
  providers: [
    {
      provide:HTTP_INTERCEPTORS,
      useClass:JwtintercapterService,
      multi:true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
