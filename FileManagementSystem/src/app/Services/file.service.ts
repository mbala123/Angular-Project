import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileService {

  private readonly fileUrl = 'http://localhost:5008/api/FileManager/';

  constructor(private http: HttpClient) { }
  addFile(formData:any){   
      return this.http.post<any>(this.fileUrl,formData);   
  }

  getFiles(userId: any): Observable<any[]> {
    return this.http.get<any[]>(`${this.fileUrl}${userId}`);
  }

  viewFile(fileId: number): Observable<Blob> {
    var result= this.http.get(`${this.fileUrl}Download/${fileId}`, { responseType: 'blob' });
    return result;
  }

  getFile(fileId:number):Observable<any>{
    return this.http.get(this.fileUrl+"ById/"+fileId)
  }

  async getFileByName(userId:any,fileName:any){
   
    const response= await fetch(this.fileUrl+"GetByFileName/"+userId+"/"+fileName);
    try{
    if(response.ok){
      const data=response.json();
      return data;
    }
    else{
      console.log("error fetching data")
      return null;
    }
  }
    catch(error){
      return null;
    }     
  }

  async deleteFile(fileId:number){
    const url=this.fileUrl+fileId;
    console.log(url)
   const response = await this.http.delete(url).subscribe({
    next:(response)=>{
      return response;
    },
    error:(Error)=>{
      return Error;
    }
   });
   return response;    
  }

  async getFileByCategory(userId:number,categoryId:number){
    const response=await fetch(this.fileUrl+"GetByCategory/"+userId+"/"+categoryId);
    return response.json();
  }
}
