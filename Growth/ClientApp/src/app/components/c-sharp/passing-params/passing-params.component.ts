import { Component, OnInit } from '@angular/core';
import { PassingParams } from 'src/app/models/interfaces';
import { PassingParamsService } from 'src/app/services/csharp-services/passing-params.service';

@Component({
  selector: 'app-passing-params',
  templateUrl: './passing-params.component.html',
  styleUrls: ['./passing-params.component.scss']
})
export class PassingParamsComponent implements OnInit {
  passingParamsItem: PassingParams = {
    outValue: 0,
    parameters: [],
    reference: 0,
    value: 0
  };

  constructor(private passingParamsService: PassingParamsService) { }

  ngOnInit(): void {
    this.passingParamsService.GetPassingParameters().subscribe(res => {
      this.passingParamsItem = res;
    })
  }

}
