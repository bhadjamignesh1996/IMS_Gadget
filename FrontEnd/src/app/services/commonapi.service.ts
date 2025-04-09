import { Injectable, NgZone } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from './../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class CommonApiService {
  constructor(public http: HttpClient) { }

  postRequest(url: string, requestData: any) {
    return this.http.post<any>(
      environment.baseUrl + url,
      requestData
    );
  }

  putRequest(url: string, requestData: any = null) {
    return this.http.put<any>(environment.baseUrl + url, requestData);
  }

  getRequest(url: string) {
    return this.http.get<any>(environment.baseUrl + url);
  }

  deleteRequest(url: any) {
    return this.http.delete(environment.baseUrl + url);
  }

}
