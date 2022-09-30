namespace FormulaOneShots.Lib;

using Google.Apis.Auth.OAuth2;
using Google.Apis.Services;
using Google.Apis.Sheets.v4;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

using Data = Google.Apis.Sheets.v4.Data;

public class Program
{
    public static void Main(string[] args)
        {
            SheetsService sheetsService = new SheetsService(new BaseClientService.Initializer
            {
                HttpClientInitializer = GetCredential(),
                ApplicationName = "Google-SheetsSample/0.1",
            });

            // The spreadsheet to request.
            string spreadsheetId = "1065980596";  // TODO: Update placeholder value.

            // The ranges to retrieve from the spreadsheet.
            List<string> ranges = new List<string>();  // TODO: Update placeholder value.

            // True if grid data should be returned.
            // This parameter is ignored if a field mask was set in the request.
            bool includeGridData = false;  // TODO: Update placeholder value.

            SpreadsheetsResource.GetRequest request = sheetsService.Spreadsheets.Get(spreadsheetId);
            request.Ranges = ranges;
            request.IncludeGridData = includeGridData;

            // To execute asynchronously in an async method, replace `request.Execute()` as shown:
            Data.Spreadsheet response = request.Execute();
            // Data.Spreadsheet response = await request.ExecuteAsync();

            // TODO: Change code below to process the `response` object:
            Console.WriteLine(JsonConvert.SerializeObject(response));
        }

        public static UserCredential GetCredential()
        {
            // var credentials = new UserCredential();
            // TODO: Change placeholder below to generate authentication credentials. See:
            // https://developers.google.com/sheets/quickstart/dotnet#step_3_set_up_the_sample
            //
            // Authorize using one of the following scopes:
            //     "https://www.googleapis.com/auth/drive"
            //     "https://www.googleapis.com/auth/drive.file"
            //     "https://www.googleapis.com/auth/drive.readonly"
            //     "https://www.googleapis.com/auth/spreadsheets"
            //     "https://www.googleapis.com/auth/spreadsheets.readonly"
            return null;
        }
}