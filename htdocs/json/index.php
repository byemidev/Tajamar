<?php
    //get data from movies.php
    include_once('movies.php');
    $data = fetchData();

    //input 
    // Check if the form was submitted & and what form had been submited
    if ($_SERVER['REQUEST_METHOD'] === 'POST') {
        if (isset($_POST['submitByStoryLine'])) {
            $inFindMovieByStoryLine = $_POST['findMovieByStoryLine'];
            $inFindMovieByStoryLine = htmlspecialchars(trim($inFindMovieByStoryLine));
            include_once('movies.php');
            $result = getfilteredData($data, $inFindMovieByStoryLine);
        }
        elseif (isset($_POST['submitByActors'])) {
            $inFindMovieByActor = $_POST['findMovieByActor'];
            $inFindMovieByActor = htmlspecialchars(trim($inFindMovieByActor));
            //TODO: find in the data about actor trying to match the input and the data.
            //TODO: Show the output in a new window
        }
    }
?>


<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>buscar peliculas</title>
</head>
<body>
    <form action="" method="post">
        <label for="findMovieByStoryLine">Buscar por sipnosis: <input id="findMovieByStoryLine" type="text" placeholder="aqui nombre por sipnosis" name="findMovieByStoryLine"> <button type="submit" name="submitByStoryLine">Buscar</button></label>
    </form>
    <form action="" method="post">
        <label for="findMovieByActor">Buscar por actor: <input id="findMovieByActor" type="text" placeholder="aqui nombre actor" name="findMovieByActor"> <button type="submit" name="submitByActors">Buscar</button></label>
    </form>
</body>
</html>


<?php
$countMovies = 0; //to count movies 
foreach($data as $movie){
    $countMovies++;
    echo '<hr>';
    echo '<p style="font-weight: bold; font-size: 3rem;">' . '<label>Titulo:<br>' . $movie['title'] . '</label></p><br>';
    echo '<p style="font-weight: lighter; font-size: 1.3rem;">' . '<label>año:<br>' . $movie['year'] . '</label></p><br>';
    echo '<p style="font-weight:lighter; font-style: italic; font-size: 1em;"><label>Sinopsis:<br>' . $movie['storyline'] . '</label></p><br>';


    if($movie['actors']){
        //to count actors
        $countActors = 0;
        foreach($movie['actors'] as $actor){
            $countActors++;
            echo '<p>' . $actor .'</p>';
        }
        echo '<br>';
    }
    //total actors
    echo '<p style="font-weight: 400; color: blue;"> Total actores es de ' . $countActors . '</p>';
}
//total movies 
echo '<p style="font-weight: 400; color: blue; display: top;"> Total peliculas es de ' . $countMovies. '</p>';
?>

