import { Injectable } from '@angular/core';
import { Http, XHRBackend, RequestOptions, Request, RequestOptionsArgs, Response, Headers } from  '@angular/http';
import { Observable} from 'rxjs/Observable';
import 'rxjs/Rx';

@Injectable()
export class AskQuestionService {

  constructor(private http :Http) { }

  PostQuestion(data : any) :Observable <any>
  {
      console.log("On post question");
      let headers = new Headers({ 'Content-Type': 'application/json' }); // ... Set content type to JSON
      let options = new RequestOptions({ headers: headers });
      console.log(data);
      return this.http.post('http://localhost:52088/api/AskQuestion',data,Option)
      .map((response : Response) => response.json());
  }
}




