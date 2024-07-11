import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterOutlet } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav'
import { MatToolbarModule } from '@angular/material/toolbar'; 
import {MatButtonModule} from '@angular/material/button'
import {MatIconModule} from '@angular/material/icon'
import { FormComponent } from './form/form.component';
import { DialogueExampleComponent } from './dialogue-example/dialogue-example.component';
import {MatDialogModule} from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input';
import { TableComponent } from "./table/table.component";

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [CommonModule, RouterOutlet, MatSidenavModule, MatToolbarModule, MatButtonModule, MatIconModule, FormComponent, DialogueExampleComponent, MatDialogModule, TableComponent]
})
export class AppComponent {
  title = 'Angular-Materials';
  formview:boolean=false;
  tableview:boolean=false;
  constructor(private router:Router){}
  form(){
    this.formview=true;
    this.tableview=false;
  }
  table(){
    this.formview=false;
    this.tableview=true;
  }
}
