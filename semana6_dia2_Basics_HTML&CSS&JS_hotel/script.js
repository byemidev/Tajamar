//new client
const btnCreateAccount = document.getElementById("btn-create-account");
const formCreateAccount = document.getElementById("form-create-account");
//client
const btnClient = document.getElementById("btn-client");
const formLogin = document.getElementById("form-login");
//botones dentro de forms
const btnLogin = document.getElementById("btn-login");
const btnNew = document.getElementById("btn-new");
btnClient.addEventListener("click", () => {
  formLogin.style.visibility = "visible";
  btnLogin.style.visibility = "visible";
  btnLogin.setAttribute("type", "submit");
  formCreateAccount.style.visibility = "hidden";
});

// Mostrar form para cliente nuevo cuando btnNewClient is clicked
btnCreateAccount.addEventListener("click", () => {
  if (formCreateAccount.style.visibility === "hidden") {
    formCreateAccount.style.visibility = "visible";
    formLogin.style.visibility = "visible";
    btnLogin.style.visibility = "hidden";
    btnLogin.removeAttribute("type");
    btnNew.setAttribute("type", "submit");
  }
});
