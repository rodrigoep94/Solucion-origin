import { Injectable } from '@angular/core';
import { Restangular } from 'ngx-restangular'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ExtraccionService {

  constructor(
    protected restangular: Restangular) { }

  public getExtraccion(idExtraccion: number): Observable<any> {
    let res = this.restangular.one('extraccion/' + idExtraccion).get();
    return res as Observable<any>;
  }

  public extraer(objExtraccion: any): Observable<any> {
    let res = this.restangular.all('extraccion/extraer').post(objExtraccion);
    return res as Observable<any>;
  }
}
