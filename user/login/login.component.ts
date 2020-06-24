import { Component, OnInit } from '@angular/core';
import { UserService } from '../shared/user.service';
import { ToastrService } from 'ngx-toastr';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styles: []
})
export class LoginComponent implements OnInit {

  constructor(public service: UserService, private router: Router, private toastr: ToastrService) { }

  formModel = {
    UserName: 'danc',
    Password: 'Anim@te1'
  }
  ngOnInit() {
    // if (localStorage.getItem('token') == null) {
    //   this.service.loggedIn = false;
    //   this.router.navigateByUrl('/home');
    // }
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/home');
        this.service.loggedIn = true;
      },
      err => {
        if (err.status == 400) {
          this.toastr.error('Incorrect Username or Password', 'Authentication Failed');
        }
        else {
          console.log(err);
        }
      }
    );
  }
}
