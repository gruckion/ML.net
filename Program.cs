using System;
using Microsoft.ML;
using Microsoft.ML.Data;
using PLplot;

class Program
{
    public class HouseData
    {
        public float Size { get; set; }
        public float Price { get; set; }
    }

    public class Prediction
    {
        [ColumnName("Score")]
        public float Price { get; set; }
    }

    static void Main(string[] args)
    {
        var mlContext = new MLContext();
        {
            // 1. Import or create training data
            var trainingData = mlContext.Data.LoadFromEnumerable(
                new HouseData[]
                {
                new HouseData() { Size = 1.1F, Price = 1.2F },
                new HouseData() { Size = 1.9F, Price = 2.3F },
                new HouseData() { Size = 2.8F, Price = 3.0F },
                new HouseData() { Size = 3.4F, Price = 3.7F }
                });

            // 2. Specify data preparation and model training pipeline
            var pipeline = mlContext.Transforms.Concatenate("Features", new[] { "Size" })
                .Append(mlContext.Regression.Trainers.Sdca(
                    labelColumnName: "Price",
                    maximumNumberOfIterations: 100));

            // 3. Train model
            var model = pipeline.Fit(trainingData);

            // 4. Make a prediction with test data
            var testingData = new HouseData() { Size = 2.5F };
            var price = mlContext.Model.CreatePredictionEngine<HouseData, Prediction>(model)
                .Predict(testingData);

            Console.WriteLine($"Predicted price for size: {testingData.Size * 1000} sq ft= {price.Price * 100:C}k");

            // Predicted price for size: 2500 sq ft= $261.98k
        }

        // 5. Visualize our data
        var pl = new PLStream();
        pl.sdev("svg");
        pl.sfnam("linear-regression.svg");
        pl.spal0("cmap0_alternate.pal");
        pl.init();

        const int xMin = 0;
        const int xMax = 1000;
        const int yMin = -1;
        const int yMax = 1;
        pl.env(xMin, xMax, yMin, yMax, AxesScale.Independent, AxisBox.BoxTicksLabelsAxes);
        pl.schr(0, 1.25);
        pl.lab(nameof(HouseData.Size), nameof(HouseData.Price), "Linear regression plot of house price for size");
        pl.eop();

    }
}