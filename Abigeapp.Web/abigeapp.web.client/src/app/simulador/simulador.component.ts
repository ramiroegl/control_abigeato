import { Component, Input, OnInit } from '@angular/core';
import { Dispositivo, DispositivoConPerimetro, Posicion } from '../models/dispositivo';
import { HttpClient } from '@angular/common/http';
import { GoogleMap, MapAdvancedMarker, MapMarker, MapPolygon } from '@angular/google-maps';
import { Coordenada, Perimetro } from '../models/finca';

@Component({
  selector: 'app-simulador',
  templateUrl: './simulador.component.html',
  styleUrl: './simulador.component.css',
  standalone: true,
  imports: [GoogleMap, MapPolygon, MapAdvancedMarker, MapMarker],
})
export class SimuladorComponent implements OnInit {
  @Input() id?: string;
  zoom: number = 20;
  posicion: google.maps.LatLngLiteral = { lat: 0, lng: 0 };
  dispositivo?: DispositivoConPerimetro;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    console.log(this.id);
    this.http.get<DispositivoConPerimetro>(`/api/dispositivos/${this.id}`)
      .subscribe({
        next: (result) => {
          this.dispositivo = result;
          this.posicion = { lat: this.dispositivo.latitud, lng: this.dispositivo.longitud };
        },
        error: (error) => {
          console.error(error);
          alert("Error al obtener datos del dispositivo");
        }
      });
  }

  convertirCoordenadas(coordenadas: Coordenada[]): google.maps.LatLngLiteral[] {
    let latLngLiterals = coordenadas.map(coordenada => <google.maps.LatLngLiteral>{ lat: coordenada.latitud, lng: coordenada.longitud });
    return latLngLiterals
  }

  obtenerOpcionesDelPerimetro(perimetro?: Perimetro): google.maps.PolygonOptions {
    const color: string = perimetro?.tipo == 'General' ? 'gray' : 'blue';
    const opacity: number = perimetro?.tipo == 'General' ? 0.3 : 0.1;
    return { fillColor: color, strokeColor: color, fillOpacity: opacity, strokeOpacity: opacity };
  }

  actualizarPosicion(event: google.maps.MapMouseEvent) {
    if (event.latLng) {

      let posicionClic: Posicion = {
        latitud: event.latLng.lat(),
        longitud: event.latLng.lng()
      };

      this.http.put<Dispositivo>(`/api/dispositivos/${this.id}/posicion`, posicionClic)
        .subscribe({
          next: (result) => {
            if (this.dispositivo) {
              this.dispositivo.estado = result.estado;
              this.dispositivo.latitud = result.latitud;
              this.dispositivo.longitud = result.longitud;
            }

            this.posicion = { lat: result.latitud, lng: result.longitud };
          },
          error: (error) => {
            console.error(error);
            alert("Error al actualizar datos del dispositivo");
          }
        });
    }
  }

  private getCircleColor(estado?: string): string {
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
