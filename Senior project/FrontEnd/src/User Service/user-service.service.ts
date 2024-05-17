import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserViewModel } from 'src/appoinmentshedulingmodels/appoinmentshedulingmodels.module';
@Injectable({
  providedIn: 'root'
})
export class UserServiceService {
  constructor(private http: HttpClient) {}

  //#region UrlLinks
  private readonly UserUrl="http://localhost:54855/api/User/"; 

  //#endregion


//#region Sign and SignOut

//#endregion


  //#region GetTokens
  GetTokens(){
    var tokens=this.http.get("http://localhost:54855/api/Auth/GetToken?email=ndeva6798%40gmail.com",{responseType:'text'})
    return tokens;
  }
  //#endregion


  //#region Header Tokens
  private Tokendata(){
    return new HttpHeaders({
      'Authorization': 'Bearer '+sessionStorage.getItem("Token"),
      'Content-Type': 'application/json',});
  }
  //#endregion
  
  
  //#region GetAllData
  GetAllUser(){
    const headers= this.Tokendata()
      return this.http.get(this.UserUrl+"UserGetByEmail?email=ndeva6798%40gmail.com",{headers})
  }
  //#endregion


//#region GetByName,Id,Email

//#endregion


//#region Create Data


//#endregion


//#region Edit Data

//#endregion


}