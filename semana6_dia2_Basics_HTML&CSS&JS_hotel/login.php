<?php
// Step 1: Connect to the MySQL database
require_once('gestorDB.php');
$conn = getConn();

// Step 2: Write a SQL query to retrieve the data from the database table
$sql = "SELECT * FROM USUARIOS WHERE user = ?";

// Step 3: Prepare the statement and bind the parameter
$stmt = $conn->prepare($sql);
$stmt->bind_param("s", $_POST['user']);

// Step 4: Execute the statement and fetch the result set
$stmt->execute();
$result = $stmt->get_result();
$user = $result->fetch_assoc();

// Step 5: Compare the form data with the fetched data
if ($user) {
    // The username exists in the database
    if ($user['pass'] === $_POST['pass']) {
        // The password is correct
        session_start();
        $_SESSION['id_cliente'] = $user['id_cliente'];
        $_SESSION['id_usuario'] = $user['id_usuario'];
        $_SESSION['user'] = $user['user'];
        header("Location: ../src/pages/home.php");
        exit();
    } else {
        // The password is incorrect
        header("Location: ../index.html");
    } 
}else {
    // The username does not exist in the database
    header("Location: ../index.html");
}
$conn->close();
?>
