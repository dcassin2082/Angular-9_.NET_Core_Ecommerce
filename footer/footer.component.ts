import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styles: []
})
export class FooterComponent implements OnInit {

  constructor() { }

  year: number;

  ngOnInit() {
    var dt = new Date();
    this.year =  dt.getFullYear();
  }
}
