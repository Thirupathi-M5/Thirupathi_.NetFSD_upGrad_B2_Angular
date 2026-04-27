"use strict";
// Problem -3: Basic Employee Management Module using TypeScript Classes
// Base Class: Employee
class Employee {
    id;
    name;
    salary;
    constructor(id, name, salary) {
        this.id = id;
        this.name = name;
        this.salary = salary;
    }
    // Getter
    getSalary() {
        return this.salary;
    }
    // Setter with validation
    setSalary(value) {
        if (value > 0) {
            this.salary = value;
        }
        else {
            console.log("Salary must be greater than 0");
        }
    }
    // Method
    displayDetails() {
        console.log("Employee Details");
        console.log("ID:", this.id);
        console.log("Name:", this.name);
        console.log("Salary:", this.salary);
    }
}
// Derived Class: Manager
class Manager extends Employee {
    teamSize;
    constructor(id, name, salary, teamSize) {
        super(id, name, salary);
        this.teamSize = teamSize;
    }
    // Method Overriding
    displayDetails() {
        console.log("Manager Details");
        console.log("ID:", this.id);
        console.log("Name:", this.name);
        console.log("Salary:", this.getSalary());
        console.log("Team Size:", this.teamSize);
    }
}
// Object Creation
// Employee Object
let emp1 = new Employee(101, "Thiru", 30000);
emp1.displayDetails();
console.log("Current Salary:", emp1.getSalary());
emp1.setSalary(35000);
console.log("Updated Salary:", emp1.getSalary());
// Manager Object
let mgr1 = new Manager(201, "Ram", 60000, 8);
mgr1.displayDetails();
