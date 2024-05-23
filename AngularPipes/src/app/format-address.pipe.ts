import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatAddress',
  standalone: true
})
export class FormatAddressPipe implements PipeTransform {

  transform(streetName:string,cityName:string,state:string,pinCode:string) {
    return (streetName+", "+cityName+", "+state+". Pincode - <"+pinCode+">");
  }

}
