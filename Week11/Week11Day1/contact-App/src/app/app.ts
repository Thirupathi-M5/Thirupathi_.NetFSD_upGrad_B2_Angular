import { Component } from '@angular/core';
import { ReactiveContact } from './reactive-contact/reactive-contact';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [ReactiveContact],
  templateUrl: './app.html'
})
export class App {}