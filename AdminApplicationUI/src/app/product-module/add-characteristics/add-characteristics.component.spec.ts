import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCharacteristicsComponent } from './add-characteristics.component';

describe('AddCharacteristicsComponent', () => {
  let component: AddCharacteristicsComponent;
  let fixture: ComponentFixture<AddCharacteristicsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCharacteristicsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCharacteristicsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
