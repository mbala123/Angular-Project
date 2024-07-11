import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import {MatInputModule} from '@angular/material/input';
import {MatSelectModule} from '@angular/material/select';
import {MatDatepickerModule} from '@angular/material/datepicker';
import {MatMomentDateModule} from '@angular/material-moment-adapter';
import { DialogueExampleComponent } from '../dialogue-example/dialogue-example.component';
import { MatButtonModule } from '@angular/material/button';
import {MatDialog} from '@angular/material/dialog'

@Component({
  selector: 'app-form',
  standalone: true,
  imports: [CommonModule,RouterOutlet,MatInputModule,MatSelectModule,MatDatepickerModule,MatMomentDateModule,MatButtonModule],
  templateUrl: './form.component.html',
  styleUrl: './form.component.css'
})
export class FormComponent {
  constructor(private dialog:MatDialog){}
   openDialog() {
  
    this.dialog.open(DialogueExampleComponent);
  }
}
