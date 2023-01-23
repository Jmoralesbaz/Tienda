import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { User } from 'src/app/Modelos/user';
import { LoginService } from 'src/app/Services/login.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  frmLogin:FormGroup;
  constructor(private servicio:LoginService, private fromBuilder:FormBuilder,private router:Router) { }

  ngOnInit() {
    this.frmLogin=this.fromBuilder.group({
      user:'',
      pwd:''
    });
  }

  private auteticar(user:User){
    this.servicio.Login(user).subscribe((d:string)=>{
      localStorage.setItem(environment.luser, user.user);
      localStorage.setItem(environment.lkey,d);
      return this.router.navigate(['/panel']).then(() => true);
    });
  }

}
