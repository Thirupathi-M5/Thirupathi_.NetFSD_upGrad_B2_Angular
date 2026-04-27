"use strict";
// Problem-1: Build a Reusable Data Manager using Generics in TypeScript
// 1. Generic Function
function getFirstElement(items) {
    return items[0];
}
// 3. Generic Class
class DataManager {
    items = [];
    add(item) {
        this.items.push(item);
    }
    getAll() {
        return this.items;
    }
}
// 5. Use Case - User Management
const userManager = new DataManager();
userManager.add({ id: 1, name: "Thiru" });
userManager.add({ id: 2, name: "Ram" });
console.log("Users:");
console.log(userManager.getAll());
// Use Case - Product Management
const productManager = new DataManager();
productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mouse" });
console.log("Products:");
console.log(productManager.getAll());
// Generic Function Testing
const firstUser = getFirstElement(userManager.getAll());
const firstProduct = getFirstElement(productManager.getAll());
console.log("First User:", firstUser);
console.log("First Product:", firstProduct);
