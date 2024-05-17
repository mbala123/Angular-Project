import {Component} from '@angular/core';
import {MatDialog, MatDialogRef, MatDialogModule} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent {
  NameField:string="UserName Or EmailId"
  PasswordField:string="Enter the Password"
  checking:boolean=true
  LoginOrSignIn:any=sessionStorage.getItem("LoginandSignIn");
  constructor(){
    if(this.LoginOrSignIn=="SignIn")
    {
      this.checking=false
    }
  }
  NameFielddata(){
      this.NameField=""
  }
  PasswordFielddata(){
    this.PasswordField=""
  }

}
