//creo una instancia del elemento con id display
const display = document.getElementById("display");

var calculado = false;

function appendChildToDisplay(buttonValue){
    if(calculado){
        display.value = "";
        calculado = false;        
    }
        display.value += buttonValue; //add to display.value each button value as param
}

function clearDisplay() {
    display.value = ""; //sobrescribe display value as empty string 
}

function calculate(){
    try{
        display.value = Number((eval(display.value).toFixed(6)));
        calculado = true;
        //Using Numer class function can i use eval(String: string or another function) function to calculate the result of all of the operations  
        //embedded in try clause 
    }catch(error){
        console.log("error");
    }
}


function calculateV2(){
    var operations = ['+','-','*','/'];
    let displayValue = display.value;
    let displayAsCharArr = displayValue.split(""); 

    displayAsCharArr.forEach(char => {
        num1 += char;
        operations.forEach(operation => {
            if(char == operation ){
                switch(operation){
                    case '+':
                        console.log("estas sumando " + num1 + "+" + num2);
                        break;
                        case '-':
                        console.log("estas restando");
                        break;
                        case '*':
                        console.log("estas multiplicando");
                        break;
                        case '/': 
                        console.log("estas dividiendo");
                        break;
                }
            }
        });
    });
}