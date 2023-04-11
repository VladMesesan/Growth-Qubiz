import { Component, OnInit } from '@angular/core';
import { ValueAndReferenceType } from 'src/app/models/interfaces';
import { ValueAndReferenceTypesService } from 'src/app/services/csharp-services/value-and-reference-types.service';

@Component({
  selector: 'app-value-and-reference-types',
  templateUrl: './value-and-reference-types.component.html',
  styleUrls: ['./value-and-reference-types.component.scss']
})
export class ValueAndReferenceTypesComponent implements OnInit {

  constructor(private valueAndReferenceTypesService: ValueAndReferenceTypesService) { }

  valueAndReferenceType: ValueAndReferenceType = { refName: '', value: 0, refArray: [] };

  ngOnInit(): void {
    this.valueAndReferenceTypesService.getReferenceType().subscribe(reference => {
      this.valueAndReferenceType.refName = reference.refName;
    })

    this.valueAndReferenceTypesService.getValueType().subscribe((value: number) => {
      this.valueAndReferenceType.value = value;
    })

    this.valueAndReferenceTypesService.GetReferenceArray().subscribe((value: number[]) => {
      this.valueAndReferenceType.refArray = value;
    })
  }
}
