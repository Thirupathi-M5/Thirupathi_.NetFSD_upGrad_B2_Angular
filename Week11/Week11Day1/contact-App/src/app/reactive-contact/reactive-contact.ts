import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-reactive-contact',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './reactive-contact.html',
  styleUrl: './reactive-contact.css'
})
export class ReactiveContact {

  contactForm: FormGroup;
  contacts: any[] = [];

  constructor(private fb: FormBuilder) {
    this.contactForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', [Validators.required, Validators.minLength(10)]],
      isActive: [false]
    });
  }

  onSubmit() {
    if (this.contactForm.invalid) {
      this.contactForm.markAllAsTouched();
      return;
    }

    const newContact = {
      contactId: this.contacts.length + 1,
      ...this.contactForm.value
    };

    this.contacts.push(newContact);

    this.contactForm.reset({
      isActive: false
    });
  }

  get f() {
    return this.contactForm.controls;
  }
}