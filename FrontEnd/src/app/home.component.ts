import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styles: []
      
})
export class HomeComponent implements OnInit {

  constructor(private route: ActivatedRoute,private router: Router) 
  { }

  ngOnInit() {
  }

}
