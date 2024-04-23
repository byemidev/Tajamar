<?php
session_start();

//capturando id de grupo para completar form
if (!isset($_SESSION['id_group'])) {
    echo "<script>console.log('ningun valor para id_group capturado(desde registro.php)');</script>";
} else {
    //all code bellow
    if($submit = $_POST['submit']) {

        $nombre = $_POST['nombre'];
        $desc = $_POST['desc'];

    
        header('Location: confirmacion.php');
        exit;
    } else {
        echo "<script>console.log();</script>";
    }
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Registro</title>
</head>
<body>
    <form action="" method="post">
        <label for="nombre">Nombre:<input name="nombre" type="text" placeholder="aqui nombre"></label>
        <label for="desc">Descripcion: <textarea id="desc" name="desc" type="text"></textarea></label>
        <button id="submit" name="submit">Registrar</button>
    </form>
</body>
</html>