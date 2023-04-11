import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PassingParams } from '../../models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class PassingParamsService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

    GetPassingParameters(): Observable<PassingParams> {
      return this.http.get<PassingParams>(this.baseUrl + 'passingparameters/GetPassingParametersTest');
    }
}
