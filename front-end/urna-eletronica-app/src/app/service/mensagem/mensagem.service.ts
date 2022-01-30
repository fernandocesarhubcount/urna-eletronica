import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root'
})
export class MensagemService {

  constructor(private _snackBar: MatSnackBar) { }

  mostraMensagem(mensagem: string) {
    this._snackBar.open(mensagem, '', { duration: 3000 });
  }
}
