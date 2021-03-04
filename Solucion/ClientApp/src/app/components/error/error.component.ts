import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.scss']
})
export class ErrorComponent implements OnInit {

  constructor(private router: Router) {
    this.errorMessage = this.router.getCurrentNavigation().extras.state.errorMessage;
    this.previousPage = this.router.getCurrentNavigation().extras.state.previousPage;
  }

  public errorMessage: string;
  private previousPage: string;

  ngOnInit() {
  }

  public volver(): void {
    this.router.navigate([this.previousPage]);
  }

}
