import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ResponseApi } from '../interfaces/response-api';

@Injectable({
  providedIn: 'root'
})
export class DepartamentoPacienteService {
  apiBase: string = '/api/DepartamentoPaciente/'
  constructor(private http: HttpClient) { }

  getDepartamentoPacientes(): Observable<ResponseApi> {
    return this.http.get<ResponseApi>(`${this.apiBase}Lista`)
  }
}
