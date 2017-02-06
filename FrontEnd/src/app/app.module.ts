import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';

import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
import { AskQuestionsComponent } from './ask-questions/ask-questions.component';
import { ListQuestionsComponent } from './list-questions/list-questions.component';
import { HomeComponent } from './home.component';

import { routing } from './app.route';
import { QuestionHeaderComponent } from './question-header.component';
import { LoginService } from "./login/login.service";
import { RegistrationService} from "./registration/registration.service";
import { AskQuestionService } from "./ask-questions/ask-question.service";
import {ListQuestionsService} from "./list-questions/list-questions.service";
import { QuestionItemComponent } from './list-questions/question-item/question-item.component';
import { AnswerItemComponent } from './answer/answer-item.component';
import { AnswerListComponent } from './answer/answer-list.component';
import { AnswerService } from './answer/answer.service'
  
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    RegistrationComponent,
    AskQuestionsComponent,
    ListQuestionsComponent,
    HomeComponent,
    AskQuestionsComponent,
    QuestionHeaderComponent,
    QuestionItemComponent,
    AnswerItemComponent,
    AnswerListComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    routing,

  ],
  providers: [LoginService,AnswerService,RegistrationService, AskQuestionService,ListQuestionsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
