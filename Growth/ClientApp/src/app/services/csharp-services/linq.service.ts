import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LinqService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

    GetOldSchoolLINQ(): Observable<number[]> {
      return this.http.get<number[]>(this.baseUrl + 'linq/GetOldSchoolLINQ');
    }

    GetLambdaLINQ(): Observable<string[]> {
      return this.http.get<string[]>(this.baseUrl + 'linq/GetLambdaLINQ');
    }
}
