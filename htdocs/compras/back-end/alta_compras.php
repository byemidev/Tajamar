<?php
    
    include_once('gestorDB.php');
    $conn = getConn();

    $idCli = $_POST["idCli"];
    $idArt = $_POST["idArt"];
    $uds = $_POST["uds"];
    $date = $_POST["date"];

    $sql = "INSERT INTO COMPRAS (id_cliente, id_articulo, cantidad, fechacompra) 
            VALUES ('{$idCli}', '{$idArt}', '{$uds}', '{$date}')";

    require_once('gestorDB.php');
    insert($conn, $sql);
    $conn->close();
?>