import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
@Injectable({
providedIn: 'root'
})
export class FileUploadService {

// API url
baseApiUrl = "https://localhost:7081/api/Media/UploadFile"

constructor(private http:HttpClient) { }

// Returns an observable
upload(file:any):Observable<any> {

  var options = {
    headers: new HttpHeaders({
       'Accept':'text/plain'
    }),
    'responseType': 'text' as 'json'
 }

	// Create form data
	const formData = new FormData();

	// Store form name as "file" with file data
	formData.append("files", file, file.name);

	// Make http post request over api
	// with formData as req
	return this.http.post(this.baseApiUrl, formData, options)
}
}
