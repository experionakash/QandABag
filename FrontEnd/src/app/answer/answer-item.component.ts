import { Answer } from '../models/answer';
import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-answer-item',
  templateUrl: './answer-item.component.html',
  styleUrls: ['./answer-item.component.css']
})
export class AnswerItemComponent implements OnInit  {
  @Input() answer: Answer;
   @Input() index: number;
   AnsweredDate:Date;
  constructor() { }

  ngOnInit() {
    
    
  }

}
