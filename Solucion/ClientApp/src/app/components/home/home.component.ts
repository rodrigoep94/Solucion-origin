import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TarjetaService } from 'src/app/services/tarjeta.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  public errorMessage = "";

  constructor(private router: Router,
              private cookieService: CookieService,
              private tarjetaService: TarjetaService) { }

  ngOnInit() {
  }

  public manejarAceptar(numeroTarjeta: any): void {
    this.errorMessage = "";
    if (numeroTarjeta.length != 16) {
      this.errorMessage = "Debe ingresar un número de tarjeta válido";
      return;
    }

    this.tarjetaService.validarNumeroDeTarjeta(numeroTarjeta).subscribe(data => {
      this.cookieService.set('cardNumber', numeroTarjeta);
      this.router.navigate(['ingreso-pin']);
    }, error => {
      this.router.navigate(['error'], { state: { errorMessage: error.data, previousPage: 'home' } });
    })
  }

}
