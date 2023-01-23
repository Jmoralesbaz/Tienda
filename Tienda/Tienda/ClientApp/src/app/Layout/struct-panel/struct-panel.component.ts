import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/Modelos/user';
import { LoginService } from 'src/app/Services/login.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-struct-panel',
  templateUrl: './struct-panel.component.html',
  styleUrls: ['./struct-panel.component.css']
})
export class StructPanelComponent implements OnInit {

  constructor(private auth:LoginService) { }

  ngOnInit() {
    this.auth.IsLogin(this.GetUser()).subscribe((e:boolean)=>{},()=>{
        localStorage.clear();
    });
  }
  public async Salir(){
    this.auth.LogOut(this.GetUser()).subscribe((d:boolean)=>{
      localStorage.clear();
      window.location.href="/acceso";
    },(e)=>{
      localStorage.clear();
      window.location.href="/acceso";
    });

  }
  private GetUser():User{
    return {user:localStorage.getItem(environment.luser),pwd:localStorage.getItem(environment.lkey)};
  }
}
