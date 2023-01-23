import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Cliente } from '../Modelos/cliente';
import { ClienteDetalle } from '../Modelos/cliente-detalle';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ClientesService extends BaseService {

  constructor(protected http: HttpClient) {
    super(http);
    this.pathService ='Clientes';
  }
  
  public Listar(){
    return this.Get<ClienteDetalle[]>('',[]);
  }

  public Agregar(cleinte:Cliente){
    return this.Post<number,Cliente>('',cleinte);
  }

  public Ediatr(detalle:ClienteDetalle){
    return this.Put<number,ClienteDetalle>('',detalle);
  }
}