<?php 
   session_start();
?>
<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link
      href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"
      rel="stylesheet"
      integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"
      crossorigin="anonymous"
    />
    <link rel="stylesheet" href="styles/styles.css" />
    <title>Home</title>
  </head>
  <body>
    <nav class="navbar navbar-expand-lg bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand" href=".">HOME</a>
        <button
          class="navbar-toggler"
          type="button"
          data-bs-toggle="collapse"
          data-bs-target="#navbarNav"
          aria-controls="navbarNav"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span class="navbar-toggler-icon"></span>
        </button>
        
<?php
  //aqui codigo para botton reserva solo si tiene un id de session $_SESSION 
?>
        <div class="collapse navbar-collapse" id="navbarNav">
          <ul class="navbar-nav">
            <li class="nav-item">
              <a
                class="nav-link active"
                aria-current="page"
                href="reservas.php"
                >Reservas</a
              >
            </li>
          </ul>
        </div>

      </div>
    </nav>
    <div class="container text-center">
      <div class="row align-items-start">
        <div class="row align-items-start">
          <div class="col side1">
            <img src="./src/img/bghotel.png" alt="background" />
          </div>
            <?php
             
              include("php/config.php");
            
              if(isset($_POST['submit'])){
            
                $username = mysqli_real_escape_string($con,$_POST['username']);
                $password = mysqli_real_escape_string($con,$_POST['password']);

                $result = mysqli_query($con,"SELECT * FROM users WHERE username='$username' AND Password='$username' ") or die("Select Error");
            
                $row = mysqli_fetch_assoc($result);

                if(is_array($row) && !empty($row)){
                    $_SESSION['valid'] = $row['username'];
                    $_SESSION['firstname'] = $row['firstname'];
                    $_SESSION['lastname'] = $row['lastname'];
                    $_SESSION['age'] = $row['age'];
                    $_SESSION['id'] = $row['id'];
                }else{
                    echo "<div class='message'>
                      <p>Error en usuario o contraseña</p>
                        </div> <br>";
                    echo '<a href="index.php"><button id="btn-new" class="btn btn-primary">Volver a intentarlo</button>';
          
                }
                if(isset($_SESSION['valid'])){
                  echo 'script:console.log("reedirigiendo");';
                    header("Location: reservas.php");
                }
              }else{
            //parece que la logica esta bien pero no esta checkeando si hay algun error o no 
            
            ?>

          <div class="col side2">
            <div class="btn-group" role="group" aria-label="Basic example">
              <button
                type="button"
                id="btn-client"
                class="btn btn-primary bg-black homebtn"
              >
                I'm client
              </button>
              <button
                type="button"
                id="btn-create-account"
                class="btn btn-primary homebtn"
              >
                Create Account
              </button>
            </div class="box-form">
            <form
              id="form-login"
              class="row g-3 needs-validation"
              method="post"
            >
              <div class="col-md-6">
                <label for="validationCustomUsername" class="form-label"
                  >Username</label
                >
                <div class="input-group has-validation">
                  <span class="input-group-text" id="inputGroupPrepend">@</span>
                  <input
                    type="text"
                    class="form-control"
                    id="validationCustomUsername"
                    aria-describedby="inputGroupPrepend"
                    required
                  />
                </div>
              </div>
              <div class="col-md-4">
                <label for="password" class="form-label">Contraseña</label>
                <input
                  type="password"
                  class="form-control"
                  id="password"
                  placeholder="*****"
                  name="password"
                  required
                />
              </div>
              <div id="toResgistry" class="container text-centre" style="visibility: hidden;">
                <div class="row aling-items-end">
                  <div class="col-md-4">
                    <label for="nombre" class="form-label">First name</label>
                    <input
                    type="text"
                    class="form-control"
                    id="nombre"
                    placeholder="Emilio"
                    name="nombre"
                    required
                    />
                    <div class="valid-feedback">Looks good!</div>
                  </div>
                  <div class="col-md-4">
                    <label for="surname" class="form-label">Last name</label>
                    <input
                    type="text"
                    class="form-control"
                    id="surname"
                    placeholder="Arevalo"
                    name="surname"
                    required
                    />
                  </div>
                  <div class="col-md-6">
                    <label for="city" class="form-label">Ciudad</label>
                    <input
                    type="text"
                    class="form-control"
                    id="city"
                    name="city"
                    required
                    />
                  </div>
                  <div class="col-md-3">
                    <label for="country" class="form-label">Pais</label>
                    <select
                    class="form-select"
                    id="country"
                    required
                    name="country"
                    >
                    <option selected disabled value="">--</option>
                    <option value="Spain">España</option>
                    <option value="Otro">Otro</option>
                  </select>
                </div>
                <div class="col-12">
                  <div class="form-check">
                    <input
                    class="form-check-input"
                    type="checkbox"
                    value=""
                    id="agree"
                    name="agree"
                    required
                    />
                    <label for="agree" class="form-label"
                    >Estoy deacuerdo con las Politicas del Sitio</label
                    >
                  </div>
                </div>
              </div>
              </div>
              <div class="col-12">
                <button id="submit" class="btn btn-primary" type="submit">Login</button>
              </div>
            </form>
          </div>
<?php } ?>
        </div>
      </div>
    </div>
    <script src="script/script.js"></script>
    <script
      src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"
      integrity="sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"
      crossorigin="anonymous"
    ></script>
  </body>
</html>
