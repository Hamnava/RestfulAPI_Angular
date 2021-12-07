import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getUser();
  }

  registerToggle(){
    this.registerMode = !this.registerMode;
  }

  getUser(){
    this.http.get("https://localhost:44335/api/users").subscribe(users => this.users = users);
  }

  cancelRegisterEvent(Event : boolean){
    this.registerMode = Event;
  }
}
