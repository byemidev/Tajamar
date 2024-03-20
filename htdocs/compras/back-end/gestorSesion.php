<?php
    //necesito conexion a la base de datos 
    require_once('gestorDB.php');
    $conn = getConn();

    //necesito comprobar si el usuario existe (nombre_usu) podria teneer una tabla usuarios , que tengan un id_cliente asociado a la tabla clientes
    // Get the form data
    $user = $_POST['user'];
    $pass = $_POST['pass'];

    // Create a prepared statement
    $stmt = $conn->prepare("SELECT * FROM USUARIOS WHERE username=? AND password=?");

    // Bind parameters
    $stmt->bind_param("ss", $user, $pass);

    // Execute the statement
    $stmt->execute();

    // Get the result
    $result = $stmt->get_result();

    // Check if a user was found
    if ($result->num_rows > 0) {
        // Start the session and store the user's username
        session_start();
        $_SESSION['username'] = $user;

        // Redirect to the dashboard or wherever you want the user to go after logging in
        header("Location: dashboard.php");
    } else {
        // If no user was found, show an error message
        echo "Invalid username or password.";
    }

    // Close the statement and the connection
    $stmt->close();
    $conn->close();
    //debo guardar al menos el id de la sesion y los productos que ha comprado o esta comprando

    //al cerrar sesion se perdera lo que esta haciendo ya que no lo estoy guardando ni en cache ni en base de datos 
?>