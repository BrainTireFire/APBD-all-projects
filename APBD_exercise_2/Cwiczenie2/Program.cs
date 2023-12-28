// See https://aka.ms/new-console-template for more information
using Cwiczenie2;
using System.Text.Json;
using System.Threading.Tasks;
using System.Globalization;
using System.Xml.Serialization;

if (args.Length != 4)
{
    throw new ArgumentOutOfRangeException("Specified argument was out of the range of valid values.");
}

var pathToFileWithData = args[0];
var pathToFolderOutput = args[1];
var pathToLogFile = args[2];
var fileFormat = args[3];

//Check file with data
if (!File.Exists(pathToFileWithData))
{
    throw new FileNotFoundException("Unable to find the specified file.", pathToFileWithData);
}

// Check Folder for output
if (!Directory.Exists(pathToFolderOutput))
{
    throw new DirectoryNotFoundException("Attempted to access a path that is not on the disk.");
}

//Check file with logs
if (!File.Exists(pathToLogFile))
{
    throw new FileNotFoundException("Unable to find the specified file.", pathToLogFile);
}

//Clearing log file
using (FileStream fileStream = new FileStream(pathToLogFile, FileMode.Truncate))
{
    fileStream.SetLength(0);
}

//Check formats
if (fileFormat is not "json" and not "xml")
{
    throw new InvalidOperationException("Operation is not valid due to the current state of the object.");
}

//Czytanie z pliku
var lines = await File.ReadAllLinesAsync(pathToFileWithData);

var students = new HashSet<Student>(new StudentComparer());
var studies = new HashSet<Studies>(new StudiesComparer());
var activeStudies = new HashSet<ActiveStudies>();

foreach (string line in lines)
{
    var data = line.Split(',');

    //Sprawdzenie czy dane mają 9 kolumn
    if (data.Length != 9)
    {
        throw new System.ArgumentOutOfRangeException("Too few or too many arguments passed");
    }

    //Sprawdzenie czy nie ma pustych wartości
    if (isElementInArrayEmpty(data))
    {
        await File.AppendAllTextAsync(pathToLogFile, $"The row cannot have empty columns: {line}\n");
        continue;
    }

    var studie = new Studies
    {
        Name = data[2],
        Mode = data[3]
    };

    if (!studies.Contains(studie))
    {
        studies.Add(studie);
    }


    var student = new Student
    {
        IndexNumber = $"s{data[4]}",
        Fname = data[0],
        Lname = data[1],
        Birthdate = DateOnly.Parse(data[5], CultureInfo.InvariantCulture),
        Email = data[6],
        MothersName = data[7],
        FathersName = data[8],
        Studies = studie
    };

    if (!students.Contains(student))
    {
        students.Add(student);
    }
    else
    {
        await File.AppendAllTextAsync(pathToLogFile, $"Duplicate: {line}\n");
    }
}


foreach (var studie in studies)
{
    var studentsCount = 0;
    foreach (var student in students)
    {
        if (studie.Name.Equals(student.Studies.Name) && studie.Mode.Equals(student.Studies.Mode))
        {
            studentsCount++;
        }
    }

    if (studentsCount > 0)
    {
        var activeStudie = new ActiveStudies
        {
            Name = studie.Name,
            NumberOfStudents = studentsCount
        };

        if (!activeStudies.Contains(activeStudie))
        {
            activeStudies.Add(activeStudie);
        }
    }
}

var uczelnia = new Uczelnia
{
    CreatedAt = DateTime.Now.ToString("dd.MM.yyyy"),
    Author = "Maciej Kawęcki",
    Students = students.ToList(),
    ActiveStudies = activeStudies.ToList()
};

if (fileFormat.Equals("json", StringComparison.OrdinalIgnoreCase))
{
    await createJsonFormatAsync(uczelnia);
}
else if (fileFormat.Equals("xml", StringComparison.OrdinalIgnoreCase))
{
    
    await createXmlFormatAsync(uczelnia);
}

bool isElementInArrayEmpty(string[] data)
{
    for (int i = 0; i < data.Length; i++)
    {
        if (string.IsNullOrEmpty(data[i]))
        {
            return true;
        }
    }
    return false;
}

async Task createJsonFormatAsync(Uczelnia uczelnia)
{
    if (string.IsNullOrEmpty(pathToFolderOutput))
    {
        throw new ArgumentNullException(nameof(pathToFolderOutput));
    }

    string fullPathFileOutput = Path.Combine(pathToFolderOutput, "uczelnia.json");

    var options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
    };

    await File.WriteAllTextAsync(fullPathFileOutput, JsonSerializer.Serialize(new { Uczelnia = uczelnia }, options));
}

async Task createXmlFormatAsync(Uczelnia uczelnia)
{
    if (string.IsNullOrEmpty(pathToFolderOutput))
    {
        throw new ArgumentNullException(nameof(pathToFolderOutput));
    }

    string fullPathFileOutput = Path.Combine(pathToFolderOutput, "uczelnia.xml");

    using var stream = new FileStream(fullPathFileOutput, FileMode.Create);

    await Task.Run(() =>
    {
        var serializer = new XmlSerializer(typeof(Uczelnia));
        serializer.Serialize(stream, uczelnia);
    });
}

// need to add YamlDotNet from nuget packages
// async Task createYamlFormatAsync(Uczelnia uczelnia)
// {
//     if (string.IsNullOrEmpty(pathToFolderOutput))
//     {
//         throw new ArgumentNullException(nameof(pathToFolderOutput));
//     }

//     string fullPathFileOutput = Path.Combine(pathToFolderOutput, "uczelnia.yaml");

//     var serializer = new SerializerBuilder().Build();

//     using var writer = new StreamWriter(fullPathFileOutput);

//     await Task.Run(() =>
//     {
//         serializer.Serialize(writer, uczelnia);
//     });
// }
