import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<any>('/api/fincas/bd62482d-e78c-4605-9f9d-70811d856096')
      .subscribe({
        next: (result) => {
          console.log(result);
        },
        error: (error) => {
          console.error(error);
        }
      });
  }

  title = 'abigeapp.web.client';
}
