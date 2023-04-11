import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ValueAndReferenceType } from 'src/app/models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class ValueAndReferenceTypesService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

  getReferenceType(): Observable<ValueAndReferenceType> {
    return this.http.get<ValueAndReferenceType>(this.baseUrl + 'valueandreferencetypes/GetReferenceType');
  }

  getValueType(): Observable<number> {
    return this.http.get<number>(this.baseUrl + 'valueandreferencetypes/GetValueType');
  }

  GetReferenceArray(): Observable<number[]> {
    return this.http.get<number[]>(this.baseUrl + 'valueandreferencetypes/GetReferenceArray');
  }
}
