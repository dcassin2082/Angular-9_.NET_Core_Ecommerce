import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Customer } from './customer.Model';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private http: HttpClient, private spinner: NgxSpinnerService) { }

  customer: Customer;
  public customers: Customer[];
  baseUrl: string = environment.production ? "https://jungle-deployment.azurewebsites.net/api/customers" : "https://localhost:44377/api/customers";
  customerId: number;
  selectedRow: Number;

  getCustomers() {
    this.spinner.show();
    setTimeout(() => {
      this.spinner.hide();
    }, 800);
    this.http.get(this.baseUrl).toPromise().then(x => {
      this.customers = x as Customer[];
    })
  }
  getCustomer(id: number) {
    this.http.get(this.baseUrl + '/' + id).toPromise().then(x => {
      this.customer = x as Customer;
    })
  }
  postCustomer(customer: Customer) {
    return this.http.post(this.baseUrl, customer);
  }
  putCustomer(customer: Customer) {
    return this.http.put(this.baseUrl + '/' + customer.CustomerId, customer);
  }
  deleteCustomer(id: number) {
    return this.http.delete(this.baseUrl + '/' + id);
  }
  resetCustomer() {
    this.customer = null;
    // this.customer = {
    //   CustomerId: null,
    //   FirstName: '',
    //   LastName: '',
    //   Address: '',
    //   City: '',
    //   State: '-1',
    //   Zip: '',
    //   Email: ''
    // }
  }
}
