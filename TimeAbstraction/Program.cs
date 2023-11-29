


var timeStamp = TimeProvider.System.GetTimestamp();

//await Task.Delay(1000);

var elapsedTime = TimeProvider.System.GetElapsedTime(timeStamp);

Console.WriteLine(elapsedTime);


