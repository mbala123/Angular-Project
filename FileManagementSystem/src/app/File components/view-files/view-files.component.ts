import {  Component, OnInit, ViewChild } from '@angular/core';
import { FileService } from '../../Services/file.service';
import { CommonModule } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { DeleteDialogComponentComponent } from '../delete-dialog-component/delete-dialog-component.component';
import { PasswordDialogComponentComponent } from '../password-dialog-component/password-dialog-component.component';
import { ActivatedRoute, Router } from '@angular/router';
import { AddFileComponent } from '../add-file/add-file.component';

@Component({
  selector: 'app-view-files',
  standalone: true,
  templateUrl: './view-files.component.html',
  styleUrls: ['./view-files.component.css'],
  imports: [CommonModule, AddFileComponent, MatTableModule,MatPaginator]
})
export class ViewFilesComponent implements OnInit {
  files: any[] = [];
  fileUrl: any;
  viewfile: boolean = false;
  fileType: string = "";

  dataSource = new MatTableDataSource<any>();
  displayedColumns: string[] = ['fileId', 'fileName', 'category', 'createdOn','securityType', 'actions'];

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private service: FileService,  private dialog: MatDialog,private route:ActivatedRoute, private router:Router) { }
  userId=0;
  categoryId=0;
  ngOnInit(): void {   
    this.loadfiles();   
  }
  
   loadfiles(){
    this.route.paramMap.subscribe(params=>{
      this.userId= +params.get('userId')!;
      this.categoryId= +params.get('categoryId')!
    })

   if(this.userId==0){    
    this.router.navigate(['/home']);
   }
   else if (this.categoryId==0 &&this.userId>0) {
      this.service.getFiles(this.userId).subscribe(
        data => {
          this.files = data;
           console.log(this.files)
          this.dataSource.data = this.files; 
        },
       
      );
    }
    else if(this.categoryId>0 && this.userId>0){
      this.service.getFileByCategory(this.userId,this.categoryId).then(data=>{
        this.files=data;
        console.log("Category files",this.files);
        this.dataSource.data=this.files;
      })
    }
  }

  ngAfterViewInit(): void {
    setTimeout(() => {
      if (this.paginator) {
        this.paginator._intl.itemsPerPageLabel = ''; 
        this.paginator.pageSize = 5; 
        this.paginator.hidePageSize = true; 
        this.dataSource.paginator = this.paginator;
      }
    });
  }

  adddialogueopen() {
    const dialogRef=this.dialog.open(AddFileComponent);
       dialogRef.componentInstance.fileUploaded.subscribe(() => {
      this.loadfiles(); // Refresh the file list
    });
  }

  // viewFile(fileId: number): void {
  //   this.service.viewFile(fileId).subscribe(response => {
  //     const blob = new Blob([response], { type: response.type });
  //     this.fileUrl = this.sanitizer.bypassSecurityTrustResourceUrl(URL.createObjectURL(blob));
  //     this.viewfile = true;
  //   }, error => {
  //     console.error('File view failed', error);
  //   });
  // }

 async fileVerification(fileId: number, functionType:string) {
  await this.service.getFile(fileId).subscribe(response => {
    const fileName = response.fileName;
    const securityType = response.securityType;
    const filePassword=response.password; 

    if (securityType === 'Protected') {
      const dialogRef = this.dialog.open(PasswordDialogComponentComponent);

      dialogRef.afterClosed().subscribe(password => {
          if(password==filePassword){
            if(functionType=='Download'){
            this.initiateDownload(fileId,fileName);
            }
            else{
              this.deleteFile(fileId);
            }
          }
          else{
            window.alert("Invalid file password");
            this.loadfiles();
          }
      });
    }
    else {
      if(functionType=='Download'){
      this.initiateDownload(fileId, fileName);
      }
      else{
        this.deleteFile(fileId);
      }
    }
  });
}

async initiateDownload(fileId: number, fileName: string) {
  await this.service.viewFile(fileId).subscribe(response => {
    const blob = new Blob([response], { type: response.type });
    this.fileUrl = URL.createObjectURL(blob);
    const a = document.createElement('a');
    a.href = this.fileUrl;
    a.download = fileName;
    a.click();
    URL.revokeObjectURL(this.fileUrl);
    console.log("File downloaded successfully");
  });
}

  async deleteFile(fileId:number){
   const dialogRef=this.dialog.open(DeleteDialogComponentComponent);
   dialogRef.afterClosed().subscribe(async result=>{
    if(result){
         await this.service.deleteFile(fileId)
         window.alert("File deleted successfully")
         await this.loadfiles();   
    }
   })  
}
}

