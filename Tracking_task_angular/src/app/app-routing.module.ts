import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AboutComponent } from './about/about.component';
import { ContactComponent } from './contact/contact.component';
import { BooksComponent } from './books/books.component';
import { InviteTableComponent } from './invite-table/invite-table.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { InvitepersonComponent } from './inviteperson/inviteperson.component';
import { JwtactiateguradService } from './jwtactiategurad.service';
import { RoleguradService } from './rolegurad.service';

const routes: Routes = [
  {path:"home",component:HomeComponent,canActivate:[JwtactiateguradService]},
  {path:"about",component:AboutComponent},
  {path:"contact",component:ContactComponent},
  {path:"books",component:BooksComponent,canActivate:[JwtactiateguradService]},
  {path:"invitetable",component:InviteTableComponent,canActivate:[JwtactiateguradService]},
  {path:"login",component:LoginComponent},
  {path:"register",component:RegisterComponent},
  {path:"inviteperson",component:InvitepersonComponent,canActivate:[JwtactiateguradService]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
