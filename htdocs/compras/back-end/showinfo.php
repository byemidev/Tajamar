<?php

    include('gestorDB.php');
    $conn = getConn();
    
    $selection = $_POST["selection"];
        switch($selection){
            case $option="1": 
                showAll($conn, $option);
                break;
            case $option="2":
                showAll($conn, $option);
                break;
            case $option="3":
                showAll($conn, $option);
                break;
            default: 
                echo "default case";
                break;
        }
    $conn->close();
?>
