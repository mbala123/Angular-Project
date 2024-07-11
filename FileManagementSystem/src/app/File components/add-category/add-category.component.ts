import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CategoryService } from '../../Services/category.service';

@Component({
  selector: 'app-add-category',
  standalone: true,
  imports: [CommonModule, FormsModule, MatDialogModule, MatFormFieldModule, MatInputModule],
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.css']
})

export class AddCategoryComponent implements OnInit {
  loginDetails: any;
  userId:any;
  categories: { name: string }[] = [{ name: '' }];
  count=0;

  constructor( private categoryService: CategoryService,public  dialogRef:MatDialogRef<AddCategoryComponent>) {}

  @Output() categoryUploaded=new EventEmitter<void>();

  ngOnInit(): void {
    this.userId=sessionStorage.getItem('currentUser')
  }

  addCategory() {
    this.categories.push({name:''});
  }

  async onSubmit() {
   if (this.categories.every(category => category.name.trim())) {
      for(let i=0; i<this.categories.length; i++){
      const categorydata={
        userId:this.userId,
        categoryName:this.categories[i].name
      }      
      await this.categoryService.AddCategory(categorydata).subscribe(data=>{
        this.count++;
      })
    }
    if(this.count==this.categories.length)
      window.alert("Categories added successfully")  
    this.categoryUploaded.emit();       
    } 
    else {
      console.log('Form is invalid, some categories are empty.');
    }
  }
}
