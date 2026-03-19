import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TermeniComponent } from './termeni.component';

describe('TermeniComponent', () => {
  let component: TermeniComponent;
  let fixture: ComponentFixture<TermeniComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TermeniComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TermeniComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
