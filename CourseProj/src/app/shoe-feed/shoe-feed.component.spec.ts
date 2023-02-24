import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShoeFeedComponent } from './shoe-feed.component';

describe('ShoeFeedComponent', () => {
  let component: ShoeFeedComponent;
  let fixture: ComponentFixture<ShoeFeedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ShoeFeedComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShoeFeedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
