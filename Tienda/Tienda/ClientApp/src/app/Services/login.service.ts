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
    return this.Post<string,User>('Login',datos);
  }
  public LogOut(datos:User){
    return this.Put<string,Params>('LogOut',datos);
  }

  public IsLogin(datos:User){    
   return this.Post<boolean,User>('SesionActiva',datos);
  }
}
