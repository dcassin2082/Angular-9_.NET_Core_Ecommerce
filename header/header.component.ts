import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user/shared/user.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router, public userService: UserService) { }

  imageUrl: string;

  ngOnInit() {
    // this.imageUrl = "../../assets/img/pexels-photo-4177562.jpeg";
    // this.imageUrl = "../../assets/img/pexels-photo-1578248.jpeg";
    this.imageUrl = "../../assets/img/pexels-photo-3663314.jpeg"; 
  }

  login(){
    this.router.navigate(['/user/login']);
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    this.userService.loggedIn = false;
  }
}
