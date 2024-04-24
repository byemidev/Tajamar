const btnVolver = document.getElementById('btn-volver');

btnVolver.addEventListener("click", (event) => {
  console.log('se esta produciendo el evento');
  window.location.href = "index.php";
});
