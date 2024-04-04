//creo una instancia del elemento con id display
const display = document.getElementById("display");

function appendChildToDisplay(buttonValue){
    display.value += buttonValue; //add to display.value each button value as param
}

function clearDisplay() {
    display.value = ""; //sobrescribe display value as empty string 
}

function calculate(){
    try{
        display.value = Number((eval(display.value).toFixed(6)));
        //Using Numer class function can i use eval(String: string or another function) function to calculate the result of all of the operations  
        //embedded in try clause 
    }catch(error){
        console.log("error");
    }

}