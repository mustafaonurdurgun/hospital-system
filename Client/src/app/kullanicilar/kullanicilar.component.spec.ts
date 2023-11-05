import { ComponentFixture, TestBed } from '@angular/core/testing';

import { KullanicilarComponent } from './kullanicilar.component';

describe('KullanicilarComponent', () => {
  let component: KullanicilarComponent;
  let fixture: ComponentFixture<KullanicilarComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [KullanicilarComponent]
    });
    fixture = TestBed.createComponent(KullanicilarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
