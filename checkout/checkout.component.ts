import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { UserService } from '../user/shared/user.service';
import { NgForm, FormGroupDirective } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CheckoutService } from './shared/checkout.service';
import { CustomerService } from '../customers/shared/customer.service';
import { Router } from '@angular/router';
import { ShoppingCartService } from '../shopping-cart/shared/shopping-cart.service';
import { Customer } from '../customers/shared/customer.Model';
import { StateService } from '../shared/state.service';
import { ProductService } from '../products/shared/product.service';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styles: [
  ]
})
export class CheckoutComponent implements OnInit {
  @ViewChild('chk') chk: ElementRef;

  constructor(public stateService: StateService, public productService: ProductService, public shoppingCartService: ShoppingCartService, private router: Router,
    public customerService: CustomerService, public userService: UserService, private toastrService: ToastrService,
    public checkoutService: CheckoutService) { }

  customer: Customer;
  tax: number;
  shipping: number;
  subtotal: number;
  grandTotal: number;
  months: string[] = ['Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec'];
  years: string[];
  month: string = new Date().getMonth().toString();
  year: string = new Date().getFullYear().toString();
  checked: boolean = false;
  cardType: string;
  result: string;
  selectedMonth: string = '-1';
  selectedYear: string = '-1';
  cards: string[] = ['4111111111111111', '5555555555554444'];
  selectedCardNumber: string = '-1';

  ngOnInit(): void {
    this.stateService.getStates();
    this.subtotal = this.shoppingCartService.cartTotal;
    this.tax = this.subtotal * 0.08;
    this.shipping = this.subtotal > 1000 ? 9.95 : this.subtotal == 0 ? 0.00 : 19.95;
    this.grandTotal = this.subtotal + this.tax + this.shipping;
    this.cardType = '';
    this.resetForm();
  }
  
  backToCart() {
    this.router.navigate(['shopping-cart'])
  }

  clearCardIcons() {
    this.cardType = '';
  }

  onSubmit(form: NgForm) {
    this.toastrService.success('Order Submitted Successfully', 'Order Complete');
    this.tax = 0;
    this.subtotal = 0;
    this.shipping = 0;
    this.grandTotal = 0;
    this.resetForm(form);
    let element: HTMLElement = document.getElementById('collapseOneLink') as HTMLElement;
    element.click();
    this.chk.nativeElement.checked = false;
    this.shoppingCartService.selectedProducts = [];
    this.productService.productsCount = 0;
    this.shoppingCartService.cartTotal = 0;
    this.tax = 0;
    this.shipping = 0;
    this.grandTotal = 0;
  }

  resetForm(form?: NgForm) {
    if (form != null) {
      form.reset();
    }
    this.checkoutService.resetCheckout();
    this.checked = false;
    this.selectedMonth = '-1';
    this.selectedYear = '-1';
  }

  setBillingAddress() {
    this.checked = !this.checked;
    if (this.checked) {
      this.checkoutService.checkout.BillingAddress = this.checkoutService.checkout.ShippingAddress;
      this.checkoutService.checkout.BillingCity = this.checkoutService.checkout.ShippingCity;
      this.checkoutService.checkout.BillingState = this.checkoutService.checkout.ShippingState;
      this.checkoutService.checkout.BillingZip = this.checkoutService.checkout.ShippingZip;
    }
    else {
      this.checkoutService.checkout.BillingAddress = '';
      this.checkoutService.checkout.BillingCity = '';
      this.checkoutService.checkout.BillingState = '-1';
      this.checkoutService.checkout.BillingZip = '';
    }
  }

  setCardNumber(event){
    this.selectedCardNumber = event;
    this.validateCardNumber(this.selectedCardNumber);
  }

  setSelectedMonth(event) {
    var today = new Date();
    var currentMonth = today.getMonth().toString();
    var currentYear = today.getFullYear().toString();
    this.selectedMonth = event;
    
    if(parseInt(this.selectedMonth) >= parseInt(currentMonth)){
      this.years = ['2020', '2021', '2022', '2023', '2024'];
    }
    else{
      this.years = ['2021', '2022', '2023', '2024', '2025'];
    }
  }

  setSelectedYear(event) {
    var currentYear = new Date().getFullYear().toString();
    this.selectedYear = event;
  }

  validateCardNumber(cardNumber: string) {
    this.clearCardIcons();
    var digitSum = 0;
    var digits = '';
    var reversedCardNumber = '';

    if (cardNumber.length == 16) {
      for (var i = cardNumber.length - 1; i >= 0; i--) {
        reversedCardNumber += cardNumber[i];
      }
      for (var i = 0; i < reversedCardNumber.length; i++) {
        if ((i + 1) % 2 == 0) {
          digits += parseInt(reversedCardNumber.substr(i, 1)) * 2;
        }
        else {
          digits += reversedCardNumber.substr(i, 1);
        }
      }
      for (var i = 0; i < digits.length; i++) {
        digitSum += parseInt(digits.substr(i, 1));
      }
      if ((digitSum % 10) == 0) {
        if (cardNumber[0] == '4') {
          this.cardType = "Visa";
          this.result = "Visa"
        }
        else if (cardNumber[0] == '5') {
          this.cardType = "Mastercard";
          this.result = "Mastercard";
        }
        else {
          this.result = "Invalid Card Type";
        }
      }
      else {
        this.result = "Card number is Invalid";
      }
    }
  }
}
