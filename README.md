# TouchTunesCSharpSDK

## Installation with NuGet
`Install-Package TouchTunesCSharpSDK`

## Usage
### Init
```
  var ttApi = new TouchTunesApi(/*Your TouchTunes Api Key*/);
```

### Now Playing (requires device id)
```
  var deviceId = 8675309;
  var response = ttApi.NowPlaying(deviceId);
  
  if(response.Success) {
    // do something with response.Data (string of JSON)
  }
```

### Keyword Search
```
  var keyword = "Mad Season";
  var response = ttApi.KeywordSearch(keyword);
  
  if(response.Success) {
    // do something with response.Data (string of JSON)
  }
```

### Song ID Search
```
  var songId = "8675309";
  var response = ttApi.SongIdSearch(songId);
  
  if(response.Success) {
    // do something with response.Data (string of JSON)
  }
```

### Locate
```
  var latitude = "40.942438";
  var longitude = "-72.990088";
  var limit = 10; // optional, defaults to 20
  var response = ttApi.Locate(longitude, latitude, limit);
  
  if(response.Success) {
    // do something with response.Data (string of JSON)
  }
```

