import { calculateTotal } from "./cart.js";

const { cart, totalValue } = calculateTotal();

console.log("---------Invoice-------")
cart.forEach(item => {
    console.log(
        `${item.name} | Price : ${item.price} | Qty: ${item.quantity} | Total: ${item.price * item.quantity}`

    )
})

console.log(`------------------------`)
console.log(`Grand Total: ${totalValue}`)