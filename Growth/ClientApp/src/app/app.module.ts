import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ComponentsModule } from "./components/components.module";
import { RouterModule } from '@angular/router';
import { ValueAndReferenceTypesService } from './services/csharp-services/value-and-reference-types.service';
import { DARK_MODE_OPTIONS } from 'angular-dark-mode';

@NgModule({
  declarations: [
    AppComponent
  ],
  exports: [],
  providers: [
    ValueAndReferenceTypesService,
    {
      provide: DARK_MODE_OPTIONS,
      useValue: {
          element: document.documentElement,
          darkModeClass: 'dark-mode',
          lightModeClass: 'light-mode'
      }
  }
  ],
  bootstrap: [AppComponent],
  imports: [
    RouterModule,
    ComponentsModule
  ]
})
export class AppModule { }
