import { ListQuestionsService } from './list-questions.service';
import { Question } from '../models/question';
import { Component, OnChanges,OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-questions',
  templateUrl: './list-questions.component.html',
  styleUrls: ['./list-questions.component.css']
})
export class ListQuestionsComponent implements OnChanges,OnInit {
  questions: any[]=[] ;
  constructor(private listQuestions: ListQuestionsService) 
  { }

  ngOnChanges() {
    this.LoadAnswers();
  }
  ngOnInit()
  {
    this.LoadAnswers();
  }

   LoadAnswers()
    {
      var questionsList = this.listQuestions.GetQuestions().subscribe(
                    (data)=> {
        this.questions = data.Questions.reverse();;
        console.log(this.questions)
    });
    }
}
