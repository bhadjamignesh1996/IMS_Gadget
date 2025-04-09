import { Injectable } from '@angular/core';
import { HttpRequest, HttpHandler, HttpEvent, HttpInterceptor, HttpErrorResponse } from '@angular/common/http';
import { BehaviorSubject, from, Observable, throwError } from 'rxjs';
import { AuthenticationService, CommonService } from 'src/app/services/';
import { finalize, switchMap } from 'rxjs/operators';

@Injectable()
export class JwtInterceptor implements HttpInterceptor {

    private isQueueing = false;
    private queue: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);

    constructor(
        private authenticationService: AuthenticationService,
        private commonService: CommonService
    ) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        // Add authorization header with JWT token if available
        let currentUserValue = this.authenticationService.currentUserValue;
        if (currentUserValue?.data != null && currentUserValue?.data != undefined) {
            let currentUser = currentUserValue?.data;
            request = request.clone({
                setHeaders: {
                    TOKEN_NO: currentUser?.token,
                    Authorization: currentUser?.token,
                    Local_TimeZone: Intl.DateTimeFormat().resolvedOptions().timeZone
                }
            });
        }


        return next.handle(request).pipe(
            finalize(() => {
                if (this.queue.value) {
                    this.queue.next(false); // Signal that the queue can proceed
                }
                this.isQueueing = false;
            })
        );
    }
}
