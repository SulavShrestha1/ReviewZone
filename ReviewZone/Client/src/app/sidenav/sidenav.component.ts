import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.css']
})
export class SidenavComponent implements OnInit {

  @Input() isExpanded: any;

  userName = 'Sulav Shrestha'
  status: boolean = false;
  panelOpenState = false;

  status2: boolean = false;
  clickEvent(){
      this.status2 = !this.status2;       
  }
  constructor() { }

  ngOnInit(): void {
    console.log(this.isExpanded); 
  }
}
