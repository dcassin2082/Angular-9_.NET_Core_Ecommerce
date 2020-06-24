import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CustomerOrder } from './customer-order.Model';
import { OrderItem } from './order-item.Model';
import { CustomerService } from 'src/app/customers/shared/customer.service';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class CustomerOrderService {

  constructor(private http: HttpClient, public customerService: CustomerService, private spinner: NgxSpinnerService) { }

  baseUrl: string = environment.production ? "https://jungle-deployment.azurewebsites.net/api/customerorders/" : "https://localhost:44377/api/customerorders/" ;
  order: CustomerOrder;
  orders: CustomerOrder[];
  orderItem: OrderItem;
  orderItems: OrderItem[];
  count: number;
  public itemCount: number = 0;
  imageUrl: any[] = [];
  firstName: string;
  lastName: string;
  public p: number = 1;

  getOrders(id: number) { 
    this.spinner.show();
    this.http.get(this.baseUrl + 'summary/' + id).toPromise().then(x => {
      this.orders = x as CustomerOrder[];
      this.firstName = this.orders.find(x => x.CustomerID === id).FirstName;
      this.lastName = this.orders.find(x => x.CustomerID === id).LastName;
      this.count = this.orders.length;
      this.spinner.hide();
    })
  }
  getOrderItems(id: number) {
    this.orderItems = this.orders.find(x => x.OrderID === id).OrderItems;
    let i = 0;
    let itemCount = 0;
    this.orderItems.forEach(element => {
      this.imageUrl[i] = 'data:image/png;base64,' + element.ThumbnailPhoto;
      itemCount += element.ItemCount;
      i++;
    })
    this.itemCount = itemCount;
    console.log(this.itemCount);
  }
  reset() {
    this.order = null;
    this.orders = null;
    this.orderItems = null;
    this.orderItem = null;
  }
}
