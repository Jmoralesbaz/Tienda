import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule, Routes, UrlSerializer } from '@angular/router';

import { AppComponent } from './app.component';
import { StructAccessComponent } from './Layout/struct-access/struct-access.component';
import { StructPanelComponent } from './Layout/struct-panel/struct-panel.component';
import { BrowserModule } from '@angular/platform-browser';
import { UrlLowerCase } from './Utils/url-lower-case';
import { SeguridadGuard } from './Utils/seguridad.guard';

const routes: Routes = [ 
  {
    path:'',
    pathMatch:'full',
    redirectTo:'acceso'
  },
  {
    path:'',
    component:StructAccessComponent,
    children:[
      {
        path:'',
        loadChildren:()=>import("../app/Modulos/access/access.module").then(m=>m.AccessModule)
      }
    ]    
  },
  {
    path:'panel',
    component:StructPanelComponent,
    canActivate: [SeguridadGuard],
    children:[
      {
        path:'',
        loadChildren:()=>import("../app/Modulos/panel/panel.module").then(m=>m.PanelModule)
      }
    ]    
  }
];


@NgModule({
  declarations: [
    AppComponent,
    StructAccessComponent,
    StructPanelComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,  

    RouterModule.forRoot(routes)
  ],
  providers: [
    {
      provide: UrlSerializer,
      useClass: UrlLowerCase
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
