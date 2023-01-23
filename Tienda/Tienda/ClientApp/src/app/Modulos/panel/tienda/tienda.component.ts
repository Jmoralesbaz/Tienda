import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { TiendaDetalle } from 'src/app/Modelos/tienda-detalle';
import { TiendasService } from 'src/app/Services/tiendas.service';

@Component({
  selector: 'app-tienda',
  templateUrl: './tienda.component.html',
  styleUrls: ['./tienda.component.css']
})
export class TiendaComponent implements OnInit {
  detalle:TiendaDetalle[];
  frmTienda:FormGroup;
  constructor(private servicio:TiendasService,private fb:FormBuilder) { }

  ngOnInit() {
    this.frmTienda=this.fb.group({
      id:0,
      sucursal:'',
      direccion:''
    });
   this.loadData();
    
  }
  private loadData(){
    
    this.frmTienda.reset();
    this.setForm({
      id:0,
      sucursal:'',
      direccion:''
    });
    this.servicio.Listar().subscribe((datos)=>{
      this.detalle=datos;
    });
  }
  private setForm(datos:TiendaDetalle){
    this.frmTienda.patchValue({
      id:datos.id,
      sucursal:datos.sucursal,
      direccion:datos.direccion
    });
  }
  public editar(row:TiendaDetalle){
      this.setForm(row);
  }
  public guardar(row:TiendaDetalle){
    if(row.id==0){
      this.servicio.Agregar({ direccion:row.direccion, sucursal:row.sucursal  }).subscribe(()=>{
        this.loadData();
      });
    }else{
      this.servicio.Ediatr(row).subscribe(()=>{
        this.loadData();
      });
    }
  }
}
