import { Component, Input, OnInit } from '@angular/core';
import { GoogleMap, MapAdvancedMarker, MapPolygon } from '@angular/google-maps';
import { Coordenada, Perimetro } from '../models/finca';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css',
  standalone: true,
  imports: [GoogleMap, MapAdvancedMarker, MapPolygon],
})
export class MapComponent implements OnInit {
  @Input({ required: true }) perimetros!: Perimetro[];
  @Input({ required: true }) lat!: number;
  @Input({ required: true }) lng!: number;
  @Input({ required: true }) zoom!: number;

  public center: google.maps.LatLngLiteral = { lat: 0, lng: 0 };
  display?: google.maps.LatLngLiteral;

  ngOnInit(): void {
    console.log(this.perimetros);
    this.center = { lat: this.lat, lng: this.lng };
  }

  move(event: any) {
    this.display = event.latLng!.toJSON();
  }

  convertirCoordenadas(coordenadas: Coordenada[]): google.maps.LatLngLiteral[] {
    let latLngLiterals = coordenadas.map(coordenada => <google.maps.LatLngLiteral>{ lat: coordenada.latitud, lng: coordenada.longitud });
    console.log(latLngLiterals);
    return latLngLiterals
  }
}
