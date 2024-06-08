import { Component, OnDestroy, OnInit } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapCircle, MapPolygon } from '@angular/google-maps';
import { Coordenada, Finca, Perimetro } from '../models/finca';
import { HttpClient, HttpParams } from '@angular/common/http';
import { LoginService } from '../services/login.service';
import { Dispositivo, FincaConDispositivos } from '../models/dispositivo';
import { Subscription, interval, switchMap } from 'rxjs';
import { LoginResult } from '../models/loginResult';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css',
  standalone: true,
  imports: [GoogleMap, MapAdvancedMarker, MapPolygon, MapCircle],
})
export class MapComponent implements OnInit, OnDestroy {
  zoom: number = 20;
  center: google.maps.LatLngLiteral = { lat: 0, lng: 0 };
  private subscription: Subscription | null = null;
  session: LoginResult | null = null;
  finca: Finca | null = null;
  fincaConDispositivos: FincaConDispositivos | null = null;
  display?: google.maps.LatLngLiteral;

  constructor(private http: HttpClient, private loginService: LoginService) {
  }

  ngOnInit(): void {
    this.session = this.loginService.getSession();
    this.http.get<Finca>(`/api/fincas/${this.session?.fincaId}`)
      .subscribe({
        next: (result) => {
          this.finca = result;
          this.center = { lat: this.finca.latitud, lng: this.finca.longitud };
        },
        error: (error) => {
          alert("Error al obtener datos de la finca");
          console.error(error);
        }
      });

    let params = new HttpParams();
    params = params.append('fincaId', this.loginService.getSession()?.fincaId ?? '');
    params = params.append('pagina', 1);
    params = params.append('cantidad', 50);

    this.subscription = interval(5000).pipe(
      switchMap(() => this.http.get<FincaConDispositivos>(`/api/dispositivos`, { params: params }))
    ).subscribe({
      next: (result) => {
        this.fincaConDispositivos = result;
      },
      error: (error) => {
        console.error(error);
        alert("Error al obtener dispositivos");
      }
    });
  }

  ngOnDestroy(): void {
    if (this.subscription != null) {
      this.subscription.unsubscribe();
    }
  }

  move(event: any) {
    this.display = event.latLng!.toJSON();
  }

  convertirCoordenadas(coordenadas: Coordenada[]): google.maps.LatLngLiteral[] {
    let latLngLiterals = coordenadas.map(coordenada => <google.maps.LatLngLiteral>{ lat: coordenada.latitud, lng: coordenada.longitud });
    return latLngLiterals
  }

  obtenerOpcionesDelPerimetro(perimetro: Perimetro): google.maps.PolygonOptions {
    const color: string = perimetro.tipo == 'General' ? 'gray' : 'blue';
    const opacity: number = perimetro.tipo == 'General' ? 0.3 : 0.1;
    return { fillColor: color, strokeColor: color, fillOpacity: opacity, strokeOpacity: opacity };
  }

  obtenerOpcionesDelDispositivo(dispositivo: Dispositivo): google.maps.CircleOptions {
    return {
      center: { lat: dispositivo.latitud, lng: dispositivo.longitud },
      fillColor: this.getCircleColor(dispositivo.estado),
      strokeColor: this.getCircleColor(dispositivo.estado),
      radius: this.zoom * 0.3,
      fillOpacity: 0.2,
      strokeOpacity: 0.7
    };
  }

  private getCircleColor(estado: string): string {
    switch (estado) {
      case "Dentro":
        return "green";
      case "Fuera":
        return "red";
      default:
        return "gray";
    }
  }
}
