import { Component, OnInit } from '@angular/core';
import { Shoe } from './shoe';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { environment } from '../environment/environment';

@Component({
  selector: 'app-shoe-by-brand',
  templateUrl: './shoe-by-brand.component.html',
  styleUrls: ['./shoe-by-brand.component.css']
})
export class ShoeByBrandComponent implements OnInit{
  
  shoes?: Shoe[];
  brand?: string;
  constructor(private http: HttpClient, private activatedRoute: ActivatedRoute){}

  ngOnInit(): void {
    let idParam = this.activatedRoute.snapshot.paramMap.get('id');
    let url= environment.baseUrl + `api/Shoes/ShoeByBrand/${idParam}`;
    this.http.get<Shoe[]>(url).subscribe(result => {
      this.shoes = result;
      this.brand = this.shoes[0].brand;
    });
  }

}
