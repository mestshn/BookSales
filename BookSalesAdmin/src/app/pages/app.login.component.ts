import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router} from '@angular/router';
import { UserService } from './demo/service/userservice';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './app.login.component.html',
})
export class AppLoginComponent implements OnInit {
    formModel = {
    KullaniciAdi:'',
    Sifre:''
  }
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }
  ngOnInit() {
    if (localStorage.getItem('token') != null)
      this.router.navigateByUrl('/dashboard');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/dashboard');
      },
      err => {
        if (err.status == 400)
          this.toastr.error('Incorrect username or password.', 'Authentication failed.');
        else
          console.log(err);
      }
    );
  }

  onRegister()
  {
    this.router.navigateByUrl('register');
  }

}
