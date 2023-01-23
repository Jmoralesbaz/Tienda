import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TiendaComponent } from './tienda/tienda.component';
import { ArticuloComponent } from './articulo/articulo.component';
import { ClienteComponent } from './cliente/cliente.component';
import { RouterModule, Routes } from '@angular/router';
import { CompartidaModule } from 'src/app/compartida/compartida.module';

const panelRout:Routes=[
  {
    path:'tiendas',
    component:TiendaComponent
  },
  {
    path:'articulos',
    component:ArticuloComponent
  },
  {
    path:'clientes',
    component:ClienteComponent
  },  
  {
    path:'',
    pathMatch:'full',
    redirectTo:'tiendas'
  },
  {
    path:'**',    
    redirectTo:'tiendas'
  }
];

@NgModule({
  declarations: [TiendaComponent, ArticuloComponent, ClienteComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(panelRout),
    CompartidaModule,
    
  ]
})
export class PanelModule { }
