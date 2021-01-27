import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
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
    this.httpClient.post(environment.api_url, {username:username, password: password}, {
      responseType: 'text',
      observe: 'response',
    }).subscribe((response:HttpResponse<any>) => {
      let tokenHeader = response.headers.get("token");
      let token = tokenHeader ? tokenHeader : "";
      localStorage.setItem("token", "Bearer "+ token);
      console.log(token);
      console.log(response);
    });
  }

  getWheather(){
    let tokenStorage = localStorage.getItem("token");
    let token = tokenStorage ?  tokenStorage : "";
    this.httpClient.get("http://localhost:32872/WeatherForecast/",{
      headers: new HttpHeaders({
        Authorization: token
      })
    }).subscribe(data => {
      console.log(data);
    });
  }

}

