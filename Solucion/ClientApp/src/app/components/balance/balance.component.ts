import { Component, OnInit } from '@angular/core';
import { BalanceCuentaModel } from 'src/app/model/balanceCuentaModel';
import { Router } from '@angular/router';
import { TarjetaService } from 'src/app/services/tarjeta.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-balance',
  templateUrl: './balance.component.html',
  styleUrls: ['./balance.component.scss']
})
export class BalanceComponent implements OnInit {

  public model: BalanceCuentaModel = new BalanceCuentaModel();
  public fechaFormateada: string;

  constructor(private router: Router,
              private cookieService: CookieService,
              private tarjetaService: TarjetaService) { }

  ngOnInit() {
    this.obtenerBalance();
  }

  private obtenerBalance() {
    let numeroTarjeta = this.cookieService.get("cardNumber");
    this.tarjetaService.obtenerBalance(numeroTarjeta).subscribe(data => {
      this.model = data;
      let fecha = this.model.fechaVencimiento.toString();
      this.fechaFormateada = fecha.substr(8, 2) + "/" + fecha.substr(5, 2) + "/" + fecha.substr(0, 4);
    });
  }

  public salir(): void {
    this.cookieService.delete("cardNumber");
    this.router.navigate(['home']);
  }

}
