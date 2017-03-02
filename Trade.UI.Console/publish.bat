SET PublishPath=%CD%\WebJobs\Scraping
dotnet publish --output %PublishPath%
powershell Compress-Archive -Path %PublishPath% -DestinationPath %PublishPath%.zip -Update
