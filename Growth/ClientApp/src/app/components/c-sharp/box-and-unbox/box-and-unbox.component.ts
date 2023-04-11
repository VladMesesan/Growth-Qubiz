import { Component, OnInit } from '@angular/core';
import { BoxingAndUnboxingService } from 'src/app/services/csharp-services/boxing-and-unboxing.service';

@Component({
  selector: 'app-box-and-unbox',
  templateUrl: './box-and-unbox.component.html',
  styleUrls: ['./box-and-unbox.component.scss']
})
export class BoxAndUnboxComponent implements OnInit {
  boxUnboxItem: any;

  constructor(private boxingAndUnboxingService: BoxingAndUnboxingService) { }

  ngOnInit(): void {
    this.boxingAndUnboxingService.GetBoxingUnboxing().subscribe(val => {
      this.boxUnboxItem = val;
    })
  }
}
