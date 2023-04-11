import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BoxingAndUnboxingService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

    GetBoxingUnboxing(): Observable<any[]> {
      return this.http.get<any[]>(this.baseUrl + 'boxingandunboxing/BoxingAndUnboxing');
    }
}
