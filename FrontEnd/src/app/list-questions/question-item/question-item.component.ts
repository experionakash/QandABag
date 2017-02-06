import { Question } from '../../models/question';
import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-question-item',
  templateUrl: './question-item.component.html',

})
export class QuestionItemComponent implements OnInit {
  @Input() question: Question;
  @Input() questionId: number;
  Status: string;
  DateAsked: string;
  constructor() { }

  ngOnInit() {

      if(this.question.Status==false)
        this.Status="Unanswered";
      else
        this.Status="Answered";

  }

}
