import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import { Observable} from 'rxjs/Observable';
import 'rxjs/Rx';
@Injectable()
export class LoginService {

  constructor(private http :Http) { }


 Login(credentials : any) :Observable <any>
 {
    console.log("On register");
    let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
    let options = new RequestOptions({ headers: headers });
    console.log(credentials);
    return this.http.post('http://localhost:52088/api/Login',credentials,Option)
    .map((response : Response) => response.json());
 } 

 
}