SET Dll=Trade.UI.Console.dll
SET Assembly=Trade.UI.Batch
SET Configuration=Debug

dotnet %Dll% --assembly "%Assembly%" --class "%Assembly%.Scraping.YahooVolumeIncreaseRateBatch" --configuration "%Configuration%"
dotnet %Dll% --assembly "%Assembly%" --class "%Assembly%.Scraping.YahooPriceIncreaseRateBatch" --configuration "%Configuration%"
dotnet %Dll% --assembly "%Assembly%" --class "%Assembly%.Scraping.YahooPriceDecreaseRateBatch" --configuration "%Configuration%"
