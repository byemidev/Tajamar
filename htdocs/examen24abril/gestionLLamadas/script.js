const lista = document.getElementById("lista");
const infos = document.querySelectorAll(".show");

infos.forEach((info) => {
    info.addEventListener("click",(event)=> {
        if(event){
            lista.style.visibility = "visible";
        }
    });    
});

const form = document.querySelector(".form");
const inserts = document.querySelectorAll(".add");

inserts.forEach((insert) => {
  insert.addEventListener("click", (event) => {
    if (event) {
      form.style.visibility = "visible";
      form.querySelector('input[name="id_grupo"]').value = event.target.value;
    }
  });
});


