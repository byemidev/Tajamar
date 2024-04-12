<?php
        //obtiene la conexion OK 
    function getConn(){
        $serverName ="localhost";
        $user ="root";
        $pass ="";
        $database ="carrito";

        $conn = mysqli_connect($serverName, $user, $pass, $database);

        if(!$conn){
            die("fallo de conexion" . mysqli_connect_error());
        }
    return $conn;
    }
?>