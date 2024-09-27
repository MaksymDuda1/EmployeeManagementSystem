import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HireDaysComponent } from './hire-days.component';

describe('HireDaysComponent', () => {
  let component: HireDaysComponent;
  let fixture: ComponentFixture<HireDaysComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HireDaysComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HireDaysComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
