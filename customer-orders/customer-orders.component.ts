import { Component, OnInit } from '@angular/core';
import { CustomerOrderService } from './shared/customer-order.service';
import { UserService } from '../user/shared/user.service';
import { NgForm } from '@angular/forms';
import { CustomerOrder } from './shared/customer-order.Model';

@Component({
  selector: 'app-customer-orders',
  templateUrl: './customer-orders.component.html',
  styles: [
  ]
})
export class CustomerOrdersComponent implements OnInit {

  constructor(public userService: UserService, public orderService: CustomerOrderService) { }

  key: string = 'OrderDate';
  reverse: boolean = false;
  filter: string;
  active: boolean = false;
  totalItems: number = 0;
  imageUrlLarge: any;
  description: string;
  sku: string;
  productId: number;
  price: number;
  imgID = "Angular";
  detailedDescription: string;

  ngOnInit(): void {
    this.resetForm();
    this.active = true;
  }

  clearSearch() {
    this.filter = null;
  }

  getProduct(id: number){
    this.orderService.orderItem = this.orderService.orderItems.find(x => x.ProductID ===id);
    this.imageUrlLarge = 'data:image/png;base64,' + this.orderService.orderItem.LargePhoto;
    this.description = this.orderService.orderItem.Description;
    this.detailedDescription = this.orderService.orderItem.DetailedDescription;
    this.sku = this.orderService.orderItem.SKU;
    this.productId = id;
    this.price = this.orderService.orderItem.Price;
  }

  loadDetail(order: CustomerOrder) {
    this.orderService.order = Object.assign({}, order);
  }

  loadOrderItems(id: number){ 
    this.orderService.getOrderItems(id);
    this.totalItems = this.orderService.itemCount;
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }
    this.orderService.reset();
  }
 
  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  // magnify(imgID, zoom) {
  //   var img, glass, w, h, bw;
  //   img = document.getElementById(imgID);
  //   /*create magnifier glass:*/
  //   glass = document.createElement("DIV");
  //   glass.setAttribute("class", "img-magnifier-glass");
  //   /*insert magnifier glass:*/
  //   img.parentElement.insertBefore(glass, img);
  //   /*set background properties for the magnifier glass:*/
  //   glass.style.backgroundImage = "url('" + img.src + "')";
  //   glass.style.backgroundRepeat = "no-repeat";
  //   glass.style.backgroundSize =
  //     img.width * zoom + "px " + img.height * zoom + "px";
  //   bw = 3;
  //   w = glass.offsetWidth / 2;
  //   h = glass.offsetHeight / 2;
  //   /*execute a function when someone moves the magnifier glass over the image:*/
  //   glass.addEventListener("mousemove", moveMagnifier);
  //   img.addEventListener("mousemove", moveMagnifier);
  //   /*and also for touch screens:*/
  //   glass.addEventListener("touchmove", moveMagnifier);
  //   img.addEventListener("touchmove", moveMagnifier);
  //   function moveMagnifier(e) {
  //     var pos, x, y;
  //     /*prevent any other actions that may occur when moving over the image*/
  //     e.preventDefault();
  //     /*get the cursor's x and y positions:*/
  //     pos = getCursorPos(e);
  //     x = pos.x;
  //     y = pos.y;
  //     /*prevent the magnifier glass from being positioned outside the image:*/
  //     if (x > img.width - w / zoom) {
  //       x = img.width - w / zoom;
  //     }
  //     if (x < w / zoom) {
  //       x = w / zoom;
  //     }
  //     if (y > img.height - h / zoom) {
  //       y = img.height - h / zoom;
  //     }
  //     if (y < h / zoom) {
  //       y = h / zoom;
  //     }
  //     /*set the position of the magnifier glass:*/
  //     glass.style.left = x - w + "px";
  //     glass.style.top = y - h + "px";
  //     /*display what the magnifier glass "sees":*/
  //     glass.style.backgroundPosition =
  //       "-" + (x * zoom - w + bw) + "px -" + (y * zoom - h + bw) + "px";
  //   }
  //   function getCursorPos(e) {
  //     var a,
  //       x = 0,
  //       y = 0;
  //     e = e || window.event;
  //     /*get the x and y positions of the image:*/
  //     a = img.getBoundingClientRect();
  //     /*calculate the cursor's x and y coordinates, relative to the image:*/
  //     x = e.pageX - a.left;
  //     y = e.pageY - a.top;
  //     /*consider any page scrolling:*/
  //     x = x - window.pageXOffset;
  //     y = y - window.pageYOffset;
  //     return { x: x, y: y };
  //   }
  // }
}
