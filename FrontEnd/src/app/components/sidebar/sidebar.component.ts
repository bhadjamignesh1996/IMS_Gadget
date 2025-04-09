import { Component } from '@angular/core';
import { AuthenticationService } from 'src/app/services';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
})
export class SidebarComponent {
  sidebarOpen = false;

  constructor(private authenticationService: AuthenticationService) {

  }
  toggleSidebar() {
    this.sidebarOpen = !this.sidebarOpen;
  }

  logout() {
    this.authenticationService.logout();
  }
}
