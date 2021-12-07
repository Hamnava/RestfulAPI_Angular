import { HttpClient } from '@angular/common/http';
import { ThrowStmt } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { User } from './models/user';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'My Lovely Angular project';
  users: any;
  constructor(private accountService: AccountService){}

  ngOnInit() {
   this.setCurrentUser();
  }

setCurrentUser(){
  const user: User = JSON.parse(localStorage.getItem('user'));
  this.accountService.setCurrentUser(user);
}
}
