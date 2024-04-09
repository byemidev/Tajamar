<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <link rel="stylesheet" href="styles.css">
    <title>Document</title>
</head>
<body class="vista">
    <div id="productos">
    <?php
        include_once('gestorDB.php');
        $conn = getConn();
        $sql = "SELECT* FROM PRODUCTS";
        //recuperar datos de products
        if($result = mysqli_query($conn, $sql)){
            while($row = $result->fetch_assoc()){
                echo '<div class="producto"><label for="producto">'. $row["nomprod"] . '<button onclick="addProductToList(' . $row["idprod"] . ",'" . $row["nomprod"] . "'," . $row["precio"] .')">Add for '. $row["precio"] .'</button></label></div>';
            }
        }
        $conn->close();
    ?>
    </div>
    <div id="carrito">  
        <div id="display"></div>
    </div>
    <div id="resume">
        <label id="total"></label>
    </div>
    <div id="end">
        <button id="ok" onclick="script:alert('compra realizada')">Pagar</button>
    </div>
    <script src="main.js"></script>

</body>
</html>