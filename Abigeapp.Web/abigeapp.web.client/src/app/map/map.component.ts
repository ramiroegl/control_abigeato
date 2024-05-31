import { Component, Input, OnInit } from '@angular/core';
import { GoogleMap } from '@angular/google-maps';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css',
  standalone: true,
  imports: [GoogleMap],
})
export class MapComponent implements OnInit {
  @Input({ required: true }) lat!: number;
  @Input({ required: true }) lng!: number;
  @Input({ required: true }) zoom!: number;

  public center: google.maps.LatLngLiteral = { lat: 0, lng: 0 };
  display?: google.maps.LatLngLiteral;

  ngOnInit(): void {
    this.center = { lat: this.lat, lng: this.lng };
    console.log(this.center);
  }

  moveMap(event: any) {
    this.center = (event.latLng!.toJSON());
  }

  move(event: any) {
    this.display = event.latLng!.toJSON();
  }
}
