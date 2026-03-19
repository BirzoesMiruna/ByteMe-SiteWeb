import { Routes } from '@angular/router';

import { DesprenoiComponent } from './desprenoi/desprenoi.component'; // Import corect!
import { HomeComponent } from './home/home.component';
import { ReteteComponent}  from './retete/retete.component';
import { RetetaDetaliiComponent } from './reteta-detalii/reteta-detalii.component';
import { ContactComponent } from './contact/contact.component';
import { TermeniComponent } from './termeni/termeni.component';
import { ConfidentialitateComponent } from './confidentialitate/confidentialitate.component';
import { LoginComponent } from './login/login.component';
import { WhishlistComponent } from './whishlist/whishlist.component';
import { DashboardComponent } from './components/dashboard.component';
import { ContulMeuComponent } from './components/contul-meu.component';
import { AuthGuard } from './guards/auth.guard';
import { ResetPasswordComponent } from './reset-password/reset-password.component';
/* import { DashboardComponent } from './dashboard/dashboard.component';
import { AuthGuard } from './auth.guard'; */

export const routes: Routes = [

  { path: '', component: HomeComponent },

  { path: 'desprenoi', component: DesprenoiComponent },
  { path: 'retete', component: ReteteComponent },
  { path: 'reteta/:id', component: RetetaDetaliiComponent },
  { path: 'contact', component: ContactComponent },
  { path: 'termeni', component: TermeniComponent },
  { path: 'confidentialitate', component: ConfidentialitateComponent },
  { path: 'login', component: LoginComponent },
  { path: 'whishlist', component: WhishlistComponent },
 { path: 'contul-meu', component: ContulMeuComponent , canActivate: [AuthGuard] },
   { path: 'reset-password', component: ResetPasswordComponent },


    { path: 'dashboard', component: DashboardComponent },

 // { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuard] },
];
