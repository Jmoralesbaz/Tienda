import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Params } from '@angular/router';
import { User } from '../Modelos/user';

import { BaseService } from './base.service';

@Injectable({
  providedIn: 'root'
})
export class LoginService extends BaseService {

  constructor(protected http: HttpClient) {
    super(http);
    this.pathService ='Account';
  }
  public Login(datos:User){
    return this.Post<string,User>('',datos);
  }
  public LogOut(datos:Params){
    return this.Put<string,Params>('',datos);
  }

  public IsLogin(){
    var sesion =localStorage.getItem('ids');
    this.Get<boolean>('',[{name:'id',value:sesion}]).subscribe((activa)=>{
      return activa;
    });
  }
}
