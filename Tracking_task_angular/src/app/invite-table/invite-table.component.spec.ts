import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InviteTableComponent } from './invite-table.component';

describe('InviteTableComponent', () => {
  let component: InviteTableComponent;
  let fixture: ComponentFixture<InviteTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ InviteTableComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(InviteTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
