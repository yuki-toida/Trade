SET PublishPath=%CD%\WebJobs\Scraping
dotnet build
dotnet publish --output %PublishPath%
powershell Compress-Archive -Path %PublishPath% -DestinationPath %PublishPath%.zip -Update
