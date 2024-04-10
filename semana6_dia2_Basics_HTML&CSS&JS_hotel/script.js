
//Mostrar form para cliente nuevo cuando btnNewClient is cliked
const btnNewClient = document.getElementById("btnNewClient");
const formNewClient = document.getElementById("form__display__newclient");

btnNewClient.addEventListener("click", () => {
  if (formNewClient.style.visibility === "hidden") {
    formNewClient.style.visibility = "visible";
  } else {
    formNewClient.style.visibility = "hidden";
  }
});

//clase para instanciar objetos de mis clientes
class cliente {
   username;
    constructor(username){
        this.username = username;
    }
}

//formNewCLient y mostrar el login
const btnClient = document.getElementById("btnClient");
btnClient.addEventListener("click" , () => {
    formNewClient.style.visibility = "hidden";
    location.href = "./paginas/reserva.html";
});

formNewClient.addEventListener("submit",(event) => {
  event.preventDefault();
});


