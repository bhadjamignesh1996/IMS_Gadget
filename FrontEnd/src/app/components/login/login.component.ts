import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { first } from 'rxjs';
import { AuthenticationService, CommonApiService, CommonService } from 'src/app/services';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup;
  constructor(

    private router: Router,
    private fb: FormBuilder,
    private authenticationService: AuthenticationService,
    private commonApiService: CommonApiService,
    public commonService: CommonService,
  ) {
    if (this.commonService.checkLogin()) {
      this.router.navigateByUrl("gadgets")
    }

    this.loginForm = this.fb.group({
      userName: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });
  }

  ngOnInit(): void {
  }

  login(): void {
    if (this.loginForm.invalid) {
      this.loginForm.markAllAsTouched();
      return;
    }
    this.authenticationService
      .login(this.loginForm.value)
      .pipe(first())
      .subscribe((data) => {
        if (data['status'] == 200) {
          this.router.navigateByUrl("gadgets")
        } else {
          alert(data.message);
        }
      });
  }




}
