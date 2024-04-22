<?php

class Weather{

    public $date, $icon, $tempMax, $tempMin, $text, $humidity, $moonphase;

    function Weather($date, $icon, $tempMax, $tempMin, $text, $humidity, $moonphase){
        $this->date = $date; 
        $this->icon = $icon; 
        $this->tempMax = $tempMax; 
        $this->tempMin = $tempMin;  
        $this->text = $text; 
        $this->himidity = $humidity; 
        $this->moonphase = $moonphase; 
    }

    function __toString(){
        return '<div class= "card-box">' . '<h3>Para el <span>'. $this->date .'</span></h3>' . '<img src= "https://v5i.tutiempo.net/wi/01/40/' . $this->icon . '.png" >' . '<p>Max. <span>' . $this->tempMax . '</span></p>' . '<p>Min. <span>' . $this->tempMin . '</span></p>' . '<p>Info: <span>' . $this->tempMin . '</span></p>' . '<p><span>' . $this->humidity . '</span></p>' . '<img src="https://v5i.tutiempo.net/wmi/02/' . $this->moonphase . '.png">'; 
    }
}


//fetching and return data
    function fetchData(){
        //Warring: check the reload when i trying to find the data into de json file
        //(using get by default) 
        $url = "https://api.tutiempo.net/json/?lan=es&apid=zwDX4azaz4X4Xqs&lid=3768";
        $json = file_get_contents($url);
        $data = json_decode($json, true);
        return $data;    
    }
?>