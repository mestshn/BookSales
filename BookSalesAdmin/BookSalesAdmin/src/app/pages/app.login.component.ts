import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './app.login.component.html',
})
export class AppLoginComponent implements OnInit {
 
  formModel = {
    KullaniciAdi:'',
    Sifre:''
  }


  onSubmit(form: NgForm) {

    }




  ngOnInit(): void {}

}
