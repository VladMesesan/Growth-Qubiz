import { Component, OnInit } from '@angular/core';
import { DarkModeService } from 'angular-dark-mode';
import { Location } from '@angular/common'
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.scss']
})
export class NavMenuComponent implements OnInit {
  darkMode$ = this.darkModeService.darkMode$;
  isExpanded = false;

  constructor(private darkModeService: DarkModeService,
    private location: Location,
    public router: Router) {}

  ngOnInit() {
    console.log('');
}

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  toggleTheme(): void {
    this.darkModeService.toggle();
  }

  goBack() {
    this.location.back()
  }
}
