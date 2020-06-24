import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../shared/customer.service';
import { ToastrService } from 'ngx-toastr';
import { NgForm } from '@angular/forms';
import { StateService } from 'src/app/shared/state.service';
import { CustomerOrderService } from 'src/app/customer-orders/shared/customer-order.service';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styles: []
})
export class CustomerComponent implements OnInit {

  constructor(public orderService: CustomerOrderService, public customerService: CustomerService, public stateService: StateService, private toastrService: ToastrService) { }

  ngOnInit() {
    this.resetForm();
    this.stateService.getStates();
  }

  resetForm(form?: NgForm) {
    if (form != null)
      form.reset({
        State: -1
      });
    this.customerService.resetCustomer();
    this.orderService.reset();
  }
  
  submitForm(form: NgForm){
    if(form.value.CustomerId == null){
      form.value.CustomerId = 0;
      this.customerService.postCustomer(form.value).subscribe(x => {
        this.toastrService.success('Customer Added Successfully', 'Add Customer');
        this.customerService.getCustomers();
        this.resetForm(form);
      })
    }
    else{
      this.customerService.putCustomer(form.value).subscribe(x => {
        this.toastrService.info('Customer Updated Successfully', 'Update Customer');
        this.customerService.getCustomers();
        this.resetForm(form);
      })
    }
  }
}
