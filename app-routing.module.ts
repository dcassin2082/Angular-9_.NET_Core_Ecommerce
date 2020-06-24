import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { EmployeesComponent } from './employees/employees.component';
import { CustomersComponent } from './customers/customers.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './auth/auth.guard';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { LineSeriesChartComponent } from './line-series-chart/line-series-chart.component';
import { ColumnChartComponent } from './column-chart/column-chart.component';
import { TrackballChartComponent } from './trackball-chart/trackball-chart.component';
import { AllChartsComponent } from './all-charts/all-charts.component';
import { FunnelChartComponent } from './funnel-chart/funnel-chart.component';
import { PieChartComponent } from './pie-chart/pie-chart.component';
import { DoughnutChartComponent } from './doughnut-chart/doughnut-chart.component';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerComponent } from './customers/customer/customer.component';
import { ProductsComponent } from './products/products.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { SalesTrackerComponent } from './sales-tracker/sales-tracker.component';
import { DeveloperComponent } from './developer/developer.component';
import { AreaChartComponent } from './area-chart/area-chart.component';
import { DevQuizComponent } from './dev-quiz/dev-quiz.component';
import { AboutComponent } from './about/about.component';
import { SkillsComponent } from './skills/skills.component';
import { SsrsComponent } from './ssrs/ssrs.component';

const routes: Routes = [
  // { path: '', redirectTo: '/user/login', pathMatch: 'full' },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'column', component: ColumnChartComponent },
  { path: 'line-series', component: LineSeriesChartComponent },
  { path: 'trackball', component: TrackballChartComponent },
  { path: 'all-charts', component: AllChartsComponent },
  { path: 'multiple', component: FunnelChartComponent },
  // { path: 'resetpassword', component: ResetPasswordComponent },
  // { path: 'contacts', component: ContactsComponent },
  // { path: 'companies', component: CompaniesComponent },
  { path: 'customers', component: CustomersComponent },
  { path: 'employees', component: EmployeesComponent },
  { path: 'forbidden', component: ForbiddenComponent },
  { path: 'pie', component: PieChartComponent },
  { path: 'doughnut', component: DoughnutChartComponent },
  { path: 'products', component: ProductsComponent },
  { path: 'shopping-cart', component: ShoppingCartComponent },
  { path: 'checkout', component: CheckoutComponent },
  { path: 'sales-tracker', component: SalesTrackerComponent },
  { path: 'developer', component: DeveloperComponent },
  { path: 'area', component: AreaChartComponent },
  { path: 'devquiz', component: DevQuizComponent },
  { path: 'developer', component: DeveloperComponent },
  { path: 'about', component: AboutComponent },
  { path: 'skills', component: SkillsComponent },
  { path: 'ssrs', component: SsrsComponent },
  // {
  //   path: 'adminpanel', component: AdminPanelComponent, canActivate: [AuthGuard],
  //   data:
  //   {
  //     permittedRoles: ['Admin']
  //   }
  // },
  { path: 'home', component: HomeComponent },
  // { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
  {
    path: 'user', component: UserComponent,
    children: [
      { path: 'register', component: RegisterComponent },
      { path: 'login', component: LoginComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, {onSameUrlNavigation: 'reload'})],
  exports: [RouterModule]
})
export class AppRoutingModule { }
