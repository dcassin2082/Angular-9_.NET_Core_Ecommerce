import { Injectable } from '@angular/core';
import { Checkout } from './checkout.Model';
import { HttpClient } from '@angular/common/http';
import { Customer } from 'src/app/customers/shared/customer.Model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {

  constructor(private http: HttpClient) { }

  checkout: Checkout; 
  customer: Customer;
  
  baseUrl: string = environment.production ? "https://jungle-deployment.azurewebsites.net/api/customers/" : "https://localhost:44377/api/customers/" ;
  getCustomer() {
    this.http.get(this.baseUrl + 2025).toPromise().then(x => {
      this.customer = x as Customer;
    })
  }
  resetCheckout() {
    this.checkout = {
      CheckoutId: null,
      FirstName: '',
      LastName: '',
      BillingAddress: '',
      BillingCity: '',
      BillingState: '-1',
      BillingZip: '',
      ShippingAddress: '',
      ShippingCity: '',
      ShippingState: '-1',
      ShippingZip: '',
      Phone: '',
      Email: '',
      CardNumber: '',
      CCV: '',
      CardNumbers: [],
      NameOnCard: '',
      Tax: null,
      Shipping: null,
    }
  }
}
