import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { ExtraccionService } from 'src/app/services/extraccion.service';

@Component({
  selector: 'app-retiro',
  templateUrl: './retiro.component.html',
  styleUrls: ['./retiro.component.scss']
})
export class RetiroComponent implements OnInit {

  public errorMessage: string;
  constructor(private router: Router,
    private cookieService: CookieService,
    private extraccionService: ExtraccionService) { }

  ngOnInit() {
  }

  public manejarAceptar(ev: any) {
    this.errorMessage = null;
    if (ev.length == 0) {
      this.errorMessage = "Debe ingresar un monto a retirar";
      return;
    }

    let objExtraccion = {
      numeroTarjeta: this.cookieService.get("cardNumber"),
      monto: ev
    };

    this.extraccionService.extraer(objExtraccion).subscribe(data => {
      this.router.navigate(['reporte-operacion', data.id]);
    }, error => {
      console.log(error);
      this.router.navigate(['error'], { state: { errorMessage: error.data, previousPage: 'retiro' } });
    });
  }

  public salir() {
    this.cookieService.delete("cardNumber");
    this.router.navigate(['home']);
  }
}
