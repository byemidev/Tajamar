<?php
//fetching and return data
    function fetchData(){
        //Warring: check the reload when i trying to find the data into de json file
    //getting (using get) 
    $url = "http://www.holaformacion.com/json/movies.json";
    $json = file_get_contents($url);
    $data = json_decode($json, true);

    return $data;    
    }

    
    function getfilteredData($data, $input){
        foreach($data as $weather){
                
        }
    }


    function infoMovie($movie){
        return '<div><p style="font-weight: bold; font-size: 3rem;">' . '<label>Titulo:<br>' . $movie['title'] . '</label></p><br></div> <p style="font-weight:lighter; font-style: italic; font-size: 1em;"><label>Sinopsis:<br>' . $movie['storyline'] . '</label></p><br>';
    }
?>