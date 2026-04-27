// Problem-1: Build a Reusable Data Manager using Generics in TypeScript

// 1. Generic Function
function getFirstElement<T>(items: T[]): T {
    return items[0];
}


// 2. Generic Interface
interface Repository<T> {
    add(item: T): void;
    getAll(): T[];
}


// 3. Generic Class
class DataManager<T> implements Repository<T> {
    private items: T[] = [];

    add(item: T): void {
        this.items.push(item);
    }

    getAll(): T[] {
        return this.items;
    }
}


// 4. Models

interface User {
    id: number;
    name: string;
}

interface Product {
    id: number;
    title: string;
}


// 5. Use Case - User Management

const userManager = new DataManager<User>();

userManager.add({ id: 1, name: "Thiru" });
userManager.add({ id: 2, name: "Ram" });

console.log("Users:");
console.log(userManager.getAll());


// Use Case - Product Management

const productManager = new DataManager<Product>();

productManager.add({ id: 101, title: "Laptop" });
productManager.add({ id: 102, title: "Mouse" });

console.log("Products:");
console.log(productManager.getAll());


// Generic Function Testing

const firstUser = getFirstElement(userManager.getAll());
const firstProduct = getFirstElement(productManager.getAll());

console.log("First User:", firstUser);
console.log("First Product:", firstProduct);