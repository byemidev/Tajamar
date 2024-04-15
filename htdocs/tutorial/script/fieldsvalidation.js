
//textbox validation 
const textboxes = document.querySelectorAll("input[type=text]");
const form = document.querySelector("form");


form.addEventListener("submit", (event) => {
    textboxes.forEach(element => {
        if(!onlyTextValid(element)){
            element.checkVisibility
        }
    });
});


const emailRegex =  /^[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?$/;
function onlyTextValid(input){
    return emailRegex.test(input);
}

const poneRegex = /^\d{9}$/;

const onlyTextRegex = /^[a-zA-Z]{1,90}$/;


