const IVA = 0.21;
const  price = document.getElementById("price");

//escucho un evento esperando que hagan click
let clicked = false;
document.getElementById("button").addEventListener("click", () => {
    clicked = true; //sobreescribo clicked a true
    if(clicked){//esto siempre se cumple por que clicked es true == if(true)
        setInterval(() => {//Cambiar por setTimeOut () quiero que la respuesta al evento sea algo mas tardia "estoy esperando una validacion externa, lectura de un fichero, .. o quiero animar con una pantalla de carga"
            const saludo = "Bienvenido  " + document.getElementById("ip").value + " cargando datos .. ";
            const nameDisplay = document.getElementById("nameDisplay");
            nameDisplay.textContent = saludo;
            if(price && price.value){//existe price y tiene valor ?
                if(isIVA()){
                    console.log("has seleccionado IVA");
                    let p =  parseFloat(price.value) * IVA; //uso parseFloat() para la entrada tipo texto hacerla float y operar
                    console.log(p);
                    displayValue(p);
                }else{//is base
                    console.log("has seleccionado Base");
                    let p =  parseFloat(price.value) / (1 + IVA);
                    console.log(p);
                    displayValue(p);
                }
            }
        }, 1000);
    }
});

function isIVA(){
   return document.getElementById("IVA").checked;
}

function displayValue(p){
    const nameDisplay = document.getElementById("value");
    nameDisplay.textContent = Number((p).toFixed(2));
}

//calculadora
const display = document.getElementById("display");

function appendChildToDisplay(num){
    display.value += num;
}

function clearDisplay() {
    display.value = "";
}

function calculate(){
    try{
        display.value = Number((eval(display.value).toFixed(6)));// eval es una funcion de js para evaluar expresiones regulares dentro de una cadena y operar
    }catch {
        console.log("error");
    }

}