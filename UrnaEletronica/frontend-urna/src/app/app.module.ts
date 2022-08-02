import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { CandidateService } from './services/candidate.service';
import { TerceiraTelaComponent } from './components/terceira-tela/terceira-tela.component';
import { SegundaTelaComponent } from './components/segunda-tela/segunda-tela.component';
import { PrimeiraTelaComponent } from './components/primeira-tela/primeira-tela.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    TerceiraTelaComponent,
    SegundaTelaComponent,
    PrimeiraTelaComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [HttpClientModule, CandidateService],
  bootstrap: [AppComponent]
})
export class AppModule { }
