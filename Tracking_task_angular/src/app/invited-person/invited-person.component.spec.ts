import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitedPersonComponent } from './invited-person.component';

describe('InvitedPersonComponent', () => {
  let component: InvitedPersonComponent;
  let fixture: ComponentFixture<InvitedPersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvitedPersonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvitedPersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
