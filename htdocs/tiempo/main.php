<?php

class Weather{

    public $date, $icon, $tempMax, $tempMin, $text; $humidity, $moonphase;

    function Weather($date, $icon, $tempMax, $tempMin, $text, $humidity, $moonphase){
        echo '<div class="box-weather"><h3>' . $date . '</h3><br>';
        echo '<img href="https://v5i.tutiempo.net/wi/02/40/'. $icon. '.png"></img><br>';
        echo '<ul><li>' . $tempMax . '</li><br>';
        echo '<li>' . $tempMin . '</li><br>';
        echo '<li>' . $text . '</li><br>';
        echo '<li>' . $humidity . '</li><br>';
        echo '<li>' . $moonphase . '</li><br></ul></div>';
    }
}


//fetching and return data
    function fetchData(){
        //Warring: check the reload when i trying to find the data into de json file
        //getting (using get) 
        $url = "https://api.tutiempo.net/json/?lan=es&apid=zwDX4azaz4X4Xqs&lid=3768";
        $json = file_get_contents($url);
        $data = json_decode($json, true);
        return $data;    
    }
?>