import { LoginService } from './login.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {NgForm} from '@angular/forms';
import { AskQuestionsComponent } from '../ask-questions/ask-questions.component';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private router: Router, private loginService:LoginService){}

  userLogin={
         username:'',
         password:''
     };
  ngOnInit() {}

  
    onSubmit(form:NgForm)
    { var status =false;
      console.log(form.value);
      var response = this.loginService.Login(this.userLogin).subscribe(
                    (data)=> {
                      if(data.Valid==true)
                      {
                        this.router.navigate(['./list-questions']);
                        localStorage.setItem("user",this.userLogin.username);
                        alert(data.Message)
                      }
                      if(data.Valid==false)
                      {
                        alert(data.Message);
                      }


                    });
     
  }

}
