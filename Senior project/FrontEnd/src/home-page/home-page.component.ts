import { Component } from '@angular/core';
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';
import { UserServiceService } from 'src/User Service/user-service.service';
import { UserViewModel } from 'src/appoinmentshedulingmodels/appoinmentshedulingmodels.module';
@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent {
  checking:boolean=false;
  tesing:any;
  datas:UserViewModel[]=[];

  constructor(private service:UserServiceService){
    this.service.GetTokens().subscribe(data=>{
      this.tesing=data;
      sessionStorage.setItem("Token",this.tesing);
    })
   
  }
  Login()
  { 
    this.service.GetAllUser().subscribe(data=>{
      console.log(data);
    })
    this.changingfield()
    sessionStorage.setItem("LoginandSignIn","Login");
    if(this.checking)
    {
      document.getElementById('section')?.addEventListener('click',()=>{
        this.checking=false;
    })
    }
  }
  SignIn(){
    this.changingfield()
    sessionStorage.setItem("LoginandSignIn","SignIn");
  }
  changingfield(){
    if(!this.checking)
      this.checking=true;
    else
      this.checking=false;
  }
  
}