import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user/shared/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
})
export class HomeComponent implements OnInit {

  constructor(private router: Router, public service: UserService) { }

  div1: string = "../../assets/img/pexels-photo-1578248.jpeg";
  div2:string = "../../assets/img/pexels-photo-2680270.jpeg";
  div3:string = "../../assets/img/pexels-photo-924824.jpeg";
  divtools: string = "../../assets/img/pexels-photo-3062948.jpeg";

  ngOnInit() { 
  }

  onLogout(){
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
  }
}