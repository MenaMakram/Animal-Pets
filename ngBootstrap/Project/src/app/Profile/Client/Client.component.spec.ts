import { ComponentFixture, TestBed } from '@angular/core/testing';
import { NO_ERRORS_SCHEMA } from '@angular/core';
import { Animals } from './../../../Services/Animals';
import { NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfileClientService } from 'src/Services/ProfileClient.service';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { ImageUploadService } from 'src/Services/ImageUpload.service';
import { ClientComponent } from './Client.component';
describe('ClientComponent', () => {
  let component: ClientComponent;
  let fixture: ComponentFixture<ClientComponent>;
  beforeEach(() => {
    const animalsStub = { animalPhoto: { push: () => ({}) } };
    const ngbModalConfigStub = { backdrop: {}, keyboard: {} };
    const ngbModalStub = {
      open: (content1, object2) => ({ result: { then: () => ({}) } })
    };
    const profileClientServiceStub = {
      getCategory: () => ({ subscribe: () => ({}) }),
      getClient: arg1 => ({ subscribe: () => ({}) }),
      editAnimal: (id1, item2) => ({ subscribe: () => ({}) }),
      AddAnimal: (arg1, arg2) => ({ subscribe: () => ({}) }),
      DeleteAnimals: arg1 => ({ subscribe: () => ({}) }),
      AddPhoto: (arg1, arg2) => ({ subscribe: () => ({}) }),
      DeletePhoto: id1 => ({ subscribe: () => ({}) })
    };
    const routerStub = {};
    const activatedRouteStub = { queryParams: { subscribe: () => ({}) } };
    const imageUploadServiceStub = {
      postFile: arg1 => ({ subscribe: () => ({}) })
    };
    TestBed.configureTestingModule({
      schemas: [NO_ERRORS_SCHEMA],
      declarations: [ClientComponent],
      providers: [
        { provide: Animals, useValue: animalsStub },
        { provide: NgbModalConfig, useValue: ngbModalConfigStub },
        { provide: NgbModal, useValue: ngbModalStub },
        { provide: ProfileClientService, useValue: profileClientServiceStub },
        { provide: Router, useValue: routerStub },
        { provide: ActivatedRoute, useValue: activatedRouteStub },
        { provide: ImageUploadService, useValue: imageUploadServiceStub }
      ]
    });
    fixture = TestBed.createComponent(ClientComponent);
    component = fixture.componentInstance;
  });
  it('can load instance', () => {
    expect(component).toBeTruthy();
  });
  it('title defaults to: Profile', () => {
    expect(component.title).toEqual('Profile');
  });
  it('imageUrl defaults to: /assets/img/default-image.png', () => {
    expect(component.imageUrl).toEqual('/assets/img/default-image.png');
  });
  it('catList defaults to: []', () => {
    expect(component.catList).toEqual([]);
  });
  it('fileToUpload defaults to: []', () => {
    expect(component.fileToUpload).toEqual([]);
  });
  describe('ngOnInit', () => {
    it('makes expected calls', () => {
      const profileClientServiceStub: ProfileClientService = fixture.debugElement.injector.get(
        ProfileClientService
      );
      spyOn(profileClientServiceStub, 'getCategory').and.callThrough();
      spyOn(profileClientServiceStub, 'getClient').and.callThrough();
      component.ngOnInit();
      expect(profileClientServiceStub.getCategory).toHaveBeenCalled();
      expect(profileClientServiceStub.getClient).toHaveBeenCalled();
    });
  });
});
