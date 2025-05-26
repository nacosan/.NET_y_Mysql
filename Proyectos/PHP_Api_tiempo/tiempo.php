<?php
$lat = 40.4168;
$lon = -3.7038;

// URL de la API
$url = "https://api.open-meteo.com/v1/forecast?latitude={$lat}&longitude={$lon}&current=temperature_2m,wind_speed_10m";

// Realizar la petición HTTP
$response = file_get_contents($url);

// Decodificar la respuesta JSON
$data = json_decode($response, true);

// Mostrar los datos actuales
if (isset($data['current'])) {
    echo "<h2>Clima actual en Madrid</h2>";
    echo "Hora: " . $data['current']['time'] . "<br>";
    echo "Temperatura (°C): " . $data['current']['temperature_2m'] . "<br>";
    echo "Viento (km/h): " . $data['current']['wind_speed_10m'] . "<br>";
} else {
    echo "No se pudieron obtener los datos del clima.";
}
?>
