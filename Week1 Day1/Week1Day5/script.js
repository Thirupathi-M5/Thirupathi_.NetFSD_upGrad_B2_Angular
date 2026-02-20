let counter =0

function updateDisplay(){
    document.getElementById("count").innerHTML=counter
}

function incrementCounter(step){
    counter=counter+step
    updateDisplay();
}

function resetCounter(){
    counter=0
    updateDisplay()
}

document.getElementById("incrementbtn").addEventListener("click",function(){incrementCounter(1)})
document.getElementById("resetbtn").addEventListener("click",resetCounter);