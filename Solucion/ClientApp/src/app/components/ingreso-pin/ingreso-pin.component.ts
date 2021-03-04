import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TecladoComponent } from '../teclado/teclado.component';
import { CookieService } from 'ngx-cookie-service';
import { TarjetaService } from 'src/app/services/tarjeta.service';

@Component({
  selector: 'app-ingreso-pin',
  templateUrl: './ingreso-pin.component.html',
  styleUrls: ['./ingreso-pin.component.scss']
})
export class IngresoPinComponent implements OnInit {

  public errorMessage: string;
  public intentosRestantes = 4;

  @ViewChild(TecladoComponent, null) teclado: TecladoComponent;

  constructor(private router: Router,
              private tarjetaService: TarjetaService,
              private cookieService: CookieService) { }

  ngOnInit() {
  }

  public manejarAceptar(ev: any) {
    this.errorMessage = null;

    let objValidacion = {
      numeroTarjeta: this.cookieService.get('cardNumber'),
      numeroPin: ev
    }

    this.tarjetaService.validarPin(objValidacion).subscribe(data => {
      this.router.navigate(['operaciones']);
    }, error => {
      this.manejarPinInvalido();
    });
  }

  public salir(): void {
    this.cookieService.delete('cardNumber');
    this.router.navigate(['home']);
  }

  private manejarPinInvalido(): void {
    this.errorMessage = null;
    if (this.intentosRestantes == 1) {
      this.bloquearTarjeta();
    } else {
      this.errorMessage = "El pin ingresado es incorrecto"
      this.intentosRestantes -= 1;
      this.teclado.numberValue = "";
    }
  }

  private bloquearTarjeta(): void {
    let numeroTarjeta = this.cookieService.get("cardNumber");
    this.tarjetaService.bloquearTarjeta(numeroTarjeta).subscribe(data => {
      this.router.navigate(['error'], { state: { errorMessage: 'La tarjeta ha sido bloqueada.', previousPage: 'home' } });
    });
  }

}
