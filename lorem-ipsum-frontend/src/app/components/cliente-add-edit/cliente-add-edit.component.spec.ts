import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ClienteAddEditComponent } from './cliente-add-edit.component';

describe('ClienteAddEditComponent', () => {
  let component: ClienteAddEditComponent;
  let fixture: ComponentFixture<ClienteAddEditComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ClienteAddEditComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ClienteAddEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
