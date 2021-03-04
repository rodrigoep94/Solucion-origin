import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ErrorComponent } from './components/error/error.component';
import { IngresoPinComponent } from './components/ingreso-pin/ingreso-pin.component';
import { OperacionesComponent } from './components/operaciones/operaciones.component';
import { ReporteOperacionComponent } from './components/reporte-operacion/reporte-operacion.component';
import { RetiroComponent } from './components/retiro/retiro.component';
import { TecladoComponent } from './components/teclado/teclado.component';
import { BalanceComponent } from './components/balance/balance.component';

const routes: Routes = [
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: 'home', component: HomeComponent },
  { path: 'error', component: ErrorComponent },
  { path: 'ingreso-pin', component: IngresoPinComponent },
  { path: 'operaciones', component: OperacionesComponent },
  { path: 'retiro', component: RetiroComponent },
  { path: 'balance', component: BalanceComponent },
  { path: 'reporte-operacion/:idBalance', component: ReporteOperacionComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
