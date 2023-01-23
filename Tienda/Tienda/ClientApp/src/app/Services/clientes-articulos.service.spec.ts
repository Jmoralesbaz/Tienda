import { TestBed } from '@angular/core/testing';

import { ClientesArticulosService } from './clientes-articulos.service';

describe('ClientesArticulosService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ClientesArticulosService = TestBed.get(ClientesArticulosService);
    expect(service).toBeTruthy();
  });
});
