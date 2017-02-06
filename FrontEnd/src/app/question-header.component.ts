import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-question-header',
  templateUrl: './question-header.component.html'
})
export class QuestionHeaderComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }
  logout()
  {
    localStorage.clear();
  }
}
