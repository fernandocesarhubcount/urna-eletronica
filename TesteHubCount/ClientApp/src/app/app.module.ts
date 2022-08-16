import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CandidatosComponent } from './candidatos/candidatos.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { UrnaComponent } from './urna/urna.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { AlertasComponent } from './alertas/alertas.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    CandidatosComponent,
    DashboardComponent,
    UrnaComponent,
    CadastroComponent,
    AlertasComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ModalModule.forRoot(),
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: UrnaComponent, pathMatch: 'full' },
      { path: 'candidatos', component: CandidatosComponent },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'urna', component: UrnaComponent },
      { path: 'cadastro', component: CadastroComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
