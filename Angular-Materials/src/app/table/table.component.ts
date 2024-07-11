import { CommonModule } from '@angular/common';
import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { DataService } from '../data.service';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';

@Component({
  selector: 'app-table',
  standalone: true,
  imports: [RouterOutlet,CommonModule,MatTableModule,MatPaginatorModule,MatPaginator],
  templateUrl: './table.component.html',
  styleUrl: './table.component.css'
})
export class TableComponent implements OnInit, AfterViewInit{

  @ViewChild(MatPaginator) paginator!:MatPaginator;
    constructor(public dataService:DataService){}
    details=[
      {
        no:0,
        name:'',
        course:'',
        marks:0
      }
    ];
    ngOnInit(): void {
      this.details=this.dataService.getData();
       this.dataSource.data = this.details;
    }
      dataSource=new MatTableDataSource(this.details);
    displayedColumns: string[]=['no','name','course','marks'];
    ngAfterViewInit(): void {
     
        this.dataSource.paginator=this.paginator;
      
    }

}
