import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ContulMeuComponent } from './contul-meu.component';

describe('ContulMeuComponent', () => {
  let component: ContulMeuComponent;
  let fixture: ComponentFixture<ContulMeuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ContulMeuComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ContulMeuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
