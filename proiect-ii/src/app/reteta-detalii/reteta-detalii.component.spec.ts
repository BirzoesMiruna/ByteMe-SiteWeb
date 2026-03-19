import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RetetaDetaliiComponent } from './reteta-detalii.component';

describe('RetetaDetaliiComponent', () => {
  let component: RetetaDetaliiComponent;
  let fixture: ComponentFixture<RetetaDetaliiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RetetaDetaliiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RetetaDetaliiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
