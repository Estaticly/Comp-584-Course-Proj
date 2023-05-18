import { Component, OnInit } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { environment } from '../environment/environment';
import { Brand } from '../shoe-feed/brand';
import { FormControl, FormGroup } from '@angular/forms';
import { Shoe } from '../shoe-feed/shoe';
import { Router } from '@angular/router';
//will use the weatherforcast as a place holder
@Component({
  selector: 'app-shoe-inventroy',
  templateUrl: './shoe-inventroy.component.html',
  styleUrls: ['./shoe-inventroy.component.css']
})
export class ShoeInventroyComponent implements OnInit{
  brands?: Brand[];
  
  form!: FormGroup;
  constructor(private http: HttpClient, private router: Router){}

  ngOnInit(): void {
    this.form = new FormGroup({
      brand: new FormControl(''),
      model: new FormControl(''),
      size: new FormControl(''),
      price: new FormControl(''),
    });
    this.loadData();
  }

  loadData(): void{
    let url = environment.baseUrl+ 'api/Brands';
    this.http.get<Brand[]>(url).subscribe(result => {
      this.brands =result;
    });
  }

  onSubmit(){
    var shoe = <Shoe>{
      brand: this.form.controls['brand'].value,
      model: this.form.controls['model'].value,
      size: this.form.controls['size'].value,
      price: this.form.controls['price'].value
    };

    let url = environment.baseUrl+'api/Shoes';
    this.http.post<Shoe>(url,shoe).subscribe({
      next: () => {
        console.log("New Show added");
        this.router.navigate(['/shoe-feed']);
      }
    })
  }
}
