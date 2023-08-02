import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CatlistComponent } from './catlist.component';

describe('CatlistComponent', () => {
  let component: CatlistComponent;
  let fixture: ComponentFixture<CatlistComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CatlistComponent]
    });
    fixture = TestBed.createComponent(CatlistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
