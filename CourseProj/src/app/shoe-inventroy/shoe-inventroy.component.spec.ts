import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoeInventroyComponent } from './shoe-inventroy.component';

describe('ShoeInventroyComponent', () => {
  let component: ShoeInventroyComponent;
  let fixture: ComponentFixture<ShoeInventroyComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoeInventroyComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoeInventroyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
