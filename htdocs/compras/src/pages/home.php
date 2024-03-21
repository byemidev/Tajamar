<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="../css/home_styles.css">
    <title>home</title>
</head>
<body id="grid_home">
    <div id="welcome">
    <?php
        //start the session 
        session_start();
        //check if the user is logged 
        if(isset($_SESSION['user']) && isset($_SESSION['id_usuario']) && isset($_SESSION['id_cliente'])){
            //display user name 
            echo '<p>Welcome</br> <spam style="font-size:50px;">' . $_SESSION['user'] . ' </spam> </p>';
        }else {
            //
        }
        
    ?>
    </div>

    <div id="nav">
        <!-- NAVIGATOR : search prduct by name , checkout -->
        <?php
            function filterTableData($input) {
                require_once('../../back-end/gestorDB.php');
                $conn = getConn();
                $sql = "SELECT * FROM ARTICULOS WHERE nombre_art LIKE '$input%'";
                $result = mysqli_query($conn, $sql);
                return $result;
            }
        ?>
        <ul> <!--si pulso deberia filtrar llamando a la funcion de arriba -->
            <li><input type="text"></li>
            <li action="" class="button_checkout">Buscar</li>
        </ul>
    </div>
    
    
    <div id="products" class="gallery">
        <!-- PRODUCTS AREA -->
        <?php
        include_once('../../back-end/gestorDB.php');
        $conn = getConn();

        // SQL query
        $sql = "SELECT * FROM articulos";
        

        // Execute query
        $result = mysqli_query($conn, $sql);

        // Check for results
        if (mysqli_num_rows($result) > 0) {
            // Output data of each row
            while($row = mysqli_fetch_assoc($result)) {
                echo '<div class="item">' . "<img src='{$row['imgpath']}'></img>" . '<label>' . $row["nombre_art"] . "</label><p>Descripción:</br>" . $row["descripcion_art"]. '<span>'. $row["precio"] . '€</span><button id="add"></button></div>';
            }
        } else {
            echo "No results found.";
        }
        // Close connection
        $conn->close();
        ?>
    </div>
    
</body>
</html>