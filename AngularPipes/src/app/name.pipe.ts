import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'name',
  standalone: true
})
export class NamePipe implements PipeTransform {

  transform(value:string,gender:string) {
    if(gender.toLowerCase()=='male'){
      return 'Mr. '+value;
    }
    else{
      return 'Ms. '+value;
    }
  }

}
