import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { RouterLinkWithHref } from '@angular/router';
import { ClienteDetalle } from 'src/app/Modelos/cliente-detalle';
import { ClienteViewDetalle } from 'src/app/Modelos/cliente-view-detalle';
import { ClientesService } from 'src/app/Services/clientes.service';

@Component({
  selector: 'app-cliente',
  templateUrl: './cliente.component.html',
  styleUrls: ['./cliente.component.css']
})
export class ClienteComponent implements OnInit {
  detalle:ClienteDetalle[];
  frmCliente:FormGroup;
  constructor(private servicio:ClientesService,private fb:FormBuilder) { }

  ngOnInit() {
    this.frmCliente=this.fb.group({
      id:0,
      nombre:'',
      apellidos:'',
      direccion:''
    });
   this.loadData();
    
  }
  private loadData(){
    
    this.frmCliente.reset();
    this.setForm({
      id:0,
      nombre:'',
      apellidos:'',
      direccion:''
    });
    this.servicio.Listar().subscribe((datos:any)=>{
      this.detalle=[];
      datos.forEach(row=>{
        this.detalle.push({id:row.id, apellidos:row.apellidos, direccion:row.direccion,nombre:row.nombre });
      });

    });
  }
  private setForm(datos:ClienteDetalle){
    this.frmCliente.patchValue({
      id:datos.id,
      nombre:datos.nombre,
      apellidos:datos.apellidos,
      direccion:datos.direccion
    });
  }
  public editar(row:ClienteDetalle){
      this.setForm(row);
  }
  public guardar(row:ClienteDetalle){
    if(row.id==0){
      this.servicio.Agregar({ apellidos:row.apellidos,direccion:row.direccion,nombre:row.nombre }).subscribe(()=>{
        this.loadData();
      });
    }else{
      this.servicio.Ediatr(row).subscribe(()=>{
        this.loadData();
      });
    }
  }
}
