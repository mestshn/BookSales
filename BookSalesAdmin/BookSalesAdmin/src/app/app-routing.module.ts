import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import {AppMainComponent} from './app.main.component';
import {AppWizardComponent} from './pages/app.wizard.component';
import {DashboardComponent} from './demo/view/dashboard.component';
import {AppErrorComponent} from './pages/app.error.component';
import {AppAccessdeniedComponent} from './pages/app.accessdenied.component';
import {AppNotfoundComponent} from './pages/app.notfound.component';
import {AppContactusComponent} from './pages/app.contactus.component';
import {AppLoginComponent} from './pages/app.login.component';
import {AppLandingComponent} from './pages/app.landing.component';


@NgModule({
  imports: [
    RouterModule.forRoot([
      {
        path: '', component: AppMainComponent,
        children:[
          {path: '', component: DashboardComponent},
        ]
      },
      {path: 'error', component: AppErrorComponent},
      {path: 'access', component: AppAccessdeniedComponent},
      {path: 'notfound', component: AppNotfoundComponent},
      {path: 'contactus', component: AppContactusComponent},
      {path: 'login', component: AppLoginComponent},
      {path: 'landing', component: AppLandingComponent},
      {path: 'pages/wizard', component: AppWizardComponent},
      {path: '**', redirectTo: '/notfound'},
    ], {scrollPositionRestoration: 'enabled'})
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
