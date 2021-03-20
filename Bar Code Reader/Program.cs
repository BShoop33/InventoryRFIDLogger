using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Bar_Code_Reader
{
    class Program
    {
        static async Task Main(string[] args)
        {

            string file = @"C:\Users\braxt\Desktop\Test.txt";

            //using (StreamWriter sw = File.AppendText(file))
            //{
            //    sw.WriteLine("This");
            //    sw.WriteLine("is Extra");
            //    sw.WriteLine("Text");
            //}

            // Read the file as one string.
            string output = File.ReadAllText(file);

            //List<string> listOfStrings = new List<string>();
            //listOfStrings.Add(output);

            string[] bear = output.Split('e');

            using (HttpClient client = new HttpClient())
            {
            }

            string baseUrl = "https://api.upcitemdb.com/prod/trial/lookup?upc=";

            foreach (var sub in bear)
            {
                try
                {
                    //We will now define your HttpClient with your first using statement which will use a IDisposable.
                    using (HttpClient client = new HttpClient())
                    {
                        //In the next using statement you will initiate the Get Request, use the await keyword so it will execute the using statement in order.
                        using (HttpResponseMessage res = await client.GetAsync(baseUrl + sub))
                        {
                            //Then get the content from the response in the next using statement, then within it you will get the data, and convert it to a c# object.
                            using (HttpContent content = res.Content)
                            {
                                //Now assign your content to your data variable, by converting into a string using the await keyword.
                                var data = await content.ReadAsStringAsync();

                                //If the data isn't null return log convert the data using newtonsoft JObject Parse class method on the data.
                                if (data != null)
                                {
                                    //Now log your data in the console
                                    var dataObj = JObject.Parse(data);
                                    //Then create a new instance of PokeItem, and string interpolate your name property to your JSON object.
                                    //Which will convert it to a string, since each property value is a instance of JToken.
                                    Item items = new Item(title: $"{dataObj["title"]}", description: $"{dataObj["description"]}", brand: $"{dataObj["brand"]}");

                                    //Log your pokeItem's name to the Console.
                                    //Console.WriteLine(items.Title);
                                    //Console.WriteLine("Quantity:" + JObject.Parse(data)["total"]);
                                    //Console.WriteLine(items.Description);
                                    //Console.WriteLine(items.Brand);


                                    Console.WriteLine("Title:" + items.Title);
                                    Console.WriteLine("Description:" + items.Description);
                                    Console.WriteLine("Brand:" + items.Brand);
                                    //Console.WriteLine("Quantity:" + JObject.Parse(data)["total"]);
                                    //Console.WriteLine("Description:" + JObject.Parse(data)["description"]);
                                    //Console.WriteLine("Brand:" + JObject.Parse(data)["brand"]);
                                }
                                else
                                {
                                    Console.WriteLine("NO Data----------");
                                }
                            }
                        }
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine("Exception Hit------------");
                    Console.WriteLine(exception);
                }
            }

            // Display the file contents to the console. Variable text is a string.
            //Console.WriteLine(bear);

            //string baseUrl = "http://pokeapi.co/api/v2/pokemon/";
            //Have your using statements within a try/catch block
        }
    }
}
