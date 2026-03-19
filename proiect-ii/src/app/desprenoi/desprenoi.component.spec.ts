import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DesprenoiComponent } from './desprenoi.component';

describe('DesprenoiComponent', () => {
  let component: DesprenoiComponent;
  let fixture: ComponentFixture<DesprenoiComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DesprenoiComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DesprenoiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
