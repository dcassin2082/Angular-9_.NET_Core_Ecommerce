import { OrderItem } from './order-item.Model';

export class CustomerOrder {
    OrderID: number;
    CustomerID: number;
    OrderDate: Date;
    OrderTotal: number;
    OrderSubTotal: number;
    Tax: number;
    ShippingCharge: number;
    CreatedDate: Date; 
    Shipped: boolean;
    ShipDate: Date; 
    CreatedBy: number;
    Carrier: string;
    ItemCount: number;
    FirstName: string; 
    LastName: string;
    OrderItems: OrderItem[];
}
