<?php

    include('gestorDB.php');
    $conn = getConn();
    
    $selection = $_POST["selection"];
        switch($selection){
            case $option="1": 
                echo "1 case";
                showAllArticulos($conn);
                break;
            case $option="2":
                echo "2 case";
                showAllClientes($conn);
                break;
            case $option="3":
                echo "3 case";
                showAllCompras($conn);
                break;
            default: 
                echo "default case";
                break;
        }
    $conn->close();
?>
