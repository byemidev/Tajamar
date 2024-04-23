<?php
    session_start();
    if(isset($_SESSION['id_grupo'])){
        
?>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Document</title>
</head>
<body>
    <div class="confirmation">
        <form action="" method="post">
            <button class="logout" onclick="ir a ver un gato"><?php session_destroy(); ?></button>
            <button class="keepsession"> reedireccionar</button>
        </form>
    </div>
<?php }//end if ?>
</body>
</html></div>