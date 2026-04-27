// variable declarations

const userName:string="Jhon";
let age:number=25;
const email:string="john@example.com";
const isSubscribed:boolean=true;

//type interface

let city="hyderabad";
let loginCount=5;

age=age+1;
const profileMessage:string=`Hello ${userName}, you are ${age} years old and your email is ${email}.`;

const isPremiumEligible: boolean=age>18 && isSubscribed;

const isAdult:boolean=age>=18;
const isTeenager: boolean = age < 20;

const canAccessOffers: boolean = isSubscribed || age > 30;

console.log("User Name:", userName);console.log("Age:", age);console.log("Email:", email);console.log("Subscribed:", isSubscribed);console.log("City:", city);console.log("Login Count:", loginCount);console.log(profileMessage);console.log("Premium Eligible:", isPremiumEligible);console.log("Is Adult:", isAdult);console.log("Is Teenager:", isTeenager);console.log("Can Access Offers:", canAccessOffers);