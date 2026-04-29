import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ReactiveContact } from './reactive-contact';

describe('ReactiveContact', () => {
  let component: ReactiveContact;
  let fixture: ComponentFixture<ReactiveContact>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveContact],
    }).compileComponents();

    fixture = TestBed.createComponent(ReactiveContact);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
