import { Injectable } from '@angular/core';

//A dependency can be provided in multiple places:
//3. At the application root level, which allows injecting it into other classes in the application.
//This can be done by adding the providedIn: 'root' field to the @Injectable decorator:
@Injectable({
  providedIn: 'root'
})
export class DependencyInjectionService {
//When you provide the service at the root level,
//Angular creates a single, shared instance of the HeroService and injects it into any class that asks for it.
  constructor() { }
}
//Registering the provider in the @Injectable metadata also allows Angular to optimize an app
//by removing the service from the compiled application if it isn't used, a process known as tree-shaking.
