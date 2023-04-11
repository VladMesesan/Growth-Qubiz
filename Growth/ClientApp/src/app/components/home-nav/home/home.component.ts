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
          lessons: ['Passing parameters', 'Value type', 'Reference type', 'Boxing & Unboxing', 'LINQ']
        },
        {
          chapter: 'OOP',
          lessons: ['Class vs Object', 'SOLID', 'Abstraction', 'Inheritance', 'Encapsulation', 'Polymorphism']
        },
        {
          chapter: 'Dependency Injection',
          lessons: ['Inversion of control', 'IoC Container', 'DI with C#', 'DI with Angular']
        },
        {
          chapter: 'Angular',
          lessons: ['Modules', 'Components', 'Data-Binding', 'Services', 'Communication/Interaction between all of the above', 'Reactive forms', 'Angular Lifecycle hooks', 'Observables - RxJs', 'Unit-Tests']
        },
        {
          chapter: 'SQL',
          lessons: ['At least one course on SQL', 'Between 15-20 scripts on the Darwin databases']
        },
        {
          chapter: 'Mongo DB',
          lessons: ['At least one course on Mongo', 'Between 15-20 scripts on the Darwin databases']
        },
        {
          chapter: 'Clean Code',
          lessons: ['Project coding standards', 'DRY/KISS/YAGNI Principles', 'Refactoring']
        },
        {
          chapter: 'Debugging',
          lessons: ['Event Viewer', 'Client Errors', 'Call Stack', 'Try/Catch', 'Conditional breakpoints', 'Getter/Setter breakpoints']
        },
        {
          chapter: 'Coding for success',
          lessons: ['Readbility', 'Testability']
        },
        {
          chapter: 'Test Driven Development',
          lessons: ['Unit Tests', 'Integration Tests']
        },
        {
          chapter: 'Project related items',
          lessons: ['No more than one change per item/area during code review', 'Future work should not contain issues already identified in previous code reviews', 'All stories have estimates and we stick to them in optimal conditions (when nothing changes from business, UX)', 'Understand project architecture and be able to explain it', 'No P1 and P2 bugs']
        },
        {
          chapter: 'Owner of your work',
          lessons: ['Involve appropriate stakeholders in each epic', 'Start to end development cycle of the story', 'Coordinate the investigation of the story/epic', 'Communication with the stakeholders should be clear and addapted to their technical skills', 'Constructive attitude towards feedback', 'Proactivity, challenge requirements with strong arguments and try to explain them in a positive way', 'Code complete']
        }
      ]
    },
    {
      phaseName: 'PHASE II',
      growthArray: [
        {
          chapter: 'In depth architecture understanding',
          lessons: ['Understand what SOA is and how services interact', 'Principles of SOA', 'SOA Patterns', 'Implementation approches', 'The iDesign Method', 'Build a small application that adheres to the SOA standards ', 'The above application should also be documented with high level SOA diagrams']
        },
      ]
    },
    {
      phaseName: 'PHASE III',
      growthArray: [
        {
          chapter: 'Performance testing and Profiling',
          lessons: ['Visual Studio Web and Load testing', 'Visual Studio Performace Profiler', 'SQL Server Profiler', 'Using available tools to detect performance issues']
        },
        {
          chapter: 'Design patterns',
          lessons: ['Abstract Factory', 'Singleton', 'Proxy', 'Mediator', 'Observer', 'Chain of Responsibility']
        },
      ]
    },
    {
      phaseName: 'PHASE IV',
      growthArray: [
        {
          chapter: 'WCF/gRPC',
          lessons: ['What is WCF', 'What is gRPC', 'What are the similarities between WCF and gRPC', 'What are the differences between WCF and gRPC', 'Small SOA based on WCF', 'Small SOA based on gRPC']
        },
        {
          chapter: 'MSMQ/RabbitMQ',
          lessons: ['What is MSMQ', 'What is RabbitMQ', 'What are the similarities between MSMQ and RabbitMQ', 'What are the differences between MSMQ and RabbitMQ', 'Small application based on WCF', 'Small application based on gRPC']
        },
      ]
    }
  ];


  ngOnInit(): void {
    console.log('Test');
  }
}
