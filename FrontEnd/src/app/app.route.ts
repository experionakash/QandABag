import { Routes, RouterModule } from "@angular/router";
import { ListQuestionsComponent  } from './list-questions/list-questions.component';
import { AskQuestionsComponent } from './ask-questions/ask-questions.component';
import {LoginComponent } from './login/login.component';
import { RegistrationComponent } from './registration/registration.component';
//import { ANSWER_ROUTES } from './list-questions/question.routes'
import { AnswerListComponent } from "./answer/answer-list.component"
const CHILD_ROUTES: Routes = [
     { path: ':id', component: AnswerListComponent  }
]

const APP_ROUTES: Routes = [
    { path: '', redirectTo: 'login', pathMatch: 'full' },    
    { path: 'login', component: LoginComponent},
    { path: 'registration', component: RegistrationComponent },
    { path: 'ask-questions', component: AskQuestionsComponent },
    { path: 'list-questions', component: ListQuestionsComponent, children: CHILD_ROUTES},
];

export const routing = RouterModule.forRoot(APP_ROUTES);