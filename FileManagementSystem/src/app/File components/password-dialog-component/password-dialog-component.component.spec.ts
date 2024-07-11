import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordDialogComponentComponent } from './password-dialog-component.component';

describe('PasswordDialogComponentComponent', () => {
  let component: PasswordDialogComponentComponent;
  let fixture: ComponentFixture<PasswordDialogComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PasswordDialogComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PasswordDialogComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
