import { Component, OnInit } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';
import { CategoryService } from '../../Services/category.service';
import { AccountService } from '../../Services/account.service';
import { Subscription } from 'rxjs';


@Component({
  selector: 'app-home-page',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})

export class HomePageComponent implements OnInit {

  constructor(
    private categoryservice: CategoryService,
    private router:Router,
    private service:AccountService,
  ) {}

 private loginSubscription: Subscription | undefined;
 private categorySubscription: Subscription | undefined;
 private logoutSubscription: Subscription | undefined;
  userId:any;
  categories: any[] = [];

  
  ngOnInit() {  
   this.userId=this.service.getLoginDetails(); 
   this.fetchCategories();
   this.loginSubscription = this.service.login$.subscribe(() => {
      this.userId = this.service.getLoginDetails();
      this.fetchCategories();
    });
    this.categorySubscription=this.categoryservice.category$.subscribe(()=>{
      this.fetchCategories();
    });
    this.logoutSubscription=this.service.logout$.subscribe(()=>{
      this.userId=this.service.getLoginDetails();
    })    
  }  
  
  fetchCategories(): void {
    if (this.userId!=null) {
      this.categoryservice.GetCategory(this.userId).subscribe(
        (data: any) => {
          this.categories = data;
        }        
      );
    }
  }

  GetCategoryFiles(categoryId:number){
    this.router.navigate(['/view-files',this.userId,categoryId])
  }
  
}
