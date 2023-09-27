import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RegisterCookComponent } from './register-cook.component';

describe('RegisterCookComponent', () => {
  let component: RegisterCookComponent;
  let fixture: ComponentFixture<RegisterCookComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RegisterCookComponent]
    });
    fixture = TestBed.createComponent(RegisterCookComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
