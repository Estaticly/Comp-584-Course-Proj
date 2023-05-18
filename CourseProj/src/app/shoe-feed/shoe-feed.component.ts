import { Component, OnInit } from '@angular/core';
import { Brand } from './brand';
import { HttpClient } from '@angular/common/http';
import { environment } from '../environment/environment';

@Component({
  selector: 'app-shoe-feed',
  templateUrl: './shoe-feed.component.html',
  styleUrls: ['./shoe-feed.component.css']
})
export class ShoeFeedComponent implements OnInit{
  public brands!: Brand[];
  constructor(private http: HttpClient){}
  
  ngOnInit(): void {
    let url = environment.baseUrl+ 'api/Brands';
    this.http.get<Brand[]>(url).subscribe(result => {
      this.brands =result;
    });
  }
}
