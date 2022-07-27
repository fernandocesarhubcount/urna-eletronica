import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateComponent } from './candidate/candidate.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { VoteComponent } from './vote/vote.component';

const routes: Routes = [
  {path: '', pathMatch: 'full', redirectTo: 'dashboard'},
  {path: 'dashboard', component: DashboardComponent},
  {path: 'candidate', component: CandidateComponent},
  {path: 'vote', component: VoteComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
