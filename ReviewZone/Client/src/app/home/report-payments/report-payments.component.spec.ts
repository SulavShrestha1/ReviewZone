import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReportPaymentsComponent } from './report-payments.component';

describe('ReportPaymentsComponent', () => {
  let component: ReportPaymentsComponent;
  let fixture: ComponentFixture<ReportPaymentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ReportPaymentsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ReportPaymentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
