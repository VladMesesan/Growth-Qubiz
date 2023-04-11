import { Component, NgModule, OnInit } from '@angular/core';
import { DependencyInjectionService } from './dependency-injection.service';

//A dependency can be provided in multiple places:
@Component({
  selector: 'app-dependency-injection',
  templateUrl: './dependency-injection.component.html',
  styleUrls: ['./dependency-injection.component.scss'],
  providers: [DependencyInjectionService]
  //1. When we register a provider at the component level,
  //we get a new instance of the service with each new instance of that particular component.
})
export class DependencyInjectionComponent implements OnInit {

//The most common way to inject a dependency is to declare it in a class constructor.
  constructor(private depInjService: DependencyInjectionService) { }
//When Angular discovers that a component depends on a service, it first checks if the injector has any existing instances of that service.
//If a requested service instance doesn't yet exist, the injector creates one using the registered provider,
//and adds it to the injector before returning the service to Angular.

//When all requested services have been resolved and returned, Angular can call the component's constructor with those services as arguments.
  ngOnInit(): void {
    console.log("dep inj")
  }

}

//2. At the NgModule level, using the providers field of the @NgModule decorator.
@NgModule({
  declarations: [],//DependencyInjectionComponent
  providers: [DependencyInjectionService]
})
class DepInjModule {}
//In this scenario, the HeroService is available to all components, directives, and pipes declared in this NgModule.
