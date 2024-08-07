<!DOCTYPE html>
<html lang="en">
  <head>
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <link
      rel="stylesheet"
      href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/5.1.3/css/bootstrap.min.css"
    />

    <title>Hotel reservation page</title>
  </head>
  <body>
    <!DOCTYPE html>
    <html lang="es">
      <head>
        <meta charset="UTF-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1.0" />
        <title>Formulario de Reserva</title>
        <!-- Agrega tus estilos CSS aquí -->
        <link rel="stylesheet" href="../styles.css" />
      </head>
      <body>
        <div class="container text-center">
          <form id="reservation-form" class="needs-validation" action="" method="post">
            <div class="mb-3">
              <label for="name" class="form-label">Name:</label>
              <input
                type="text"
                id="name"
                name="name"
                value="<?php echo htmlspecialchars($_SESSION['session_name']);?>";
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="surname" class="form-label">Surname:</label>
              <input
                type="text"
                id="surname"
                name="surname"
                placeholder="Martin Perez"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="phone" class="form-label">Phone:</label>
              <input
                type="tel"
                placeholder="+34"
                id="phone"
                name="phone"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="email" class="form-label">Email:</label>
              <input
                type="email"
                placeholder="nickname@dom.ex"
                id="email"
                name="email"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="checkinDate" class="form-label">Check-in date:</label>
              <input
                type="date"
                id="check-in"
                name="check-in"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="checkoutDate" class="form-label"
                >Check-out date:</label
              >
              <input
                type="date"
                id="check-out"
                name="check-out"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="guestsNum" class="form-label"
                >Number of guests:</label
              >
              <input
                type="number"
                id="guestNum"
                name="number-of-guests"
                min="1"
                max="3"
                required
                class="form-control"
              />
            </div>
            <div class="mb-3">
              <label for="room" class="form-label">Room:</label>
              <select name="rooms" id="room" class="form-select">
                <option value="">--</option>
                <option value="individual">Individual</option>
                <option value="double">Double</option>
                <option value="Deluxe double">Deluxe Double</option>
              </select>
            </div>
            <button type="submit" class="btn btn-primary">Go pay</button>
            <p style="visibility: hidden" class="form-text">
              The room price is: <span id="total"></span>
            </p>
          </form>
        </div>
        <!-- Js -->
        <script src="script/validation.js"></script>
        <!-- php como se trabaja con los dos archivos de forma concurrente-->
      </body>
    </html>
  </body>
</html>
