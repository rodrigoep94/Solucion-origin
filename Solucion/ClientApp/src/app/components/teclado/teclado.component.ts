import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-teclado',
  templateUrl: './teclado.component.html',
  styleUrls: ['./teclado.component.scss']
})
export class TecladoComponent implements OnInit {

  @Input() placeholder: string;
  @Input() errorMessage: string;
  @Input() mask: string;
  @Output() onAceptar: EventEmitter<any> = new EventEmitter;

  public numberValue = "";

  constructor() { }

  ngOnInit() {
  }

  public apretar(valor: string): void {
    switch (valor) {
      case "Aceptar": {
        this.onAceptar.emit(this.numberValue);
        break;
      }
      case "Limpiar": {
        this.numberValue = "";
        break;
      }
      default: {
        this.numberValue = this.numberValue.concat(valor);
      }
    }
  }

}
