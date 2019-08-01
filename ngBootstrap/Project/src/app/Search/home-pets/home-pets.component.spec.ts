import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HomePetsComponent } from './home-pets.component';

describe('HomePetsComponent', () => {
  let component: HomePetsComponent;
  let fixture: ComponentFixture<HomePetsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HomePetsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HomePetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
