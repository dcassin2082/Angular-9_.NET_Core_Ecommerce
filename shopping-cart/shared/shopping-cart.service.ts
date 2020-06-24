import { Injectable } from '@angular/core';
import { Product } from 'src/app/products/shared/product.Model';

@Injectable({
  providedIn: 'root'
})
export class ShoppingCartService {

  constructor() { }

  selectedProducts: Product[] = [];
  selectedProduct: Product = new Product();
  cartTotal: number = 0;
  
  filter: Product[];

}
