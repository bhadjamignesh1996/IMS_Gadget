import { Injectable, SecurityContext } from '@angular/core';
import { EncryptDecryptService } from './encryptdecrypt.service';
import { AuthenticationService } from './authentication.service';
import {  FormControl, FormGroup } from '@angular/forms';
import { BehaviorSubject } from 'rxjs';
import { DomSanitizer, Meta, Title } from '@angular/platform-browser';
import { Router } from '@angular/router';
import * as moment from 'moment';
@Injectable({
  providedIn: 'root',
})
export class CommonService {
  public currentAIModel: BehaviorSubject<any> = new BehaviorSubject<any>(null);
  
  private displayedErrors = new Set<string>();
  constructor(
    public encryptDecryptService: EncryptDecryptService,
    public authenticationService: AuthenticationService,
    private sanitized: DomSanitizer,
    private meta: Meta,
    private title: Title,
    private router: Router
  ) {}

  
  encrypt(value: string) {
    return value != null && value != undefined
      ? this.encryptDecryptService.encrypt(value)
      : value;
  }

  decrypt(value: any) {
    return value != null && value != undefined
      ? this.encryptDecryptService.decrypt(value)
      : null;
  }

  checkLogin() {
    return this.authenticationService.currentUserValue != undefined &&
      this.authenticationService.currentUserValue != null
      ? Object.keys(this.authenticationService.currentUserValue).length > 0
      : false;
  }

  formUpdateValueAndValidity(form: any) {
    for (const key of Object.keys(form.controls)) {
      form.controls[key].updateValueAndValidity();
    }
  }

  // toastErrorMsg(msg: string) {
  //   if (this.displayedErrors.has(msg)) {
  //     return;
  //   }
  //   this.displayedErrors.add(msg);
  //   this.toast.error(msg);

  //   setTimeout(() => {
  //     this.displayedErrors.delete(msg);
  //   }, 3000);
  // }

  // toastinfoMsg(msg: string) {
  //   this.toast.info(msg);
  // }

  // toastsuccessMsg(msg: string) {
  //   this.toast.success(msg);
  // }

  // toastwarningMsg(msg: string) {
  //   this.toast.warning(msg);
  // }

  setDateFormatYYYYMMDD(date: any) {
    return moment(date).format('yyyy-MM-DD');
  }

  setEditData(form: any, editData: any) {
    if (editData != null) {
      for (const key of Object.keys(form.controls)) {
        if (!(form.controls[key] instanceof FormGroup)) {
          if (editData instanceof Array) {
            if (form.controls[key] instanceof FormControl) {
              form.controls[key].setValue(
                editData[0][key] == 'null' ? editData[0][key] : editData[0][key]
              );
            }
          } else if (editData instanceof Object) {
            if (form.controls[key] instanceof FormControl) {
              if (
                String(editData[key]).includes('T') &&
                String(editData[key]).indexOf('T') == 10
              ) {
                // form.controls[key].setValue(this.setDateFormatDDMMYYYY(String(editData[key]).split('T')[0]));

                form.controls[key].setValue(
                  new Date(
                    this.setDateFormatYYYYMMDD(
                      String(editData[key]).split('T')[0]
                    )
                  )
                );
              } else {
                form.controls[key].setValue(
                  editData[key] == null ? '' : editData[key]
                );
              }
            }
          }
        } else {
          for (const skey of Object.keys(form.controls[key].controls)) {
            if (form.controls[key].controls[skey] instanceof FormControl) {
              if (editData[key] != null)
                form
                  .get(key)
                  .controls[skey].setValue(
                    editData[key][skey] == null ? '' : editData[key][skey]
                  );
            }
          }
        }
      }
    }
  }

  removeDuplicates(items: any[], propertyName: string) {
    return items.filter(
      (arr, index, self) =>
        index === self.findIndex((t) => t[propertyName] === arr[propertyName])
    );
  }




 




 




}
