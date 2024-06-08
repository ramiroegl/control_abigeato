import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './map/map.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from './header/header.component';
import { LogoutComponent } from './logout/logout.component';
import { PerimetrosComponent } from './perimetros/perimetros.component';
import { DispositivosComponent } from './dispositivos/dispositivos.component';
import { RouterModule, withComponentInputBinding } from '@angular/router';
import { AlertasComponent } from './alertas/alertas.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    LoginComponent,
    HeaderComponent,
    LogoutComponent,
    PerimetrosComponent,
    DispositivosComponent,
    AlertasComponent
  ],
  imports: [
    BrowserModule, HttpClientModule,
    AppRoutingModule,
    MapComponent, ReactiveFormsModule,
    RouterModule.forRoot([], { bindToComponentInputs: true })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
