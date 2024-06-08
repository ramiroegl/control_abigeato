import { Component, OnInit } from '@angular/core';
import { Alerta } from '../models/dispositivo';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Coordenada, FincaConAlertas } from '../models/finca';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-alertas',
  templateUrl: './alertas.component.html',
  styleUrl: './alertas.component.css'
})
export class AlertasComponent implements OnInit {
  alertas: Alerta[] = [];

  constructor(private http: HttpClient, private loginService: LoginService) { }

  ngOnInit(): void {
    let params = new HttpParams();
    params = params.append('pagina', 1);
    params = params.append('cantidad', 20);
    this.http.get<FincaConAlertas>(`/api/fincas/${this.loginService.getSession()?.fincaId}/alertas`, { params: params })
      .subscribe({
        next: (result) => {
          this.alertas = result.alertas;
        },
        error: (error) => {
          console.error(error);
          alert("Error al obtener alertas");
        }
      });
  }

  leer(id: string): void {
    this.http.put(`/api/alertas/${id}/leer`, {})
      .subscribe({
        next: () => {
          this.alertas.map(alerta => {
            if (alerta.id == id) {
              alerta.estado = 'Resuelta';
            }
          })
        },
        error: (error) => {
          console.error(error);
          alert("Error al obtener alertas");
        }
      });
  }
}
