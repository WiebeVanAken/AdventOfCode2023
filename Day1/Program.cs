var document = new string [] {
    "1abc2",
    "pqr3stu8vwx",
    "a1b2c3d4e5f",
    "treb7uchet"
};

var numbers = document
    .Select(line => {
        var numbers = line
            .Select(c => c)
            .Where(char.IsDigit)
            .ToList();
        
        return Int32.Parse($"{numbers.First()}{numbers.Last()}");
    })
    .Sum();

Console.WriteLine(numbers);