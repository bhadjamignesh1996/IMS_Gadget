import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Router } from '@angular/router';
import { environment } from './../../environments/environment';
import { EncryptDecryptService } from './encryptdecrypt.service';




@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  public currentUserSubject: BehaviorSubject<any>;
  public currentUser: Observable<any>;

  constructor(
    private http: HttpClient,
    private router: Router,
    private encryptDecryptService: EncryptDecryptService
  ) {
    this.currentUserSubject = new BehaviorSubject<any>(
      JSON.parse(
        this.storageDecrypt(
          localStorage.getItem('GadgetStoreCurrentUser'),
          'GadgetStoreCurrentUser'
        ) || '{}'
      )
    );
    this.currentUser = this.currentUserSubject.asObservable();
  }

  public get currentUserValue() {
    return this.currentUserSubject.value;
  }

  login(requestData: any) {
    return this.http
      .post<any>(environment.baseUrl + 'Authentication/Login', requestData)
      .pipe(
        map((user) => {
          if (user.status == 200) {
            localStorage.setItem(
              'GadgetStoreCurrentUser',
              this.storageEncrypt(JSON.stringify(user))
            );
            this.currentUserSubject.next(user);
          }
          return user;
        })
      );
  }

  storageEncrypt(value: string) {
    return value != null && value != undefined
      ? this.encryptDecryptService.encrypt(value)
      : value;
  }

  storageDecrypt(value: any, storageName: string) {
    return value != null &&
      value != undefined &&
      !this.checkUnEncryptVal(value, storageName)
      ? this.encryptDecryptService.decrypt(value)
      : value;
  }

  checkUnEncryptVal(value: string, storageName: string) {
    var checkVal =
      value != null
        ? value.includes('{"status":200') ||
          value.includes('{"lat"') ||
          value.includes('{"userId"')
        : false;
    if (checkVal) {
      localStorage.setItem(storageName, this.storageEncrypt(value));
    }
    return checkVal;
  }

  logout() {
    localStorage.clear();
    this.currentUserSubject.next(null);
    this.router.navigateByUrl('login');
  }
}
