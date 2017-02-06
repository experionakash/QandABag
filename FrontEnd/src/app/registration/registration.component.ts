import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import {NgForm} from '@angular/forms';
import { RegistrationService } from './registration.service';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  constructor(private regService:RegistrationService , private router : Router) { }

  userRegistration={
         firstname:'',
         lastname:'',
         dob:'',
         email:'',
         username:'',
         password:''
     };

  ngOnInit() {}

    onSubmit(form:NgForm)
  { var status =false;
    console.log(form.value);
    var response = this.regService.Register(this.userRegistration).subscribe(
                   (data)=> {
                     if(data.Valid==true)
                     {
                       this.router.navigate(['./login']);
                       alert(data.Message)
                     }
                     if(data.Valid==false)
                     {
                       alert(data.Message);
                     }

                   });
  }


}
