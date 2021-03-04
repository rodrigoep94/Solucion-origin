import { Component, OnInit } from '@angular/core';
import { OperacionRetiroModel } from 'src/app/model/operacionRetiroModel';
import { ActivatedRoute, Router } from '@angular/router';
import { ExtraccionService } from 'src/app/services/extraccion.service';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-reporte-operacion',
  templateUrl: './reporte-operacion.component.html',
  styleUrls: ['./reporte-operacion.component.scss']
})
export class ReporteOperacionComponent implements OnInit {

  public model: OperacionRetiroModel = new OperacionRetiroModel();
  public fechaFormateada: string;

  constructor(private activatedRoute: ActivatedRoute,
              private router: Router,
              private cookieService: CookieService,
              private extraccionService: ExtraccionService) { }

  ngOnInit() {
    this.activatedRoute.params.subscribe(p => {

      this.extraccionService.getExtraccion(p.idBalance).subscribe(data => {
        console.log(data);
        this.model.balanceCuenta = data.tarjeta.monto;
        this.model.cantidadRetirada = data.monto;
        this.model.numeroTarjeta = data.tarjeta.numero;
        //2021-03-03T17:50:47.7152386
        let fecha = data.fechaRetiro;
        this.fechaFormateada = fecha.substr(8, 2) + "/" + fecha.substr(5, 2) + "/" + fecha.substr(0, 4) + "-" + fecha.substr(11,5);
      });
    })
  }

  public salir() {
    this.cookieService.delete("cardNumber");
    this.router.navigate(['home']);
  }

}
