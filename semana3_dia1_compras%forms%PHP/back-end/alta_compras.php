<?php
    $serverName ="localhost";
    $user ="root";
    $pass ="";
    $database ="compras";

    $conn = mysqli_connect($serverName, $user, $pass, $database);

    if(!$conn){
        die("fallo de conexion" . mysqli_connect_error());
    }

    $nombre = $_POST["nombre_art"];
    $cod = $_POST["cantidad_art"];
    $des = $_POST["fechacompra_art"];

    $sql = "INSERT INTO articulos (nombre_art, cantidad_art, fechacompra_art) 
            VALUES ('{$nombre}', '{$cod}', '{$des}', '{$price}')";

    if(mysqli_query($conn, $sql)){
        echo "inserted"
    } else {
        echo "error -->>" . mysqli_error($conn);
    }

    $conn->close();
?>