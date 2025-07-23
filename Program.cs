using Microsoft.ML;
using OriginML.DataStructures.ErrorSuggestion;
using OriginML.ErrorSuggestions;



#region ErrorCorrections

MLMain mLMain = new MLMain();
mLMain.Start();
Console.WriteLine("Model Kaydedildi... Şimdi yükleniyor...");

var mlContext = new MLContext(seed: 1);
ITransformer trainedModel = mlContext.Model.Load(MLMain.ModelPath, out var modelSchema);

var issue = new OriginError() { ID = "Any-ID", Description = @"Error occured in r_add_implicit_rec_with_ascode. Error message: Ascode already exists: 44103. See model logs for detailed information." };
var predEngine = mlContext.Model.CreatePredictionEngine<OriginError, OriginErrorPrediction>(trainedModel);

var prediction = predEngine.Predict(issue);
Console.WriteLine("");
Console.WriteLine($"=============== Error Message ===============");
Console.WriteLine(issue.Description);

Console.WriteLine("");
Console.WriteLine($"=============== Prediction ===============");
Console.WriteLine(prediction.Area);
Console.ReadLine();

#endregion


Console.ReadLine();