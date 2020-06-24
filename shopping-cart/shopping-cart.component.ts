import { Component, OnInit } from '@angular/core';
import { UserService } from '../user/shared/user.service';
import { ShoppingCartService } from './shared/shopping-cart.service';
import { Product } from '../products/shared/product.Model';
import { ProductService } from '../products/shared/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-shopping-cart',
  templateUrl: './shopping-cart.component.html',
  styles: [
  ]
})
export class ShoppingCartComponent implements OnInit {

  constructor(private router: Router, public productService: ProductService, public userService: UserService, public shoppingCartService: ShoppingCartService) { }
  arr: any[];
  newArr: Product[] = [];

  ngOnInit(): void {
    this.filter();
  }
  
  addToCart(product: Product) {
    this.shoppingCartService.selectedProducts.push(product);
    this.productService.productsCount++;
    this.shoppingCartService.cartTotal += product.Price;
    this.arr = this.shoppingCartService.selectedProducts.filter(
      (product, i, arr) => arr.findIndex(t => t.ProductId === product.ProductId) === i
    );
    for (var i = 0; i < this.arr.length; i++) {
      if (this.arr[i].ProductId === product.ProductId) {
        this.arr[i].LineCount++;
      }
    }
    this.filter();
  }

  continueShopping(){
    // this.filter();
    this.router.navigate(['/products']);
  }

  filter() {
    // this.shoppingCartService.selectedProducts = this.shoppingCartService.selectedProducts.filter(
    //   function (elem, index, self) {
    //     return index == self.indexOf(elem);
    //   }
    // )
    this.shoppingCartService.selectedProducts.forEach((item, index) => {
      if(this.newArr.findIndex(i => i.ProductId == item.ProductId) === -1){
        this.newArr.push(item);
      }
    });
    this.shoppingCartService.selectedProducts = this.newArr;
  }

  getProduct(id: number) {
    this.shoppingCartService.selectedProduct = this.shoppingCartService.selectedProducts.find(x => x.ProductId === id);
  }

  goToCheckout(){
    this.router.navigate(['/checkout']);
  }

  removeCartItem(product: Product) {
    var item = this.shoppingCartService.selectedProducts.find(x => x.ProductId == product.ProductId);
    this.shoppingCartService.cartTotal -= product.Price;
    if (product.LineCount > 1) {
      product.LineCount--; 
      this.productService.productsCount--;
    }
    else {
      this.shoppingCartService.selectedProducts = this.shoppingCartService.selectedProducts.filter(item => item !== product);
      this.productService.productsCount--;
    }
  }
}
