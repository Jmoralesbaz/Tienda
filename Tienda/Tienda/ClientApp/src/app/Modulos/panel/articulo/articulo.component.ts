import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { ArticuloDetalle } from 'src/app/Modelos/articulo-detalle';
import { TiendaDetalle } from 'src/app/Modelos/tienda-detalle';
import { ArticulosService } from 'src/app/Services/articulos.service';
import { TiendasService } from 'src/app/Services/tiendas.service';

@Component({
  selector: 'app-articulo',
  templateUrl: './articulo.component.html',
  styleUrls: ['./articulo.component.css']
})
export class ArticuloComponent implements OnInit {
  detalle:ArticuloDetalle[];
  tiendas:TiendaDetalle[];
  frmArticulo:FormGroup;
  fotoarticulo:string="";
  constructor(private servicio:ArticulosService, private servicio2:TiendasService, private formBuilder: FormBuilder) { }

  ngOnInit() {
    this.frmArticulo=new FormGroup({
      id:new FormControl(''),
      codigo:new FormControl(''),
      precio:new FormControl(0),
      stock:new FormControl(0),
      imagen:new FormControl(''),
      descripcion:new FormControl(''),
     } );
    
   this.setForm({id:0,codigo:'',descripcion:'',imagen:'',precio:0,stock:0});
    
    this.cargar();
  }
  private cargar(){
    this.frmArticulo.reset();
    this.servicio.Listar().subscribe((datos)=>{
      console.log(datos);
      this.detalle=datos;
    });
  }
  private setForm(datos:ArticuloDetalle){
          this.frmArticulo.patchValue(
            {
              id:datos.id,
              codigo:datos.codigo,
              precio:datos.precio,
              stock:datos.stock,
              imagen:datos.imagen,
              descripcion:datos.descripcion,
                  }
          );
  }
  public guardar(datos:ArticuloDetalle){
    if(datos.id == 0){
      this.servicio.Agregar(datos).subscribe((resul)=>{
        this.cargar();
      });
    }else{
      this.servicio.Ediatr(datos).subscribe((result)=>{
        this.cargar();
      });
    }
  }
  public editar(row:ArticuloDetalle){
    this.fotoarticulo=row.imagen;
    this.setForm(row);
     
          
  }
}
