SET PublishPath=C:\Workspace\TradePublish\Trade.UI.Console
dotnet publish --output %PublishPath%
powershell Compress-Archive -Path %PublishPath%  -DestinationPath %PublishPath%.zip -Update
