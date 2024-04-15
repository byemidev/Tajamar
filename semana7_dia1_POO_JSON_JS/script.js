//prueba 1: escritura de objetos con stringfy() en localstorage

const button = document.getElementById("escribir");

button.addEventListener("click", (event) => {
    if(event.target){
        var persona = {
            nombre:"emilio",
            apellido1: "arevalo",
            apellido2: "zuniga",
        }
        
        console.log(persona);
        
        const obj = JSON.stringify(persona);
        
        localStorage.setItem("personas.json", obj);
        
        console.log("escrito");
    }
});

//prueba 2: lectura de objetos con stringfy() en localstorage
const button2 = document.getElementById("leer");

button2.addEventListener("click",(event)=>{
    if(event.target){
        for(var i=0; i < localStorage.length; i++){
            var key = localStorage.key(i);
            var item = JSON.parse(localStorage.getItem  ( key ) );

            console.log(`leyendo ${item.nombre} , ${item.apellido1}`);
        }
    }
}); 


//prueba 3: fetching de datos con async function => https://akabab.github.io/superhero-api/api/#alljson 


//abort controller to manage async response 
const button3 = document.getElementById("get");


const controller  = new AbortController();
const signal = controller.signal;
const url = "https://akabab.github.io/superhero-api/api/all.json";

const timeoutId = setTimeout(() => controller.abort(), 5000);

button3.addEventListener("click", async()=>{
    try{
         const response = await fetch(url, {signal: controller.signal});
         const json = response.json();
         console.log(`completed:  ${json}`);
    }catch(error){
        console.error(`error in async response ${error.message}`);
    }
});

