import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';
import { StockDetailResponse } from 'src/stock';
import { SimilarStocks } from 'src/similar-stocks';
@Injectable({
providedIn: 'root'
})
export class StocksDetailService {

// API url
baseApiUrl = "https://localhost:7081/api/Stocks/"

constructor(private http:HttpClient) { }

// Returns an observable
getStocks(search:string):Observable<any> {

  var options = {
    headers: new HttpHeaders({
       'Accept':'text/plain'
    }),
    'responseType': 'text' as 'json'
 }

	return this.http.get(this.baseApiUrl.concat(search), options)
}

getStockDetails(ticker:string):Observable<StockDetailResponse> {
	return this.http.get<StockDetailResponse>(this.baseApiUrl.concat("details/", ticker));
}

getSimilarStockDetails(description:string):Observable<SimilarStocks[]> {
	return this.http.get<SimilarStocks[]>(this.baseApiUrl.concat("similar/", description));
}
}
