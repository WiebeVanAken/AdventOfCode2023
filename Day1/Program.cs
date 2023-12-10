var lines = File.ReadAllLines("input.txt");

var numbers = lines
    .Select(line => {
        var numbers = line
            .Select(c => c)
            .Where(char.IsDigit)
            .ToList();
        
        return Int32.Parse($"{numbers.First()}{numbers.Last()}");
    })
    .Sum();

Console.WriteLine(numbers);