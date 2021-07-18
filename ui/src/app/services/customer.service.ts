import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CustomerModel } from '../models/customer.model';
import { ReferenceDataTypeCode } from './referenceDataTypeCode.enum';

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    private baseUrl = 'http://localhost:63235/customer/';

    constructor(private httpClient: HttpClient) { }

    public GetCustomers(): Observable<CustomerModel[]> {
        return this.httpClient.get<CustomerModel[]>(this.baseUrl);
    }

    public GetCustomer(customerId: number): Observable<CustomerModel> {
        return this.httpClient.get<CustomerModel>(this.baseUrl + customerId);
    }

    public CreateCustomer(customer: CustomerModel): Promise<object> {
        return this.httpClient.post(this.baseUrl, customer).toPromise();
    }
}