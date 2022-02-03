$hostName = "rasmusPi"
$ip = (Invoke-WebRequest "https://pipinger.herokuapp.com/api/Ping/host?host=$hostName").Content.Trim()
echo $ip
ssh pi@$ip