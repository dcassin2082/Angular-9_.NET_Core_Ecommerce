import { Component, OnInit } from '@angular/core';
import { ProductService } from './shared/product.service';
import { UserService } from '../user/shared/user.service';
import { Product } from './shared/product.Model';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { ShoppingCartService } from '../shopping-cart/shared/shopping-cart.service';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html'
})
export class ProductsComponent implements OnInit {

  constructor(private spinner: NgxSpinnerService, private router: Router, public productService: ProductService, public shoppingCartService: ShoppingCartService, public userService: UserService) { }

  key: string = 'Price';
  reverse: boolean = false;

  ngOnInit(): void {
    // this.spinner.show();
    // setTimeout(() => {
    //   this.spinner.hide();
    // }, 1200);

    if (this.productService.categoryId == -1) {
      this.getProductCategories();
    }
    if (this.shoppingCartService.selectedProducts == null) {
      this.shoppingCartService.selectedProducts = [];
    }
    if(this.productService.products == null){
      this.getAllProducts();
    }
    
  }

  ngAfterViewInit(): void { 
  }

  addToCart(product: Product) {
    this.shoppingCartService.selectedProducts.push(product);
    this.productService.productsCount++;
    this.shoppingCartService.cartTotal += product.Price;
    var arr = this.shoppingCartService.selectedProducts.filter(
      (product, i, arr) => arr.findIndex(t => t.ProductId === product.ProductId) === i
    );
    for (var i = 0; i < arr.length; i++) {
      if (arr[i].ProductId == product.ProductId) {
        arr[i].LineCount++;
      }
    }
    this.shoppingCartService.filter = arr;
  }

  getAllProducts() {
    this.productService.getAllProducts();
  }

  getProducts(id: number) {
    this.productService.getProducts(id, this.productService.sortTerm);
  }

  getProduct(id: number) {
    this.productService.product = this.productService.products.find(x => x.ProductId === id);
  }

  getProductCategories() {
    this.productService.getProductCategories();
  }

  getSubCategories(id: number) {
    this.productService.getProductSubcategories(id);
  }

  goToCart() {
    this.router.navigate(['/shopping-cart']);
  }

  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }
}
