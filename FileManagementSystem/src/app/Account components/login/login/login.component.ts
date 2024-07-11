import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Router, RouterOutlet } from '@angular/router';
import { AccountService } from '../../../Services/account.service';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';


@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterOutlet,HttpClientModule,MatDialogModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
   @Output() loginDone=new EventEmitter<void>();

   log={
    userMail:"",
    password:""
  };
  constructor(private service:AccountService, private router:Router,private dialog:MatDialog){}

 async submit() {
  try {
    const response = await this.service.login(this.log.userMail, this.log.password);
    console.log(response);
    if (response.isSuccess) {
      console.log(response.message);
      const userId = response.userId;
      this.service.setLoginDetails(userId);
      this.dialog.closeAll();
      this.loginDone.emit();
      // window.location.reload();
    } 
    else {
      window.alert(response.message);
    }
  } 
  catch (error) {
    window.alert("Error");
  }
}

}

