import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RouterModule, Routes } from '@angular/router';
import { CompartidaModule } from 'src/app/compartida/compartida.module';

const accessRout:Routes=[
  {
    path:'acceso',
    component:LoginComponent
  },
  // {
  //   path:'logout',
  //   component:LogoutComponent
  // },
  // {
  //   path:'recuperar-acceso',
  //   component:ForgotPasswordComponent
  // },
  // {
  //   path:'cambiar-clave',
  //   component:ResetPasswordComponent
  // }
];

@NgModule({
  declarations: [LoginComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(accessRout),
    CompartidaModule,
  ]
})
export class AccessModule { }
