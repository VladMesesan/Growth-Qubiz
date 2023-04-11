import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OopPrinciplesService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

    GetPrinciplesOfOOP(): Observable<any> {
      return this.http.get<any>(this.baseUrl + 'principlesofoop/GetPrinciplesOfOOP');
    }
}
