<?php
  //global function 
  function getConn(){
    $serverName ="localhost";
    $user ="root";
    $pass ="";
    $database ="bdbiblioteca";

    $conn = mysqli_connect($serverName, $user, $pass, $database);

    if(!$conn){
        die("fallo de conexion" . mysqli_connect_error());
    }
    return $conn;
}
?>