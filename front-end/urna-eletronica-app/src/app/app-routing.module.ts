import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UrnaComponent } from './pages/urna/urna.component';

const routes: Routes = [
  { path: '', pathMatch: 'full', redirectTo: 'urna' },
  { path: 'urna', loadChildren: () => import('./pages/urna/urna.module').then((m)=> m.UrnaModule)  },
  { path: 'cadastro', loadChildren: () => import('./pages/cadastro/cadastro.module').then((m)=> m.CadastroModule)  },
  { path: 'dashboard', loadChildren: () => import('./pages/dashboard/dashboard.module').then((m)=> m.DashboardModule)  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
