import { Component, OnInit } from '@angular/core';
import { LoginService } from '../services/login.service';
import { HttpClient } from '@angular/common/http';
import { Finca } from '../models/finca';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent implements OnInit {
  finca: Finca = {id: '', latitud: 0, longitud: 0, perimetros: []}

  constructor(private loginService: LoginService, private http: HttpClient) {
  }
  ngOnInit(): void {
    var session = this.loginService.getSession();
    this.http.get<Finca>(`/api/fincas/${session?.fincaId}`)
      .subscribe({
        next: (result) => {
          console.log(result);
          this.finca = result;
        },
        error: (error) => {
          console.error(error);
        }
      });
  }
}
