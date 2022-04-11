import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportForecastComponent } from './report-forecast.component';

describe('ReportForecastComponent', () => {
  let component: ReportForecastComponent;
  let fixture: ComponentFixture<ReportForecastComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportForecastComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportForecastComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
