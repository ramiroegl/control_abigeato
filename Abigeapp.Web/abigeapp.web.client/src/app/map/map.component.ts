import { Component, OnInit } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapCircle, MapPolygon } from '@angular/google-maps';
import { Coordenada, Finca, Perimetro } from '../models/finca';
import { HttpClient, HttpParams } from '@angular/common/http';
import { LoginService } from '../services/login.service';
import { Dispositivo, FincaConDispositivos } from '../models/dispositivo';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css',
  standalone: true,
  imports: [GoogleMap, MapAdvancedMarker, MapPolygon, MapCircle],
})
export class MapComponent implements OnInit {
  zoom: number = 20;
  finca: Finca | null = null;
  fincaConDispositivos: FincaConDispositivos | null = null;
  center: google.maps.LatLngLiteral = { lat: 0, lng: 0 };
  display?: google.maps.LatLngLiteral;

  constructor(private http: HttpClient, private loginService: LoginService) {
  }

  ngOnInit(): void {
    this.http.get<Finca>(`/api/fincas/${this.loginService.getSession()?.fincaId}`)
      .subscribe({
        next: (result) => {
          console.log('Obteniendo finca en mapa', result);
          this.finca = result;
          this.center = { lat: this.finca.latitud, lng: this.finca.longitud };
        },
        error: (error) => {
          console.error(error);
        }
      });

    let params = new HttpParams();
    params = params.append('fincaId', this.loginService.getSession()?.fincaId ?? '');
    params = params.append('pagina', 1);
    params = params.append('cantidad', 50);

    this.http.get<FincaConDispositivos>(`/api/dispositivos`, { params: params })
      .subscribe({
        next: (result) => {
          console.log('Obteniendo dispositivos en mapa', result);
          this.fincaConDispositivos = result;
        },
        error: (error) => {
          console.error(error);
        }
      });
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
      radius: this.zoom * 0.1,
      fillOpacity: 0.8,
      strokeOpacity: 0
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
