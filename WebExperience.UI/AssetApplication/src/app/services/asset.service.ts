import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


const baseUrl = 'http://localhost:62677/api/Asset';
@Injectable({
  providedIn: 'root'
})
export class AssetService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    let url:string=baseUrl+'/'+'GetAssets';
    return this.http.get(url);
  }

  get(assetid:string): Observable<any> {
    let url:string=baseUrl+'/'+'GetAsset';

    return this.http.get(`${url}?assetid=${assetid}`);
  }

  create(tparam:any): Observable<any> {
    debugger;
    let url:string=baseUrl+'/'+'ManageAsset';
    return this.http.post(url,tparam);
  }
}