import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-auth',
  templateUrl: './auth.component.html',
  styleUrls: ['./auth.component.css']
})
export class AuthComponent implements OnInit {

  constructor(private httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  login(username:string, password:string){
    // alert(`${username}-${password}`);
    this.httpClient.get<any>(environment.api_url).subscribe(data => {
      console.log(data);
    });
  }

}

