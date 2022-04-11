import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { SidenavComponent } from './sidenav/sidenav.component';
import { HomeComponent } from './home/home.component';
import { AppComponent } from './app.component';
import { CustomersComponent } from './home/customers/customers.component';
import { CustomerListComponent } from './home/customer-list/customer-list.component';
import { AccountsComponent } from './home/accounts/accounts.component';
import { AccountListComponent } from './home/account-list/account-list.component';
import { VouchersComponent } from './home/vouchers/vouchers.component';
import { LoginComponent } from './login/login.component';
import { PaymentsComponent } from './home/payments/payments.component';
import { InvoicesComponent } from './home/invoices/invoices.component';
import { NewInvoiceComponent } from './home/new-invoice/new-invoice.component';
import { OrderListComponent } from './home/order-list/order-list.component';
import { OrdersComponent } from './home/orders/orders.component';
import { ViewOrderComponent } from './home/view-order/view-order.component';
import { ProductsComponent } from './home/products/products.component';
import { ProductListComponent } from './home/product-list/product-list.component';
import { TasksComponent } from './home/tasks/tasks.component';
import { TaskListComponent } from './home/task-list/task-list.component';
import { EmployeesComponent } from './home/employees/employees.component';
import { EmployeeListComponent } from './home/employee-list/employee-list.component';
import { ChangePasswordComponent } from './header/change-password/change-password.component';
import { EditProfileComponent } from './header/edit-profile/edit-profile.component';
import { ReportInvoicesComponent } from './home/report-invoices/report-invoices.component';
import { ReportPaymentsComponent } from './home/report-payments/report-payments.component';
import { ReportForecastComponent } from './home/report-forecast/report-forecast.component';
import { EvaluatorComponent } from './home/evaluator/evaluator.component';
import { EvaluatorListComponent } from './home/evaluator-list/evaluator-list.component';
import { ViewCustomerComponent } from './home/view-customer/view-customer.component';
import { EditAccountComponent } from './home/edit-account/edit-account.component';
import { EditPaymentComponent } from './home/edit-payment/edit-payment.component';
import { EditProductComponent } from './home/edit-product/edit-product.component';
import { ViewEmployeeComponent } from './home/view-employee/view-employee.component';
import { ViewEvaluatorComponent } from './home/view-evaluator/view-evaluator.component';
import { EditTaskComponent } from './home/edit-task/edit-task.component';

const routes: Routes = [
  { path: '', redirectTo: 'Home', pathMatch: 'full'},
  { path: 'App', component: AppComponent},
  { path: 'Home', component: HomeComponent},
  { path: 'Header', component: HeaderComponent},
  { path: 'Sidenav', component: SidenavComponent},
  { path: 'Customers', component: CustomersComponent},
  { path: 'CustomerList', component: CustomerListComponent},
  { path: 'Accounts', component: AccountsComponent},
  { path: 'AccountList', component: AccountListComponent},
  { path: 'Vouchers', component: VouchersComponent},
  { path: 'Login', component: LoginComponent},
  { path: 'Payments', component: PaymentsComponent},
  { path: 'Invoices', component: InvoicesComponent},
  { path: 'NewInvoice', component: NewInvoiceComponent},
  { path: 'Orders', component: OrdersComponent},
  { path: 'OrderList', component: OrderListComponent},
  { path: 'ViewOrder', component: ViewOrderComponent},
  { path: 'Products', component: ProductsComponent},
  { path: 'ProductList', component: ProductListComponent},
  { path: 'Tasks', component: TasksComponent},
  { path: 'TaskList', component: TaskListComponent},
  { path: 'Employees', component: EmployeesComponent},
  { path: 'EmployeeList', component: EmployeeListComponent },
  { path: 'Evaluator', component: EvaluatorComponent },
  { path: 'EvaluatorList', component: EvaluatorListComponent },
  { path: 'ChangePassword', component: ChangePasswordComponent},
  { path: 'EditProfile', component: EditProfileComponent},
  { path: 'ReportInvoices', component: ReportInvoicesComponent},
  { path: 'ReportPayments', component: ReportPaymentsComponent},
  { path: 'ReportForecast', component: ReportForecastComponent},
  { path: 'ViewCustomer', component: ViewCustomerComponent},
  { path: 'EditAccount', component: EditAccountComponent},
  { path: 'EditPayment', component: EditPaymentComponent},
  { path: 'EditProduct', component: EditProductComponent},
  { path: 'EditTask', component: EditTaskComponent},
  { path: 'ViewEmployee', component: ViewEmployeeComponent},
  { path: 'ViewEvaluator', component: ViewEvaluatorComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
export const routingComponents = [AppComponent, HomeComponent, HeaderComponent, SidenavComponent, CustomersComponent, CustomerListComponent, AccountsComponent, AccountListComponent, VouchersComponent, LoginComponent, PaymentsComponent, InvoicesComponent, NewInvoiceComponent, OrdersComponent, OrderListComponent, ViewOrderComponent, ProductsComponent, ProductListComponent, TasksComponent, TaskListComponent, EmployeesComponent, EmployeeListComponent, ChangePasswordComponent, EditProfileComponent, ReportInvoicesComponent, ReportPaymentsComponent, ReportForecastComponent, EvaluatorComponent, EvaluatorListComponent, ViewCustomerComponent, EditAccountComponent, EditPaymentComponent, EditProductComponent, ViewEmployeeComponent, ViewEvaluatorComponent, EditTaskComponent]
