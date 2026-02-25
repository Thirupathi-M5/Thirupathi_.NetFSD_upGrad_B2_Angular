const fetchWeather = async (city) => {
  try {

    const geoUrl = `https://geocoding-api.open-meteo.com/v1/search?name=${city}&count=1`;

    const geoResponse = await fetch(geoUrl);
    const geoData = await geoResponse.json();

    if (!geoData.results) {
      throw new Error("City not found");
    }

    const { latitude, longitude, name, country } = geoData.results[0];

    const weatherUrl =
      `https://api.open-meteo.com/v1/forecast?latitude=${latitude}&longitude=${longitude}&current_weather=true`;

    const weatherResponse = await fetch(weatherUrl);
    const weatherData = await weatherResponse.json();

    const weather = weatherData.current_weather;

    console.log(`Weather Report (Async/Await)
City: ${name}, ${country}
Temperature: ${weather.temperature}°C
Wind Speed: ${weather.windspeed} km/h`);

  } catch (error) {
    console.log(`Error: ${error.message}`);
  }
  
};

fetchWeather("Hyderabad"); //This is for html file