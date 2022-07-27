import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { NavComponent } from './nav/nav.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { CandidateComponent } from './candidate/candidate.component';
import { VoteComponent } from './vote/vote.component';
import { HttpClientModule } from '@angular/common/http';
import { VoteService } from './vote/vote.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CandidateService } from './candidate/candidate.service';


@NgModule({
  declarations: [				
    AppComponent,
      NavComponent,
      DashboardComponent,
      CandidateComponent,
      VoteComponent
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    VoteService,
    CandidateService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
