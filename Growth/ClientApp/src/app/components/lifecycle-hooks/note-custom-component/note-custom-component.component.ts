import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-note-custom-component',
  templateUrl: './note-custom-component.component.html',
  styleUrls: ['./note-custom-component.component.scss']
})
export class NoteCustomComponentComponent implements OnInit {
  @Input() headerText: string = '';
  @Input() noteText: string = '';

  constructor() { }

  ngOnInit(): void {
    console.log('object');
  }

}
