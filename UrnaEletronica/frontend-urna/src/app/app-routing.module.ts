import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PrimeiraTelaComponent } from './components/primeira-tela/primeira-tela.component';
import { SegundaTelaComponent } from './components/segunda-tela/segunda-tela.component';
import { TerceiraTelaComponent } from './components/terceira-tela/terceira-tela.component';

const routes: Routes = [
  {path:'', component:PrimeiraTelaComponent},
  {path:'segunda-tela', component:SegundaTelaComponent},
  {path:'terceira-tela', component:TerceiraTelaComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
