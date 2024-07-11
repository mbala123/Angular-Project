import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';


@Injectable({
  providedIn: 'root'
})

export class AccountService {

    constructor(private http:HttpClient) { }   

    private readonly userUrl="http://localhost:5008/api/Account/";

    private loginSubject = new Subject<void>();
    private logoutSubject = new Subject<void>();
     
    login$ = this.loginSubject.asObservable();
    logout$ = this.logoutSubject.asObservable();

    async createNewaccount(value:any):Promise<any>{
      return await this.http.post<any>(this.userUrl,value);      
    }

    async login(email: string,password:string) {
    try {
      const response = await fetch(this.userUrl + "Login/" + email+"/"+password);      
      if (response.ok) {
        const userData = await response.json();
        return userData;
      } else {
        console.error('Error fetching user data:', response.statusText);
        return null;
      }
    } 
    catch (error) {
      console.error('An error occurred while fetching user data:', error);
      return null;
    }
  }

  setLoginDetails(userId:number){
    sessionStorage.setItem('currentUser', JSON.stringify(userId));
    this.loginSubject.next(); 
    
  }

  getLoginDetails(){
   return sessionStorage.getItem('currentUser');
  }

  logout(){
    sessionStorage.removeItem('currentUser');
    this.logoutSubject.next();
    return null
  }

}

