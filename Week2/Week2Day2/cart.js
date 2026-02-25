const cart =[
    { name: "Laptop", price: 65000, quantity: 1},
    {name: "Mouse", price: 650, quantity:2},
    {name:"Keyboard", price:1400, quantity: 1},
    {name:"Cable", price:400, quantity: 2},
    {name:"Dongle", price:900, quantity: 3},
    {name:"CPU", price:5000, quantity: 1}
]

export const calculateTotal =()=>{
    const itemTotal = cart.map(item => item.price*item.quantity)
    const totalValue = itemTotal.reduce((sum, value) => sum + value,0)

    return{
        cart,
        totalValue
    }
}