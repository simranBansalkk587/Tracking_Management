import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InvitepersonComponent } from './inviteperson.component';

describe('InvitepersonComponent', () => {
  let component: InvitepersonComponent;
  let fixture: ComponentFixture<InvitepersonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InvitepersonComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InvitepersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
