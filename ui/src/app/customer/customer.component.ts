import { CustomerService } from './../services/customer.service';
import { CustomerModel } from './../models/customer.model';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { NgForm } from '@angular/forms';
import { ReferenceDataService } from '../services/reference-data.service';

@Component({
    selector: 'app-customer',
    templateUrl: './customer.component.html',
    styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
    
    public customerTypes: string[] = [];

    public customers: CustomerModel[] = [];

    public customerTypes$: Observable<string[]>;

    public customers$: Observable<CustomerModel[]>;

    public newCustomer: CustomerModel = {
        customerId: null,
        name: null,
        type: null
    };

    constructor(private customerService: CustomerService,
        private referenceDataService: ReferenceDataService) { }

    ngOnInit() {
        this.customerTypes$ = this.referenceDataService.GetCustomerTypes();
        this.customers$ = this.customerService.GetCustomers().pipe(map(data => this.customers = data));
    }

    public createCustomer(form: NgForm): void {
        if (form.invalid) {
          alert('form is not valid');
        } else {
          this.customerService.CreateCustomer(this.newCustomer).then((response) => {

            //TODO: Supposed to add this response to State management OR Cache service to avoid additional API call.
            this.customers.push(response as CustomerModel);
          });
        }
      }

}