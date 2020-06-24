import { Component, OnInit } from '@angular/core';
import { UserService } from '../user/shared/user.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styles: []
})
export class CustomersComponent implements OnInit {

  constructor(public userService: UserService, private router: Router) { }

  checked: boolean = false;
  switchChartType: string = 'Column';

  ngOnInit() {
  
  }
  
  setChartType() {
    this.checked = !this.checked;
    if (this.checked) {
      this.switchChartType = 'Line'
    }
    else{
      this.switchChartType = 'Column';
    }
   
  }

}
