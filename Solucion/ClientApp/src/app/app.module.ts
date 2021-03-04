import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { ErrorComponent } from './components/error/error.component';
import { IngresoPinComponent } from './components/ingreso-pin/ingreso-pin.component';
import { OperacionesComponent } from './components/operaciones/operaciones.component';
import { BalanceComponent } from './components/balance/balance.component';
import { RetiroComponent } from './components/retiro/retiro.component';
import { ReporteOperacionComponent } from './components/reporte-operacion/reporte-operacion.component';
import { TecladoComponent } from './components/teclado/teclado.component'
import { TarjetaService } from './services/tarjeta.service';
import { RestangularModule } from 'ngx-restangular';
import { CookieService } from 'ngx-cookie-service'
import { ExtraccionService } from './services/extraccion.service';
export function RestangularConfigFactory(RestangularProvider) {
  RestangularProvider.setBaseUrl('https://localhost:44342/api/');
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    ErrorComponent,
    IngresoPinComponent,
    OperacionesComponent,
    BalanceComponent,
    RetiroComponent,
    ReporteOperacionComponent,
    TecladoComponent
  ],
  imports: [
    RestangularModule.forRoot(RestangularConfigFactory),
    NgxMaskModule.forRoot(),
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    CookieService,
    ExtraccionService,
    TarjetaService],
  bootstrap: [AppComponent]
})
export class AppModule { }
