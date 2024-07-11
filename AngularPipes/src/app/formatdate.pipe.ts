import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'formatdate',
  standalone: true
})
export class FormatdatePipe implements PipeTransform {

  transform(value:string) {
    const dateParts=value.split('-');
    const monthNames=["January","February","March","April","May","June","July","August","September","October","November","December"];
    const day=parseInt(dateParts[2]);
    const month=monthNames[parseInt(dateParts[1])-1];
    const year=dateParts[0];
    const suffix = (day: number)=>{
      if(day>3 && day>21){
        return 'th';
      }
      else{
        switch(day%10){
          case 1:return 'st';
          case 2:return 'nd';
          case 3:return 'th';
          default: return 'th';
        }
      }
    }
    return (day+suffix(day)+" of "+month+" "+year)
  }

}
