// See https://aka.ms/new-console-template for more information

using System.Text.RegularExpressions;

if (args.Length < 1) throw new ArgumentNullException();

var url = args[0];
var checkUrl = Uri.IsWellFormedUriString(url, UriKind.Absolute);
if (!checkUrl)
{
    throw new System.ArgumentException("Niepoprawny url");
}


var httpClient = new HttpClient();
HttpResponseMessage response = await httpClient.GetAsync(url);
if(!response.IsSuccessStatusCode)
{
    throw new Exception("Błąd w czasie pobierania strony");
}

var content = await response.Content.ReadAsStringAsync();

var regex = new Regex(@"[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+");
MatchCollection matches = regex.Matches(content);

if (matches.Count <= 0)
{
    throw new System.Exception("Nie znaleziono adresów email");
}

var uniqueMatches = matches
    .OfType<Match>()
    .Select(m => m.Value)
    .Distinct();

uniqueMatches.ToList().ForEach(Console.WriteLine);
