import { Question } from '../models/question';
import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import { Observable} from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class AnswerService {

  constructor(private http:Http) { }

  GetAnswers(id:number) :Observable <any>
 {
    let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
    let options = new RequestOptions({ headers: headers });
    return this.http.get('http://localhost:52088/api/Question/'+id ,Option)
    .map((response : Response) => response.json());
 } 


 PostAnswer(data : any,id:number) :Observable <any>
  {
      console.log("On post question");
      let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
      let options = new RequestOptions({ headers: headers });
      console.log(data);
      return this.http.post('http://localhost:52088/api/Question/'+id+'/Answer',data,Option)
      .map((response : Response) => response.json());
  }

}
