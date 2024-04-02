//inicializo a false
let clicked = false;

const price = document.getElementById("price");

//escucho un evento esperando que hagan click
document.getElementById("button").addEventListener("click", () => {
    clicked = true; //sobreescribo clicked a true
    if(clicked){//esto siempre se cumple por que clicked es true == if(true)
        setInterval(() => {//Cambiar por setTimeOut () quiero que la respuesta al evento sea algo mas tardia "estoy esperando una validacion externa, lectura de un fichero, .. o quiero animar con una pantalla de carga"
            const nombre = "Hola " + document.getElementById("ip").value;
            const nameDisplay = document.getElementById("nameDisplay");
            nameDisplay.textContent = nombre;
        }, 2000);
    }

    const input = document.getElementById("price");
    if(input && input.value){
        if(isIVA()){
            console.log("has seleccionado IVA");
        }else{//is base
            console.log("has seleccionado Base");
        }
    }
    

});

function isIVA(){
   return document.getElementById("IVA").checked;
}