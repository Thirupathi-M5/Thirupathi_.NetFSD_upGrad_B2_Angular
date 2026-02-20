let amount=6000
let discount= 0;
let finalamount = 0;

if (amount>=5000){
    discount=amount*0.20

}
else if (amount>= 3000){
    discount=amount*0.10
}

else{
    discount=0;
}

finalamount=amount-discount
console.log("Price:" + amount)
console.log("Discount:" + discount)
console.log("finalamount:" + finalamount)