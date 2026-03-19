import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConfidentialitateComponent } from './confidentialitate.component';

describe('ConfidentialitateComponent', () => {
  let component: ConfidentialitateComponent;
  let fixture: ComponentFixture<ConfidentialitateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConfidentialitateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConfidentialitateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
