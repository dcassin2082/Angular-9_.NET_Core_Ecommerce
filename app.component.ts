import { Component, OnInit } from '@angular/core';
import { Router, NavigationStart, NavigationEnd } from '@angular/router';
import { Location, PopStateEvent } from "@angular/common";
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'NgClient';

  constructor(private router: Router, private location: Location) { }

  private lastPoppedUrl: string;
  private yScrollStack: number[] = [];
  imageUrl: string;
  
  ngOnInit() {
    this.location.subscribe((ev: PopStateEvent) => {
      this.lastPoppedUrl = ev.url;
    });
    this.router.events.subscribe((ev: any) => {
      if (ev instanceof NavigationStart) {
        if (ev.url != this.lastPoppedUrl)
          this.yScrollStack.push(window.scrollY);
      } else if (ev instanceof NavigationEnd) {
        if (ev.url == this.lastPoppedUrl) {
          this.lastPoppedUrl = undefined;
          window.scrollTo(0, this.yScrollStack.pop());
        } else
          window.scrollTo(0, 0);
      }
    });
  }
  
  getMode() {
    if (environment.production) {
      this.imageUrl = 'http://dcassin234-001-site1.ctempurl.com/assets/images/pexels-photo-4177562.jpeg"';
    }
    else {
      this.imageUrl = "../../assets/img/pexels-photo-4177562.jpeg";
    }
  }
}
