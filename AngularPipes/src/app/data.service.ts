import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  constructor() { }
  getStudents(){
    return[
      {
        name: 'John Doe',
        course: 'Mathematics',
        marks: 490,
        dob: '2000-01-01',
        gender: 'Male'
      },
      {
        name: 'Jane Smith',
        course: 'Science',
        marks: 585,
        dob: '1999-05-15',
        gender: 'Female'
      },
      {
        name: 'Smith',
        course: 'Social Science',
        marks: 522,
        dob: '1999-04-25',
        gender: 'Male'
      },
      {
        name: 'Mithran',
        course: 'Tamil',
        marks: 564,
        dob: '1998-11-25',
        gender: 'Male'
      },
   
    ]
  }
}
