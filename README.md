[Hello ML.NET World](https://docs.microsoft.com/en-us/dotnet/machine-learning/how-does-mldotnet-work#hello-mlnet-world)

An example of linear regression is how house prices change with size. There are many other factors that contribute to the house price, but one of those features is the size of the house. We would expect a positive relationship between the house price and size. In other words the house price increases with the size.

```
dotnet add package Microsoft.ML
```

This is a very simple model as it only has one feature and one key, normally there will be many features contributing to the key. To visualize this plot we can use `PLplot` which is a cross platform plotting library `PLPlotNet` offers binding for .Net.

PlPlot is already included on Windows as a part of [Microsoft Visual C++ Redistributable 2017](https://support.microsoft.com/en-us/help/2977003/the-latest-supported-visual-c-downloads).

```
dotnet add package PLplot
```