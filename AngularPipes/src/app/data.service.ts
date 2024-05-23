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
        gender: 'Male',
        streetName:'123 Main St',
        cityName:'Chennai',
        state:'TamilNadu',
        pinCode:'626001'
      },
      {
        name: 'Jane Smith',
        course: 'Science',
        marks: 585,
        dob: '1999-05-15',
        gender: 'Female',
        streetName:'VOC Street',
        cityName:'Madurai',
        state:'TamilNadu',
        pinCode:'626021'
      },
      {
        name: 'Smith',
        course: 'Social Science',
        marks: 522,
        dob: '1999-04-25',
        gender: 'Male',
        streetName:'Bharathiyar Street',
        cityName:'Namakkal',
        state:'TamilNadu',
        pinCode:'636401'
      },
      {
        name: 'Mithran',
        course: 'Tamil',
        marks: 564,
        dob: '1998-11-25',
        gender: 'Male',
        streetName:'Tansi Street',
        cityName:'Tricy',
        state:'TamilNadu',
        pinCode:'645632'
      },
   
    ]
  }
}
