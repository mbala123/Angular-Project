import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private readonly categoryUrl='http://localhost:5008/api/Category/';

  private categorySubject = new Subject<void>();
     
    category$ = this.categorySubject.asObservable();

  constructor(private http:HttpClient) { }
  
  AddCategory(categoryData:any){
    this.categorySubject.next();
    return this.http.post<any>(this.categoryUrl,categoryData)
  }

  GetCategory(userId:number){
    return this.http.get(this.categoryUrl+"ByUserId/"+userId);
  }
}
