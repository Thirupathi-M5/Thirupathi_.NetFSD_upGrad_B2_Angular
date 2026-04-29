import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-contact',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './contact.html',
  styleUrls: ['./contact.css']
})
export class ContactComponent {

  contacts: any[] = [];

  newContact = {
    contactId: 0,
    name: '',
    email: '',
    phone: '',
    isActive: false
  };

  onSubmit(form: any) {

    if (form.invalid) return;

    this.newContact.contactId = this.contacts.length + 1;

    this.contacts.push({ ...this.newContact });

    form.resetForm();

    this.newContact = {
      contactId: 0,
      name: '',
      email: '',
      phone: '',
      isActive: false
    };
  }
}