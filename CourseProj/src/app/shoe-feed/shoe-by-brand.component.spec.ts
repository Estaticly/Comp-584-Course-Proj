import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoeByBrandComponent } from './shoe-by-brand.component';

describe('ShoeByBrandComponent', () => {
  let component: ShoeByBrandComponent;
  let fixture: ComponentFixture<ShoeByBrandComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoeByBrandComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoeByBrandComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
