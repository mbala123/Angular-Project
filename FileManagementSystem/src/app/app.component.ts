import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './Account components/login/login/login.component';
import { SignUpComponent } from './Account components/login/sign-up/sign-up.component';
import { AddFileComponent } from './File components/add-file/add-file.component';
import { ViewFilesComponent } from './File components/view-files/view-files.component';
import { DeleteDialogComponentComponent } from './File components/delete-dialog-component/delete-dialog-component.component';
import { PasswordDialogComponentComponent } from './File components/password-dialog-component/password-dialog-component.component';
import { HomePageComponent } from './Home components/home-page/home-page.component';
import { AddCategoryComponent } from './File components/add-category/add-category.component';
import { NavbarComponentComponent } from './Home components/navbar-component/navbar-component.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterOutlet,HttpClientModule,LoginComponent,SignUpComponent,AddFileComponent,ViewFilesComponent,DeleteDialogComponentComponent,PasswordDialogComponentComponent,HomePageComponent,AddCategoryComponent,NavbarComponentComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'FileManagementSystem';
 
}
