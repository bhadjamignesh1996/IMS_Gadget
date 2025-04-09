import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EncryptDecryptService {

  private shift = 5; // Simple shift amount

  constructor() { }

  encrypt(value: string): string {
    let result = '';
    for (let i = 0; i < value.toString().length; i++) {
      const charCode = value.toString().charCodeAt(i);
      result += String.fromCharCode(charCode + this.shift);
    }
    return window.btoa(encodeURIComponent(result));
  }

  decrypt(value: string): string {
    value = decodeURIComponent(window.atob(value));
    let result = '';
    for (let i = 0; i < value.toString().length; i++) {
      const charCode = value.toString().charCodeAt(i);
      result += String.fromCharCode(charCode - this.shift);
    }
    return result;
  }
}
