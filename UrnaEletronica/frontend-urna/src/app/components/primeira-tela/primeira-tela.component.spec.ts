import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrimeiraTelaComponent } from './primeira-tela.component';

describe('PrimeiraTelaComponent', () => {
  let component: PrimeiraTelaComponent;
  let fixture: ComponentFixture<PrimeiraTelaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PrimeiraTelaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PrimeiraTelaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
