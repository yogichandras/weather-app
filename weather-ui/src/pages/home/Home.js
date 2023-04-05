import './Home.css';
import axios from "axios";
import React from "react";
import * as WeatherConst from "../../consts/WeatherConst";

function Home() {
  const [countries, setCountries] = React.useState([]);
  const [cities, setCities] = React.useState([]);
  const [weather, setWeather] = React.useState(null);
  
  const getCountries = () => {
    axios.get(`${WeatherConst.BASE_URL}/api/reference/countries`).then((response) => {
      setCountries(response.data.result);
    })
    .catch((error) => { console.log(error); });
  }

  const getCities = (idCountry) => {
    axios.get(`${WeatherConst.BASE_URL}/api/reference/cities?idCountry=${idCountry}`).then((response) => {
      setCities(response.data.result);
      setWeather(null);
    })
    .catch((error) => { console.log(error); });
  }

  const getWeather = (idCity) => {
    axios.get(`${WeatherConst.BASE_URL}/api/weather/city?idCity=${idCity}`).then((response) => {
      setWeather({
        day: dateFormat(response.data.result.time, { weekday: 'long' }),
        date: dateFormat(response.data.result.time, { day: 'numeric', month: 'short', year: 'numeric' }),
        ...response.data.result
      });
    })
    .catch((error) => { console.log(error); });
  }

  const dateFormat = (dateStr, options) =>
  {
      var date = new Date(dateStr);
      return date.toLocaleDateString('id-ID', options);        
  }

  React.useEffect(() => {
    getCountries();
  }, []);

  return (
    <div className="App">

      <div class="container">
        <div class="weather-side">
          <div class="weather-gradient"></div>
          <div class="date-container">
            <h2 class="date-dayname">{weather && weather.day }</h2><span class="date-day">{weather && weather.date}</span><i class="location-icon" data-feather="map-pin"></i><span class="location">{weather && weather.location}</span>
          </div>
          <div class="weather-container"><i class="weather-icon" data-feather="sun"></i>
            <h1 class="weather-temp">{weather && `${weather.celsiusTemperature}°C`}</h1>
            <h3 class="weather-desc">{weather && weather.skyConditions }</h3>
          </div>
        </div>
        <div class="info-side">
          <div class="today-info-container">
            {
              weather && 
                <div class="today-info">
                <div class="visibility"> <span class="title">VISIBILITY</span><span class="value">{weather && `${weather.visibility} %`}</span>
                  <div class="clear"></div>
                </div>
                <div class="humidity"> <span class="title">HUMIDITY</span><span class="value">{weather && `${weather.relativeHumidity} %`}</span>
                  <div class="clear"></div>
                </div>
                <div class="wind"> <span class="title">WIND</span><span class="value">{weather && `${weather.wind.speed} km/h`}</span>
                  <div class="clear"></div>
                </div>
                <div class="dewpoint"> <span class="title">DEW POINT</span><span class="value">{weather && `${weather.dewPoint} %`} </span>
                  <div class="clear"></div>
                </div>
                <div class="pressure"> <span class="title">PRESSURE</span><span class="value">{weather && `${weather.pressure} %`}</span>
                  <div class="clear"></div>
                </div>
              </div>
            }
            {
              !weather && <div class="area-container"><p>Select Country and City to get weather information</p></div>
            }
          </div>
          <div class="area-container">
            <div class="country-info">
              <select class="input-form" onChange={(e) => getCities(e.currentTarget.value)}>
                <option value="0">Select Country</option>
                {countries && countries.map((country) => {
                  return (
                    <option key={country.idCountry} value={country.idCountry}>{country.countryName}</option>
                  );
                })}
              </select>
            </div>
            <div class="city-info">
              <select class="input-form" onChange={(e) => getWeather(e.currentTarget.value)}>
                <option value="0">Select City</option>
                {cities && cities.map((city) => {
                  return (
                    <option key={city.idCity} value={city.idCity}>{city.cityName}</option>
                  );
                })}
              </select>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}

export default Home;
