using Newtonsoft.Json;
using System.ComponentModel.Design.Serialization;
using System.Text;
using System.Text.Json;

namespace APIClint
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //string response = await CallAPI();
            //Console.WriteLine(response);

             List<CountryInfo> response = await CallAPI();
            foreach (CountryInfo country in response)
            {
                Console.WriteLine(country);
            }
            //await CallAPI();
        }
        public async static Task<List<CountryInfo>> CallAPI()
        {
            try
            {
                String api = "https://restcountries.com/v3.1/all?fields=name,capital,area";

                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage responseMessage = await client.GetAsync(api);
                    List<CountryInfo> countries = new List<CountryInfo>();

                    if (responseMessage.IsSuccessStatusCode)
                    {
                        String stringRespons = await responseMessage.Content.ReadAsStringAsync();
                        //    JsonDocument document = JsonDocument.Parse(stringRespons);
                        //    JsonElement root = document.RootElement;

                        //    if(root.ValueKind == JsonValueKind.Array) 
                        //    {
                        //        var enumrator = root.EnumerateArray;
                        //        foreach(JsonElement country in root.EnumerateArray())
                        //        {
                        //            string capital = "";
                        //            if (country.GetProperty("capital").GetArrayLength() > 0)
                        //            {
                        //                capital = country.GetProperty("capital")[0].GetString();
                        //            }

                        //            Double area = country.GetProperty("area").GetDouble();
                        //            String officialName = country.GetProperty("name").GetProperty("official").GetString();
                        //            countries.Add(new CountryInfo(officialName, capital, area));
                        //        }
                        //    }
                        List<CountryInfo> m = JsonConvert.DeserializeObject<List<CountryInfo>>(stringRespons);
                        //Console.WriteLine(m.Count);
                    }
                    return countries;
                }
            } 
            catch (HttpRequestException ex) 
            { 
                throw new Exception(ex.Message);
            }
        }
    }
}