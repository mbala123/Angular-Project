import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MatDialog, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';

@Component({
  selector: 'app-password-dialog-component',
  standalone: true,
  imports: [MatDialogModule,MatFormFieldModule,CommonModule,FormsModule],
  templateUrl: './password-dialog-component.component.html',
  styleUrl: './password-dialog-component.component.css'
})
export class PasswordDialogComponentComponent {

  constructor(public dialogRef:MatDialogRef<PasswordDialogComponentComponent>){}
password = '';
  onConfirm() {
this.dialogRef.close(this.password);
}
onCancel() {
this.dialogRef.close(null);
}
}
