import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatmashComponent } from './catmash.component';

describe('CatmashComponent', () => {
  let component: CatmashComponent;
  let fixture: ComponentFixture<CatmashComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CatmashComponent]
    });
    fixture = TestBed.createComponent(CatmashComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
