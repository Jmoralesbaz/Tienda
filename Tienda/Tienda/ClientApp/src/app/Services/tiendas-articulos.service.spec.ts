import { TestBed } from '@angular/core/testing';

import { TiendasArticulosService } from './tiendas-articulos.service';

describe('TiendasArticulosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TiendasArticulosService = TestBed.get(TiendasArticulosService);
    expect(service).toBeTruthy();
  });
});
