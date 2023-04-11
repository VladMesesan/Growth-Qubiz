import { Component, OnInit } from '@angular/core';
import { LinqService } from 'src/app/services/csharp-services/linq.service';

@Component({
  selector: 'app-linq',
  templateUrl: './linq.component.html',
  styleUrls: ['./linq.component.scss']
})
export class LinqComponent implements OnInit {
  linqItem: number[] = [];
  linqLambdaItem: string[] = [];

  constructor(private linqService: LinqService) { }

  ngOnInit(): void {
    this.linqService.GetOldSchoolLINQ().subscribe(res => {
      this.linqItem = res;
    })

    this.linqService.GetLambdaLINQ().subscribe(res => {
      this.linqLambdaItem = res;
    })
  }

}
