import { Component } from '@angular/core';
import { LoginComponent } from '../../Account components/login/login/login.component';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { AddFileComponent } from '../../File components/add-file/add-file.component';
import { AddCategoryComponent } from '../../File components/add-category/add-category.component';
import { SignUpComponent } from '../../Account components/login/sign-up/sign-up.component';
import { Router } from '@angular/router';
import { CommonModule } from '@angular/common';
import { AccountService } from '../../Services/account.service';

@Component({
  selector: 'app-navbar-component',
  standalone: true,
  imports: [MatDialogModule,CommonModule],
  templateUrl: './navbar-component.component.html',
  styleUrl: './navbar-component.component.css'
})
export class NavbarComponentComponent {
userId:any;
constructor(
    private dialog: MatDialog,
    private router: Router,
    private service: AccountService
  ) {}

 ngOnInit(): void {
    this.userId=this.service.getLoginDetails();  
  }

  addfile(): void {
    this.dialog.open(AddFileComponent, {
      width: '500px'
    });
  }

  viewfile(): void {
    this.router.navigate(['/view-files',this.userId,0]);
  }

  addCategory(): void {
  const dialogRef= this.dialog.open(AddCategoryComponent, {
      width: '500px'
    });
   dialogRef.componentInstance.categoryUploaded.subscribe(()=>{
    this.dialog.closeAll()  
   window.location.reload();
    this.router.navigate(['/home'])
    })
  }

  login(): void {
   const dialogRef= this.dialog.open(LoginComponent, {
      width: '500px'
    });
    dialogRef.componentInstance.loginDone.subscribe(()=>{
      this.userId=sessionStorage.getItem('currentUser');
      this.router.navigate(['/home']);
    })
  }

  signup(): void {
    this.dialog.open(SignUpComponent, {
      width: '500px',
      height: '800px'
    });
  }

  logout(): void {    
    this.userId=this.service.logout();
    this.router.navigate(['/home']);   
  }

  home():void{
    this.router.navigate(['/home']);
  }
}
