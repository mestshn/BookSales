import {RouterModule} from '@angular/router';
import {NgModule} from '@angular/core';
import {AppMainComponent} from './app.main.component';
import {AppRegisterComponent} from './pages/app.register.component';
import {DashboardComponent} from './demo/view/dashboard.component';
import {AppErrorComponent} from './pages/app.error.component';
import {AppAccessdeniedComponent} from './pages/app.accessdenied.component';
import {AppNotfoundComponent} from './pages/app.notfound.component';
import {AppContactusComponent} from './pages/app.contactus.component';
import {AppLoginComponent} from './pages/app.login.component';
import {AppLandingComponent} from './pages/app.landing.component';
import {AuthGuard} from './pages/demo/auth/auth.guard';


@NgModule({
  imports: [
    RouterModule.forRoot([
      {
        path: 'dashboard',component:AppMainComponent,
        canActivate:[AuthGuard],
        children:[
          {path: '', component: DashboardComponent},
        ]
      },
      {path: '', component: AppLoginComponent},
      {path: 'error', component: AppErrorComponent},
      {path: 'access', component: AppAccessdeniedComponent},
      {path: 'notfound', component: AppNotfoundComponent},
      {path: 'contactus', component: AppContactusComponent},
      {path: 'landing', component: AppLandingComponent},
      {path: 'register', component: AppRegisterComponent},
      {path: '**', redirectTo: '/notfound'},
      
    ], {scrollPositionRestoration: 'enabled'})
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
