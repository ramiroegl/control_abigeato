import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AuthGuard } from './services/auth-guard';
import { LoginComponent } from './login/login.component';
import { LogoutComponent } from './logout/logout.component';
import { DispositivosComponent } from './dispositivos/dispositivos.component';
import { SimuladorComponent } from './simulador/simulador.component';
import { AlertasComponent } from './alertas/alertas.component';

const routes: Routes = [
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'home', component: HomeComponent, canActivate: [AuthGuard]},
  {path: 'dispositivos', component: DispositivosComponent, canActivate: [AuthGuard]},
  {path: 'dispositivos/:id/simular', component: SimuladorComponent, canActivate: [AuthGuard]},
  {path: 'alertas', component: AlertasComponent, canActivate: [AuthGuard]},
  {path: 'login', component: LoginComponent, canActivate: [AuthGuard]},
  {path: 'logout', component: LogoutComponent, canActivate: [AuthGuard]},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
