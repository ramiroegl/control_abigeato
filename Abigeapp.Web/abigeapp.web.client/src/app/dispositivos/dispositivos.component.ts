import { HttpClient, HttpParams } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Dispositivo, FincaConDispositivos } from '../models/dispositivo';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-dispositivos',
  templateUrl: './dispositivos.component.html',
  styleUrl: './dispositivos.component.css'
})
export class DispositivosComponent implements OnInit {
  dispositivos: Dispositivo[] = [];
  constructor(private http: HttpClient, private loginService: LoginService) {
  }

  ngOnInit(): void {
    let params = new HttpParams();
    params = params.append('fincaId', this.loginService.getSession()?.fincaId ?? '');
    params = params.append('pagina', 1);
    params = params.append('cantidad', 50);
    this.http.get<FincaConDispositivos>(`/api/dispositivos`, { params: params })
    .subscribe({
      next: (result) => {
        this.dispositivos = result.dispositivos;
      },
      error: (error) => {
        console.error(error);
        alert("Error al obtener dispositivos");
      }
    })
  }
}
