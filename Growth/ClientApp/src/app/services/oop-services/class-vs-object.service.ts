import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ClassObject } from 'src/app/models/interfaces';

@Injectable({
  providedIn: 'root'
})
export class ClassVsObjectService {

  constructor(
    @Inject('BASE_URL') private baseUrl: string,
    private http: HttpClient) { }

    GetClassVsObject(): Observable<ClassObject> {
      return this.http.get<ClassObject>(this.baseUrl + 'classvsobject/GetClassObjectExample');
    }
}
