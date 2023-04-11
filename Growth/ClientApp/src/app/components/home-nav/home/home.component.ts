import { Component, OnInit } from '@angular/core';
import { Growth, Phase } from 'src/app/models/interfaces';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  constructor() { }

  phaseData: Phase[] = [
    {
      phaseName: 'PHASE I',
      growthArray: [
        {
          chapter: 'C#',
          lessons: [{ name: 'Passing parameters', link: '/passing-params' }, { name: 'Value type', link: '/value-and-reference' }, { name: 'Reference type', link: '/value-and-reference' }, { name: 'Boxing & Unboxing', link: '/box-and-unbox' }, { name: 'LINQ', link: '/linq-link' }]
        },
        {
          chapter: 'OOP',
          lessons: [{ name: 'Class vs Object', link: '/class-vs-object' }, { name: 'SOLID', link: '/solid-link' }, { name: 'Abstraction', link: '/oop-principles' }, { name: 'Inheritance', link: '/oop-principles' }, { name: 'Encapsulation', link: '/oop-principles' }, { name: 'Polymorphism', link: '/oop-principles' }]
        },
        {
          chapter: 'Dependency Injection',
          lessons: [{ name: 'Inversion of control', link: '/home' }, { name: 'IoC Container', link: '/home' }, { name: 'DI with C#', link: '/home' }, { name: 'DI with Angular', link: '/dep-inj-angular' }]
        },
        {
          chapter: 'Angular',
          lessons: [{ name: 'Modules', link: '/home' }, { name: 'Components', link: '/home' }, { name: 'Data-Binding', link: '/home' }, { name: 'Services', link: '/home' }, { name: 'Communication/Interaction between all of the above', link: '/home' }, { name: 'Reactive forms', link: '/home' }, { name: 'Angular Lifecycle hooks', link: '/home' }, { name: 'Observables - RxJs', link: '/home' }, { name: 'Unit-Tests', link: '/home' }]
        },
        {
          chapter: 'SQL',
          lessons: [{ name: 'At least one course on SQL', link: '/home' }, { name: 'Between 15-20 scripts on the Darwin databases', link: '/home' }]
        },
        {
          chapter: 'Mongo DB',
          lessons: [{ name: 'At least one course on Mongo', link: '/home' }, { name: 'Between 15-20 scripts on the Darwin databases', link: '/home' }]
        },
        {
          chapter: 'Clean Code',
          lessons: [{ name: 'Project coding standards', link: '/home'}, {name:'DRY/KISS/YAGNI Principles', link: '/home'}, {name:'Refactoring', link: '/home'}]
        },
        {
          chapter: 'Debugging',
          lessons: [{ name: 'Event Viewer', link: '/home'}, {name:'Client Errors', link: '/home'}, {name:'Call Stack', link: '/home'}, {name:'Try/Catch', link: '/home'}, {name:'Conditional breakpoints', link: '/home'}, {name:'Getter/Setter breakpoints', link: '/home'}]
        },
        {
          chapter: 'Coding for success',
          lessons: [{name:'Readbility', link: '/home'}, {name:'Testability', link: '/home'}]
        },
        {
          chapter: 'Test Driven Development',
          lessons: [{name:'Unit Tests', link: '/home'}, {name:'Integration Tests', link: '/home'}]
        },
        {
          chapter: 'Project related items',
          lessons: [{name:'No more than one change per item/area during code review', link: '/home'}, {name:'Future work should not contain issues already identified in previous code reviews', link: '/home'}, {name:'All stories have estimates and we stick to them in optimal conditions (when nothing changes from business, UX)', link: '/home'}, {name:'Understand project architecture and be able to explain it', link: '/home'}, {name:'No P1 and P2 bugs', link: '/home'}]
        },
        {
          chapter: 'Owner of your work',
          lessons: [{name:'Involve appropriate stakeholders in each epic', link: '/home'}, {name:'Start to end development cycle of the story', link: '/home'}, {name:'Coordinate the investigation of the story/epic', link: '/home'}, {name:'Communication with the stakeholders should be clear and addapted to their technical skills', link: '/home'}, {name:'Constructive attitude towards feedback', link: '/home'}, {name:'Proactivity, challenge requirements with strong arguments and try to explain them in a positive way', link: '/home'}, {name:'Code complete', link: '/home'}]
        }
      ]
    },
    {
      phaseName: 'PHASE II',
      growthArray: [
        {
          chapter: 'In depth architecture understanding',
          lessons: [{name:'Understand what SOA is and how services interact', link: '/home'}, {name:'Principles of SOA', link: '/home'}, {name:'SOA Patterns', link: '/home'}, {name:'Implementation approches', link: '/home'}, {name:'The iDesign Method', link: '/home'}, {name:'Build a small application that adheres to the SOA standards ', link: '/home'}, {name:'The above application should also be documented with high level SOA diagrams', link: '/home'}]
        },
      ]
    },
    {
      phaseName: 'PHASE III',
      growthArray: [
        {
          chapter: 'Performance testing and Profiling',
          lessons: [{name:'Visual Studio Web and Load testing', link: '/home'}, {name:'Visual Studio Performace Profiler', link: '/home'}, {name:'SQL Server Profiler', link: '/home'}, {name:'Using available tools to detect performance issues', link: '/home'}]
        },
        {
          chapter: 'Design patterns',
          lessons: [{name:'Abstract Factory', link: '/home'}, {name:'Singleton', link: '/home'}, {name:'Proxy', link: '/home'}, {name:'Mediator', link: '/home'}, {name:'Observer', link: '/home'}, {name:'Chain of Responsibility', link: '/home'}]
        },
      ]
    },
    {
      phaseName: 'PHASE IV',
      growthArray: [
        {
          chapter: 'WCF/gRPC',
          lessons: [{name:'What is WCF', link: '/home'}, {name:'What is gRPC', link: '/home'}, {name:'What are the similarities between WCF and gRPC', link: '/home'}, {name:'What are the differences between WCF and gRPC', link: '/home'}, {name:'Small SOA based on WCF', link: '/home'}, {name:'Small SOA based on gRPC', link: '/home'}]
        },
        {
          chapter: 'MSMQ/RabbitMQ',
          lessons: [{name:'What is MSMQ', link: '/home'}, {name:'What is RabbitMQ', link: '/home'}, {name:'What are the similarities between MSMQ and RabbitMQ', link: '/home'}, {name:'What are the differences between MSMQ and RabbitMQ', link: '/home'}, {name:'Small application based on WCF', link: '/home'}, {name:'Small application based on gRPC', link: '/home'}]
        },
      ]
    }
  ];


  ngOnInit(): void {
    console.log('/home');
  }
}
