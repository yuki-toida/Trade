pushd

cd ../
dotnet run --assembly "Trade.UI.Batch" --class "Trade.UI.Batch.Scraping.YahooPriceIncreaseRateBatch" --configuration Debug

popd
