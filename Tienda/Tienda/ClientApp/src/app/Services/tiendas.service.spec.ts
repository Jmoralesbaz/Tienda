import { TestBed } from '@angular/core/testing';

import { TiendasService } from './tiendas.service';

describe('TiendasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: TiendasService = TestBed.get(TiendasService);
    expect(service).toBeTruthy();
  });
});
