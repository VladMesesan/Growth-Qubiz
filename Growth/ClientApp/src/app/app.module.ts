import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ComponentsModule } from "./components/components.module";
import { RouterModule } from '@angular/router';
import { ValueAndReferenceTypesService } from './services/csharp-services/value-and-reference-types.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  exports: [],
  providers: [
    ValueAndReferenceTypesService
  ],
  bootstrap: [AppComponent],
  imports: [
    RouterModule,
    ComponentsModule
  ]
})
export class AppModule { }
