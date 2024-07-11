import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogueExampleComponent } from './dialogue-example.component';

describe('DialogueExampleComponent', () => {
  let component: DialogueExampleComponent;
  let fixture: ComponentFixture<DialogueExampleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DialogueExampleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DialogueExampleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
