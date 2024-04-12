//new client
const btnCreateAccount = document.getElementById("btn-create-account");
const btnClient = document.getElementById("btn-client");
//botones dentro de forms
const form = document.querySelector("form");
const btnSubmit = document.getElementById("submit");

//revisar no funciona 
const toRegistry = document.getElementsById("toResgistry");

btnClient.addEventListener("click", () => {
  toRegistry.style.visibility = "hidden";
});

// Mostrar form para cliente nuevo cuando btnNewClient is clicked
btnCreateAccount.addEventListener("click", () => {
  if (toRegistry.style.visibility === "hidden") {
    toRegistry.style.visibility = "visible";
  }
});
