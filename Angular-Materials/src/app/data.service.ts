import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }
  getData(){
    return [
      {
        no:1,
        name:'John',
        course:'Mathematics',
        marks:89
      },
      {
        no:2,
        name:'Doe',
        course:'Science',
        marks:92
      },
      {
        no:3,
        name:'Jane',
        course:'English',
        marks:78
      },
      {
        no:4,
        name:'Smith',
        course:'Tamil',
        marks:83
      },
       {
        no:5,
        name:'Mithra',
        course:'Social',
        marks:89
      },
       {
        no:6,
        name:'Ram',
        course:'English',
        marks:82
      },
        {
        no:7,
        name:'Seetha',
        course:'Science',
        marks:89
      },
        {
        no:8,
        name:'Mani',
        course:'Maths',
        marks:82
      },
       {
        no:9,
        name:'James',
        course:'Tamil',
        marks:80
      },
      {
        no:10,
        name:'Anderson',
        course:'Science',
        marks:84
      },
    ]
  }
}
