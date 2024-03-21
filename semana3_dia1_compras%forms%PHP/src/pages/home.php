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
        <ul>
            <li>Buscar: <input type="text"></li>
            <li class="button_checkout">Checkout</li>
        </ul>
    </div>
    
    
    <div id="products">
        <!-- PRODUCTS AREA -->
        <?php
            
        ?>
    </div>
    
</body>
</html>