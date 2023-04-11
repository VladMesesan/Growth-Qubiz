import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home-nav/home/home.component';
import { HttpClientModule } from '@angular/common/http';
import { MatButtonModule, MatCheckboxModule, MatIconModule, MatMenuModule, MatTooltipModule } from '@angular/material';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { LinqComponent } from './c-sharp/linq/linq.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { BoxAndUnboxComponent } from './c-sharp/box-and-unbox/box-and-unbox.component';
import { PassingParamsComponent } from './c-sharp/passing-params/passing-params.component';
import { ValueAndReferenceTypesComponent } from './c-sharp/value-and-reference-types/value-and-reference-types.component';
import { NavMenuComponent } from './home-nav/nav-menu/nav-menu.component';
import { SolidComponent } from './oop/solid/solid.component';
import { ClassVsObjectComponent } from './oop/class-vs-object/class-vs-object.component';
import { OopPrinciplesComponent } from './oop/oop-principles/oop-principles.component';
import { DependencyInjectionComponent } from './dependency-injection/dependency-injection.component';

@NgModule({
  declarations: [
    HomeComponent,
    NavMenuComponent,
    ValueAndReferenceTypesComponent,
    PassingParamsComponent,
    LinqComponent,
    BoxAndUnboxComponent,
    SolidComponent,
    ClassVsObjectComponent,
    OopPrinciplesComponent,
    DependencyInjectionComponent
  ],
  imports: [
    CommonModule,
    BrowserAnimationsModule,
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'value-and-reference', component: ValueAndReferenceTypesComponent },
      { path: 'passing-params', component: PassingParamsComponent },
      { path: 'box-and-unbox', component: BoxAndUnboxComponent },
      { path: 'linq-link', component: LinqComponent },
      { path: 'class-vs-object', component: ClassVsObjectComponent },
      { path: 'oop-principles', component: OopPrinciplesComponent },
      { path: 'solid-link', component: SolidComponent },
      { path: 'dep-inj-angular', component: DependencyInjectionComponent },
    ]),
    HttpClientModule,
    FormsModule,
    MatButtonModule,
    MatTooltipModule,
    MatMenuModule,
    MatIconModule,
    MatCheckboxModule
  ],
  exports: [
    ValueAndReferenceTypesComponent,
    PassingParamsComponent,
    HomeComponent,
    NavMenuComponent
  ]
})
export class ComponentsModule { }
