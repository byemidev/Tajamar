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
        
        const obj = JSON.stringify(persona); // JSON.stringfy() covert JavaScript objects to JSON string 
        
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


//prueba 3: fetching de datos con async function =>     


const button3 = document.getElementById("get");


//abort controller to manage async response 
const controller  = new AbortController();
const signal = controller.signal;
const url = "https://cdn.jsdelivr.net/gh/akabab/superhero-api@0.3.0/api/all.json";

const timeoutId = setTimeout(() => controller.abort(), 5000);

button3.addEventListener("click", async()=>{
    try{
         const response = await fetch(url, {signal: controller.signal});
         const dataHero = await response.json();
         console.log(`Response:  ${JSON.stringify(dataHero,null, 2)}`); 
    }catch(error){
        console.error(`error in async response ${error.message}`);
    }
});

