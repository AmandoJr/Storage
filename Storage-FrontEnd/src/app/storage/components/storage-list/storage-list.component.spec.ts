import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RESULT_ITEMS } from '../../mock/mock-resultItem';
import { StorageService } from '../../services/storage.service';
import { StorageListComponent } from './storage-list.component';

describe('StorageListComponent', () => {
  let component: StorageListComponent;
  let fixture: ComponentFixture<StorageListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StorageListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {

    // Create jasmine spy object 
    let storageServiceSpy = jasmine.createSpyObj('StorageService', ['getItems']);
    // Provide the dummy/mock data to getItems method.
    storageServiceSpy.getItems = jasmine.createSpy().and.returnValue(Promise.resolve(RESULT_ITEMS));

    TestBed.configureTestingModule({
      providers: [
        { provide: StorageService, useValue: storageServiceSpy },
      ]
    });

    fixture = TestBed.createComponent(StorageListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
