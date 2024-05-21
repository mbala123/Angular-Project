import { CommonModule, NgFor } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { PercentagePipe } from "./percentage.pipe";
import { DataService } from './data.service';

@Component({
    selector: 'app-root',
    standalone: true,
    templateUrl: './app.component.html',
    styleUrl: './app.component.css',
    imports: [RouterOutlet, CommonModule, NgFor, PercentagePipe]
})
export class AppComponent implements OnInit {
  title = 'AngularPipes';
  totalMarks=600;
  constructor(private dataService: DataService){}
  students=[
    {
    name:'',
    course:'',
    marks:0,
    dob:'',
    gender:''
    }
  ]; 
  ngOnInit(): void {
    this.students=this.dataService.getStudents();
  } 
}
