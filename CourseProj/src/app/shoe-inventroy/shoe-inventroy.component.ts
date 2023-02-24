import { Component } from '@angular/core';

import { HttpClient } from '@angular/common/http';
//will use the weatherforcast as a place holder
@Component({
  selector: 'app-shoe-inventroy',
  templateUrl: './shoe-inventroy.component.html',
  styleUrls: ['./shoe-inventroy.component.css']
})
export class ShoeInventroyComponent {
  //public inventory: ShoeInventory[] = [];
  public forecasts: WeatherForecast[] = [];
  baseUrl ='https://localhost:7213/';

  constructor(http: HttpClient){
    http.get<WeatherForecast[]>(this.baseUrl + 'weatherforecast').subscribe(result =>{
      this.forecasts = result;
    },error => console.error(error));
  }
}
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface ShoeInventory{
  brand:string;
  model:string;
  size:number;
  summary: string;
}