"use strict";
// variable declarations
const userName = "Jhon";
let age = 25;
const email = "john@example.com";
const isSubscribed = true;
//type interface
let city = "hyderabad";
let loginCount = 5;
age = age + 1;
const profileMessage = `Hello ${userName}, you are ${age} years old and your email is ${email}.`;
const isPremiumEligible = age > 18 && isSubscribed;
const isAdult = age >= 18;
const isTeenager = age < 20;
const canAccessOffers = isSubscribed || age > 30;
console.log("User Name:", userName);
console.log("Age:", age);
console.log("Email:", email);
console.log("Subscribed:", isSubscribed);
console.log("City:", city);
console.log("Login Count:", loginCount);
console.log(profileMessage);
console.log("Premium Eligible:", isPremiumEligible);
console.log("Is Adult:", isAdult);
console.log("Is Teenager:", isTeenager);
console.log("Can Access Offers:", canAccessOffers);
