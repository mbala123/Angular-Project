import { Component } from '@angular/core';
import {MatDialogModule} from '@angular/material/dialog'
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-dialogue-example',
  standalone: true,
  imports: [MatDialogModule,MatInputModule],
  templateUrl: './dialogue-example.component.html',
  styleUrl: './dialogue-example.component.css'
})
export class DialogueExampleComponent {

}
