import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableDataSource } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { AccountsComponent } from './accounts/accounts.component';
import { AccountListComponent } from './account-list/account-list.component';
import { VouchersComponent } from './vouchers/vouchers.component';
import { PaymentsComponent } from './payments/payments.component';
import { InvoicesComponent } from './invoices/invoices.component';
import { OrderListComponent } from './order-list/order-list.component';
import { OrdersComponent } from './orders/orders.component';
import { ViewOrderComponent } from './view-order/view-order.component';
import { ProductsComponent } from './products/products.component';
import { ProductListComponent } from './product-list/product-list.component';
import { TasksComponent } from './tasks/tasks.component';
import { TaskListComponent } from './task-list/task-list.component';
import { EmployeesComponent } from './employees/employees.component';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { ReportInvoicesComponent } from './report-invoices/report-invoices.component';
import { ReportPaymentsComponent } from './report-payments/report-payments.component';
import { ReportForecastComponent } from './report-forecast/report-forecast.component';
import { EvaluatorComponent } from './evaluator/evaluator.component';
import { EvaluatorListComponent } from './evaluator-list/evaluator-list.component';
import { ViewCustomerComponent } from './view-customer/view-customer.component';
import { EditAccountComponent } from './edit-account/edit-account.component';
import { EditPaymentComponent } from './edit-payment/edit-payment.component';
import { EditProductComponent } from './edit-product/edit-product.component';
import { ViewEmployeeComponent } from './view-employee/view-employee.component';
import { ViewEvaluatorComponent } from './view-evaluator/view-evaluator.component';
import { EditTaskComponent } from './edit-task/edit-task.component';



@NgModule({
  declarations: [MatTableDataSource, AccountsComponent, AccountListComponent, VouchersComponent, PaymentsComponent, InvoicesComponent, OrderListComponent, OrdersComponent, ViewOrderComponent, ProductsComponent, ProductListComponent, TasksComponent, TaskListComponent, EmployeesComponent, EmployeeListComponent, ReportInvoicesComponent, ReportPaymentsComponent, ReportForecastComponent, EvaluatorComponent, EvaluatorListComponent, ViewCustomerComponent, EditAccountComponent, EditPaymentComponent, EditProductComponent, ViewEmployeeComponent, ViewEvaluatorComponent, EditTaskComponent],
  imports: [
    CommonModule,
    MatPaginatorModule,
  ]
})
export class HomeModule { }
