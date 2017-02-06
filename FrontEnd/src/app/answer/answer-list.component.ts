import { AnswerService } from './answer.service';
import { Component, OnInit, OnChanges, DoCheck, AfterContentInit, ContentChild,
  AfterViewChecked, AfterViewInit, ViewChild,ViewChildren } from '@angular/core';
import { ActivatedRoute, Router,Params } from '@angular/router';
import {NgForm} from '@angular/forms';

@Component({
  selector: 'app-answer-list',
  templateUrl: './answer-list.component.html',
  styleUrls: ['./answer-list.component.css']
})
export class AnswerListComponent implements OnInit, OnChanges,AfterViewInit,AfterViewChecked {
  @ViewChildren('answerNow') vc;
  questionId:number;
  answers :any
  isShow=false;
  newAnswer={
          UserAnswered :'',
          QuestionId :'',
          AnswerDetails :'',
  }
  constructor(private answerService: AnswerService, private router:Router, private activatedRoute: ActivatedRoute) { }
  
  ngAfterViewInit() {            
       this.vc.first.nativeElement.focus();
    }
    
    ngAfterViewChecked()
    {
      this.vc.first.nativeElement.focus();
    }

  ngOnChanges()
  {
    this.LoadAnswers();
   // this.vc.first.nativeElement.focus();

  }

  ngOnInit() {
    this.LoadAnswers();
 // this.vc.first.nativeElement.focus();
    }

    onSubmit(form:NgForm)
    {
        this.newAnswer.UserAnswered = localStorage.getItem("user");
        this.answerService.PostAnswer(this.newAnswer,this.questionId).subscribe(
                    (data)=> {
        this.LoadAnswers();
        console.log("from new answer");
        console.log(data);
     });

      this.isShow=false;
    }

    ShowAnswerFeild()
    {
      console.log("on true");
      this.isShow = true;
    }

    LoadAnswers()
    {
      this.activatedRoute.params.subscribe((params:Params) => {
        this.questionId = params['id'];
        console.log( this.questionId);
         this.answerService.GetAnswers(this.questionId).subscribe(
                    (data)=> {
        this.answers = data.Answers.reverse();
        console.log(this.answers)
     });

      });
    }
}

