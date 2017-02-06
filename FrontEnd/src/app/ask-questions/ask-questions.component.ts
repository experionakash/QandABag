import { AskQuestionService } from './ask-question.service';
import { Component, OnInit } from '@angular/core';
import {NgForm} from '@angular/forms';
import { Router,Params } from '@angular/router';
import { LoginComponent } from '../login/login.component';
import { NgModule } from '@angular/core';

@Component({
  selector: 'app-ask-questions',
  templateUrl: './ask-questions.component.html',
  styleUrls: ['./ask-questions.component.css']
})
export class AskQuestionsComponent implements OnInit {

  constructor(private postQuestionService:AskQuestionService , private router : Router,
              ) { }

  questionDetails={
         Title:'',
         Description:'',
         UserAsked:'',
     };
  

 ngOnInit() {
 }

 onSubmit(form:NgForm)
  {
        this.questionDetails.UserAsked = localStorage.getItem("user");
        this.postQuestionService.PostQuestion(this.questionDetails).subscribe(
                    (data)=> {  
                         if(data.Valid==true)
                     {
                       this.router.navigate(['./list-questions']);
                       alert(data.Message)
                     }
                     if(data.Valid==false)
                     {
                       alert(data.Message);
                     }

     });

    
  }
    
                  

                  //  });
  }


