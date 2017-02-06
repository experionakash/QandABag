import { Question } from '../models/question';
import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import { Observable} from 'rxjs/Observable';
import 'rxjs/Rx';
@Injectable()
export class ListQuestionsService {

  constructor(private http :Http) { }

 GetQuestions() :Observable <any>
 {
    let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
    let options = new RequestOptions({ headers: headers });
    return this.http.get('http://localhost:52088/api/Questions',Option)
    .map((response : Response) => response.json());
 } 

 
}