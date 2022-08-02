import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';  
import { Candidate } from '../candidate';

var httpOptions = {headers: new HttpHeaders({"Content-Type": "application/json"})};
@Injectable({
  providedIn: 'root'
})
export class CandidateService {
  url = 'http://localhost:5000/votes';
  urlPost = 'http://localhost:5000/candidate';
  urldelete = 'http://localhost:5000/candidates';  
  
  constructor(private http: HttpClient) { }
  
  getAllCandidates(): Observable<Candidate[]> {  
    return this.http.get<Candidate[]>(this.url);  
  }  

  getCandidateById(id: string): Observable<Candidate> {  
    const apiurl = `${this.urldelete}/${id}`;
    return this.http.get<Candidate>(apiurl);  
  } 

  createCandidate(candidate: Candidate): Observable<Candidate> {  
    return this.http.post<Candidate>(this.urlPost, candidate, httpOptions);  
  }  

  deleteCandidateById(candidateId: string): Observable<number> { 
    return this.http.delete<number>(`${this.urldelete}/${candidateId}`, httpOptions);  
  }  
}