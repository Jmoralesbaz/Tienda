import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { User } from 'src/app/Modelos/user';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  frmLogin:FormGroup;
  constructor(private servicio:LoginService, private fromBuilder:FormBuilder) { }

  ngOnInit() {
    this.frmLogin=this.fromBuilder.group({
      user:'',
      pwd:''
    });
  }

  private auteticar(user:User){
    this.servicio.Login(user).subscribe(()=>{
      
    });
  }

}
