<?php
    //necesito getConn.php
    require_once('getConn.php')
    $conn = getConn();//obtengo la conexion 
    
    //reocojo los datos del formulario
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