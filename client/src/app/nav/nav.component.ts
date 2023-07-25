import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { Observable, of } from 'rxjs';
import { User } from '../_models/user';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model: any = {}
  token: any = null

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  // getCurrentUser() {
  //   this.accountService.currentUser$.subscribe({
  //     // turns user into boolean
  //     //next: user => this.loggedIn = !!user,
  //     error: error => console.log(error)
  //   })
  // }

  login() {
    this.accountService.login(this.model).subscribe({
      next: (response : any) => {
        console.log(response);
        this.token = response.token;
      },
      error: error => console.log(error)
    })
  }

  logout() {
    this.accountService.logout();
  }

}
