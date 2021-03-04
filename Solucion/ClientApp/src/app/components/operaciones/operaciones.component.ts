import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-operaciones',
  templateUrl: './operaciones.component.html',
  styleUrls: ['./operaciones.component.scss']
})
export class OperacionesComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  public salir(): void {
    //Eliminar dato tarjeta
    this.router.navigate(['home']);
  }

}
