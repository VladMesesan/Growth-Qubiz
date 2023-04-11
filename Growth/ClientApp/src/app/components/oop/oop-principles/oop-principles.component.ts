import { Component, OnInit } from '@angular/core';
import { OopPrinciplesService } from 'src/app/services/oop-services/oop-principles.service';

@Component({
  selector: 'app-oop-principles',
  templateUrl: './oop-principles.component.html',
  styleUrls: ['./oop-principles.component.scss']
})
export class OopPrinciplesComponent implements OnInit {

  constructor(private oopPrinciplesService: OopPrinciplesService) { }
  principlesOfOop: any;

  ngOnInit(): void {
    this.oopPrinciplesService.GetPrinciplesOfOOP().subscribe(val => {
      this.principlesOfOop = val;
    })
  }
}
