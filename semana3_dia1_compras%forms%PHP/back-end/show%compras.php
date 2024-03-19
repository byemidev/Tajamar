<?php

    require_once('getConn.php')
    $conn = getConn();

    $nombre = $_POST["nombre_art"];
    $cod = $_POST["codigo_art"];
    $des = $_POST["descripcion_art"];
    $price = $_POST["precio"];

    $sql = ;//todo 

    //TODO: make if and nested while to iterate in the array

    $conn->close();
?>