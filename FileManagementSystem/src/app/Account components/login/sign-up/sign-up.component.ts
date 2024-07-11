import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AccountService } from '../../../Services/account.service';
import { Router } from '@angular/router';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { LoginComponent } from '../login/login.component';


@Component({
  selector: 'app-sign-up',
  standalone: true,
  imports: [CommonModule, FormsModule, MatDialogModule],
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent {
  user = {
    name: '',
    email: '',
    password: '',
    confirmPassword: ''
  };
  value: any;

  constructor(private service: AccountService, private router: Router, private dialog:MatDialog) { }

  async submit(form: any) {
    if (this.user.password === this.user.confirmPassword) {
      this.value = {
        name: this.user.name,
        email: this.user.email,
        password: this.user.password
      };

      try {       
       const data=await this.service.createNewaccount(this.value);
       if(data.isSuccess){
        window.alert(data.message);
        this.router.navigate(['/login'])
       }
       else{
        window.alert(data.message);
       }
      }
      catch{
        window.alert("Error");
      }
    }
    else{
      window.alert("Password does not match")
    }
  }
  Login(){
    this.dialog.closeAll();
     this.dialog.open(LoginComponent, {
      width: '500px'
    });
  }
}

