import { Component } from '@angular/core';
import { MatDialog,MatDialogModule, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-delete-dialog-component',
  standalone: true,
  imports: [MatDialogModule],
  templateUrl: './delete-dialog-component.component.html',
  styleUrl: './delete-dialog-component.component.css'
})
export class DeleteDialogComponentComponent {

constructor(private dialog:MatDialog,public dialogRef:MatDialogRef<DeleteDialogComponentComponent>){}
onConfirm() {
 this.dialogRef.close(true);
}
onCancel() {
 this.dialogRef.close(false);
}


}
