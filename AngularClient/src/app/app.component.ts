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
  constructor(private http: HttpClient, private accountService: AccountService){}

  ngOnInit() {
   this.getUsers();
   this.setCurrentUser();
  }

setCurrentUser(){
  const user: User = JSON.parse(localStorage.getItem('user'));
  this.accountService.setCurrentUser(user);
}

  getUsers(){
    this.http.get("https://localhost:44335/api/users").subscribe(response => {
      this.users = response;
    }, error => {
       console.log(error);
    });
  }
}
