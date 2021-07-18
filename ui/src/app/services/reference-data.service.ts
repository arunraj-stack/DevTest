import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ReferenceDataTypeCode } from './referenceDataTypeCode.enum';

@Injectable({
    providedIn: 'root'
})
export class ReferenceDataService {

    private baseUrl = 'http://localhost:63235/ReferenceData/';

    constructor(private httpClient: HttpClient) { }

    public GetCustomerTypes(): Observable<string[]> {
        return this.httpClient.get<string[]>(this.baseUrl + ReferenceDataTypeCode.CustomerType);
    }
}