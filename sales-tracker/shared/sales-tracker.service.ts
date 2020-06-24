import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { EmployeeDetail } from 'src/app/shared/employee-detail';
import { SalesHistory } from './sales-history.Model';
import { environment } from 'src/environments/environment';
import { NgxSpinnerService } from 'ngx-spinner';

@Injectable({
  providedIn: 'root'
})
export class SalesTrackerService {

  constructor(private http: HttpClient) { }

  baseUrl: string = environment.production ? "https://jungle-deployment.azurewebsites.net/api/employeedetail" : "https://localhost:44377/api/employeedetail";
  public employees: EmployeeDetail[];
  public employee: EmployeeDetail;
  salesHistories: SalesHistory[];
  salesHistory: SalesHistory[];
  employeeId: number = -1;
  firstName: string;
  lastName: string;
  department: string;
  title: string;
  status: string;
  rate: number;
  email: string;

  getEmployees(){
    this.http.get(this.baseUrl).toPromise().then(x => {
      this.employees = x as EmployeeDetail[];
    })
  }
  
  getSalesHistory(){
    this.http.get(this.baseUrl + '/saleshistory').toPromise().then(x => {
      this.salesHistories = x as SalesHistory[]; 
    })
  }
}
