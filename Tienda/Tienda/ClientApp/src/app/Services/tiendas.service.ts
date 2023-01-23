import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Tienda } from '../Modelos/tienda';
import { TiendaDetalle } from '../Modelos/tienda-detalle';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class TiendasService extends BaseService {

  constructor(protected http: HttpClient) {
    super(http);
    this.pathService ='Tienda';
  }
  public Listar(){
    return this.Get<TiendaDetalle[]>('',[]);
  }

  public Agregar(tienda:Tienda){
    return this.Post<number,Tienda>('',tienda);
  }

  public Ediatr(detalle:TiendaDetalle){
    return this.Put<number,TiendaDetalle>('',detalle);
  }
}
