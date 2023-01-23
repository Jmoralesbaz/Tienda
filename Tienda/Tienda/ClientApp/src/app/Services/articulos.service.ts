import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Articulo } from '../Modelos/articulo';
import { ArticuloDetalle } from '../Modelos/articulo-detalle';
import { Tienda } from '../Modelos/tienda';
import { TiendaDetalle } from '../Modelos/tienda-detalle';
import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class ArticulosService extends BaseService {

  constructor(protected http: HttpClient) {
    super(http);
    this.pathService ='Articulos';
  }

  public Listar(){
    return this.Get<ArticuloDetalle[]>('',[]);
  }

  public Agregar(articulo:Articulo){
    return this.Post<number,Articulo>('',articulo);
  }

  public Ediatr(detalle:ArticuloDetalle){
    return this.Put<number,ArticuloDetalle>('',detalle);
  }
}