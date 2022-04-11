import { Component, OnInit } from '@angular/core';
import { BreakpointObserver } from '@angular/cdk/layout';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'DashBoard';
  sideBarOpen = true;
  detail: boolean = false;
  isExpanded: any;

  contentMargin = 260;

  constructor(private observer: BreakpointObserver) {

  }
  sideBarToggler() {
    this.detail = !this.detail;
    this.isExpanded = this.detail;

    //this.sideBarOpen = !this.sideBarOpen;
    if(this.isExpanded) {
      this.contentMargin = 4.6875;
    }
    else {
      this.contentMargin = 18.2;
    }
  }

  ngAfterViewInit(){
    this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
      if(res.matches) {
        this.isExpanded = true;
      }
      else {
        this.isExpanded = false;
      }
    });
  }
}
