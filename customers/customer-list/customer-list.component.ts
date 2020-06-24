import { Component, OnInit, ViewChild, ElementRef, Input } from '@angular/core';
import { CustomerService } from '../shared/customer.service';
import { ToastrService } from 'ngx-toastr';
import { Customer } from '../shared/customer.Model';
import { CustomerOrderService } from 'src/app/customer-orders/shared/customer-order.service';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { DateTime } from '@syncfusion/ej2-angular-charts';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styles: []
})
export class CustomerListComponent implements OnInit {
  constructor(private router: Router, public orderService: CustomerOrderService, public customerService: CustomerService, private toastrService: ToastrService) {
    this.setClickedRow = function (index, customer) {
      this.selectedRow = index;
      this.loadCustomer(customer);
    }
  }

  public primaryXAxis: Object;
  public chartData: Object[];
  public title: string;
  public primaryYAxis: Object;
  public marker: Object;
  public legendSettings: Object;
  public tooltip: Object;
  public titleStyle: Object;

  
  selectedRow: Number;
  setClickedRow: Function;
  key: string = 'FirstName';
  p: number = 1;
  filter: string;
  reverse: boolean = false;

  pageChanged(page: number) {
    this.resetCustomer();
    this.p = page;
    this.selectedRow = -1;
    this.orderService.reset();
  }
  clearSearch() {
    this.filter = null;
  }

  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }


  ngOnInit() {
    if(this.customerService.customers == null){
      this.customerService.getCustomers();
    }
    this.resetCustomer();
    this.orderService.reset();
    this.orderService.orders = null;
    this.orderService.orderItems = null;
    this.orderService.order = null;
  }

  loadCustomer(customer: Customer) {
    this.customerService.customer = Object.assign({}, customer);
    this.orderService.getOrders(customer.CustomerId);
    this.orderService.p = 1;
    this.scroll();
  }

  resetCustomer() {
    this.customerService.customer = null;
  }
  
  scroll() {
    let el = document.getElementById('customer');
    if (el !== undefined && el !== null) {
      el.scrollIntoView({ behavior: 'smooth', block: 'center' });
    }
  }

  deleteCustomer(id: number) {
    if (confirm("Are you sure you want to delete this customer?")) {
      this.customerService.deleteCustomer(id).subscribe(x => {
        this.toastrService.warning("Customer Deleted Successfully", "Delete Customer");
        this.customerService.getCustomers();
        this.customerService.resetCustomer();
      })
    }
  }
}
