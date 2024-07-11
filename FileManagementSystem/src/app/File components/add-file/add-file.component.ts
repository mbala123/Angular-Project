import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Output } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { FileService } from '../../Services/file.service';
import { Router, RouterOutlet } from '@angular/router';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import {MatInputModule} from '@angular/material/input'
import { AddCategoryComponent } from '../add-category/add-category.component';
import { CategoryService } from '../../Services/category.service';



@Component({
  selector: 'app-add-file',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterOutlet,MatDialogModule,MatInputModule],
  templateUrl: './add-file.component.html',
  styleUrls: ['./add-file.component.css']  
})
export class AddFileComponent {
  file: any = {
    fileData: null,
    fileName: "",
    categoryId: "",
    securityType: 0,
    isDeleted: false,
    createdBy: sessionStorage.getItem('currentUser'),
    userId:sessionStorage.getItem('currentUser'),
    password:"0",
    confirmPassword:"0"
  };
 
  constructor(private fileService: FileService,private categoryService: CategoryService, private router:Router,private dialog: MatDialog) { }
  @Output() fileUploaded = new EventEmitter<void>();
   categories:any []=[];
  ngOnInit(): void {
    this.loadCategories();
    console.log(this.categories)
  }

  loadCategories() {
    this.categoryService.GetCategory(this.file.userId).subscribe(
     ( data:any) => {
        this.categories = data;
        console.log("Load categories",this.categories)
      },
    
    );
  }

  async onSubmit() {
   
    if(this.file.password==this.file.confirmPassword){
       const formData = new FormData();
      formData.append('fileData', this.file.fileData);
      formData.append('fileName',this.file.fileName)
      formData.append('categoryId', this.file.category);
      formData.append('securityType', this.file.securityType.toString());
      formData.append('isDeleted', this.file.isDeleted.toString());
      formData.append('createdBy', this.file.createdBy.toString());
      formData.append('userId', this.file.userId.toString());
      formData.append('password',this.file.password);
      console.log(this.file.password)
      const response=await this.fileService.getFileByName(this.file.userId,this.file.fileName)

      if(!response){    
          await this.fileService.addFile(formData).subscribe(
        response => {
          window.alert("File Uploaded successfully");
          console.log('File uploaded successfully', response);
         this.fileUploaded.emit();
       //  window.location.reload();
          this.dialog.closeAll();
          this.router.navigate(['/view-files'])
        },
        error => {
          window.alert("File Upload failed")
          console.error('File upload failed', error);          
        }
      );      
    }
      else{
        window.alert("File name already exists")
      console.log('File name already exists');
       this.dialog.closeAll();
      this.router.navigate(['/view-files'])
    }
    }
    else{
      window.alert("Password does not match")
    } 
   
  }

  onFileSelected(event: any) {
    const file = event.target.files[0];
    console.log(file)
    if (file) {
      this.file.fileData=file;
      this.file.fileName=file.name;
    }
  }

  onCategoryChange(value: string) {
    if (value === 'addNew') {
      this.dialog.closeAll();
         const dialogRef =  this.dialog.open(AddCategoryComponent, {
    width: '500px'  
  });
    dialogRef.componentInstance.categoryUploaded.subscribe(()=>{
      this.dialog.closeAll();
      this.loadCategories();
      this.dialog.open(AddFileComponent)
  }); 
 } 
    else {
      this.file.category = value;
    }
  }
}
