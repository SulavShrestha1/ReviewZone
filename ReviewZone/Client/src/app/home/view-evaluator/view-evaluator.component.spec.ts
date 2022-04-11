import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewEvaluatorComponent } from './view-evaluator.component';

describe('ViewEvaluatorComponent', () => {
  let component: ViewEvaluatorComponent;
  let fixture: ComponentFixture<ViewEvaluatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ViewEvaluatorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewEvaluatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
