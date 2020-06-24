import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA  } from '@angular/core';

import { RouterModule } from '@angular/router';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { ToastrModule } from 'ngx-toastr';
import { NgxPaginationModule } from 'ngx-pagination';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeListComponent } from './employees/employee-list/employee-list.component';
import { EmployeeComponent } from './employees/employee/employee.component';
import { CustomersComponent } from './customers/customers.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerComponent } from './customers/customer/customer.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegisterComponent } from './user/register/register.component';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';
import { ForbiddenComponent } from './forbidden/forbidden.component';
import { FooterComponent } from './footer/footer.component';
import { UserService } from './user/shared/user.service';
import { AuthInterceptor } from './auth/auth.interceptor';

// sync fusion ***************************************************************
import { ChartModule, DataLabel, DataLabelSettings } from '@syncfusion/ej2-angular-charts';
import {
  AreaSeriesService, BarSeriesService, RangeAreaSeriesService, StepAreaSeriesService, StackingAreaSeriesService, MultiColoredAreaSeriesService,
  CategoryService, DateTimeService, ScrollBarService, ColumnSeriesService, ChartAnnotationService, RangeColumnSeriesService, StackingColumnSeriesService, LegendService, TooltipService
} from '@syncfusion/ej2-angular-charts';

import { DataLabelService, LineSeriesService } from '@syncfusion/ej2-angular-charts';
import { LineSeriesChartComponent } from './line-series-chart/line-series-chart.component';
import { TrackballChartComponent } from './trackball-chart/trackball-chart.component';
import { ColumnChartComponent } from './column-chart/column-chart.component';
import { AllChartsComponent } from './all-charts/all-charts.component';
import { FunnelChartComponent } from './funnel-chart/funnel-chart.component';
import { AccumulationChartModule } from '@syncfusion/ej2-angular-charts';
import { FunnelSeriesService } from '@syncfusion/ej2-angular-charts';
import { PieChartComponent } from './pie-chart/pie-chart.component';
import {
  PieSeriesService, AccumulationLegendService, AccumulationTooltipService, AccumulationAnnotationService,
  AccumulationDataLabelService
} from '@syncfusion/ej2-angular-charts';
import { DoughnutChartComponent } from './doughnut-chart/doughnut-chart.component';
import { DoughnutChartDemoComponent } from './doughnut-chart-demo/doughnut-chart-demo.component';
import { PieChartDemoComponent } from './pie-chart-demo/pie-chart-demo.component';
import { CustomerOrdersComponent } from './customer-orders/customer-orders.component';
import { CustomerApiComponent } from './customer-api/customer-api.component';
import { ProductsComponent } from './products/products.component';
import { ShoppingCartComponent } from './shopping-cart/shopping-cart.component';
import { CheckoutComponent } from './checkout/checkout.component';

import { NgxMaskModule, IConfig } from 'ngx-mask'
export const options: Partial<IConfig> | (() => Partial<IConfig>) = {};

import { ValidatorModule } from './shared/validator.module';

// import { TooltipModule } from 'ng2-tooltip-directive';
import { SalesTrackerComponent } from './sales-tracker/sales-tracker.component';
import { DeveloperComponent } from './developer/developer.component';
import { MultiColumnComponent } from './multi-column/multi-column.component';
import { AreaChartComponent } from './area-chart/area-chart.component';
import { DevQuizComponent } from './dev-quiz/dev-quiz.component';
import { FilterPipe } from './shared/filter-pipe';

import { NgxSpinnerModule } from 'ngx-spinner';
import { AboutComponent } from './about/about.component';
import { SkillsComponent } from './skills/skills.component';
import { SsrsComponent } from './ssrs/ssrs.component'

// *************************************************************************

/* React */

/* *********************************** */

@NgModule({
  declarations: [
    AppComponent,
    EmployeesComponent,
    EmployeeListComponent,
    EmployeeComponent,
    CustomersComponent,
    CustomerListComponent,
    CustomerComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    HeaderComponent,
    HomeComponent,
    ForbiddenComponent,
    FooterComponent,
    LineSeriesChartComponent,
    TrackballChartComponent,
    ColumnChartComponent,
    AllChartsComponent,
    FunnelChartComponent,
    PieChartComponent,
    DoughnutChartComponent,
    DoughnutChartDemoComponent,
    PieChartDemoComponent,
    CustomerOrdersComponent,
    CustomerApiComponent,
    ProductsComponent,
    ShoppingCartComponent,
    CheckoutComponent,
    SalesTrackerComponent,
    DeveloperComponent,
    MultiColumnComponent,
    AreaChartComponent,
    DevQuizComponent,
    FilterPipe,
    AboutComponent,
    SkillsComponent,
    SsrsComponent,
  ],
  imports: [
    BrowserModule,
    AccumulationChartModule,
    AppRoutingModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    NgxPaginationModule,
    Ng2SearchPipeModule,
    Ng2OrderModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule,
    ToastrModule.forRoot({
      progressBar: true
    }),
    ChartModule,
    NgxMaskModule.forRoot(options),
    ValidatorModule,
    NgxSpinnerModule
    // TooltipModule
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA],
  providers: [
    // UserService,
    // {
    //   provide: HTTP_INTERCEPTORS,
    //   useClass: AuthInterceptor,
    //   multi: true
    // },
    AreaSeriesService, BarSeriesService, RangeAreaSeriesService, StepAreaSeriesService, StackingAreaSeriesService, MultiColoredAreaSeriesService,
    CategoryService, DataLabelService, DateTimeService, ScrollBarService, LineSeriesService, ColumnSeriesService, ChartAnnotationService, FunnelSeriesService,
    RangeColumnSeriesService, StackingColumnSeriesService, LegendService, TooltipService, FunnelSeriesService, AccumulationTooltipService, AccumulationDataLabelService,
    PieSeriesService, AccumulationLegendService, AccumulationAnnotationService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
