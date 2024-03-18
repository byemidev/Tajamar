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
    $cod = $_POST["codigo_art"];
    $des = $_POST["descripcion_art"];
    $price = $_POST["precio"];

    $sql = "INSERT INTO articulos (nombre_art, codigo_art, descripcion_art, precio) 
            VALUES ('{$nombre}', '{$cod}', '{$des}', '{$price}')";

    if(mysqli_query($conn, $sql)){
        echo "inserted"
    } else {
        echo "error -->>" . mysqli_error($conn);
    }

    $conn->close();
?>