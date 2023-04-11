import { Component, OnInit } from '@angular/core';
import { ClassObject } from 'src/app/models/interfaces';
import { ClassVsObjectService } from 'src/app/services/oop-services/class-vs-object.service';

@Component({
  selector: 'app-class-vs-object',
  templateUrl: './class-vs-object.component.html',
  styleUrls: ['./class-vs-object.component.scss']
})
export class ClassVsObjectComponent implements OnInit {

  constructor(private classVsObjectService: ClassVsObjectService) { }

  classVsObject: ClassObject = {intProperty: 0, stringProperty: '', forExample: {name: '', randomNumber: 0}};

  ngOnInit(): void {
    this.classVsObjectService.GetClassVsObject().subscribe(val => {
      this.classVsObject = val;
    })
  }

}
