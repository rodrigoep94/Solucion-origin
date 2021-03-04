import { Injectable } from '@angular/core';
import { Restangular } from 'ngx-restangular'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TarjetaService {

  constructor(
    protected restangular: Restangular) { }

  public validarNumeroDeTarjeta(numeroTarjeta: string): Observable<any> {
    let res = this.restangular.one('tarjetas/validarExistenciaTarjeta/' + numeroTarjeta).get();
    return res as Observable<any>;
  }

  public validarPin(objValidar: any): Observable<any> {
    let res = this.restangular.all('tarjetas/validarPin').post(objValidar);
    return res as Observable<any>;
  }

  public bloquearTarjeta(numeroTarjeta: string): Observable<any> {
    let res = this.restangular.all('tarjetas/bloquearTarjeta/' + numeroTarjeta).patch();
    return res as Observable<any>;
  }

  public obtenerBalance(numeroTarjeta: string): Observable<any> {
    let res = this.restangular.one('tarjetas/obtenerBalance/' + numeroTarjeta).get();
    return res as Observable<any>;
  }
}
