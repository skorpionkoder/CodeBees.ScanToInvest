import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
providedIn: 'root'
})
export class VisionService {

// API url
baseApiUrl = "https://localhost:7081/api/Vision/"

constructor(private http:HttpClient) { }

// Returns an observable
getVisionObject(path:string):Observable<any> {

  var options = {
    headers: new HttpHeaders({
       'Accept':'text/plain'
    }),
    'responseType': 'text' as 'json'
 }

	// Make http post request over api
	// with formData as req
	return this.http.post(this.baseApiUrl.concat(encodeURIComponent(path)), null, options)
}
}
