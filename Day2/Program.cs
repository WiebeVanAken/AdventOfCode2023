var lines = File.ReadAllLines("input.txt");

var games = new List<Game>();
games.AddRange(lines.Select(ParseGame));

var total = games
    .Where(g => g.IsPossible(14, 12, 13))
    .Select(g => g.Code)
    .Sum();

Console.WriteLine(total);

static Game ParseGame(string line)
{
    return new Game(line);
}

class Game
{
    public Game(string line)
    {
        //TODO De hands worden niet juist gesplitst van elkaar, ze worden nu *allemaal* bij elkaar opgerekend. En dan gecheckt of het valide is. Maar het moet per hand.
        var hands = line
            .Split(';')
            .Select(l => l.Split(':')
                .Select(c => c.Split(','))
            );
        
        foreach (var hand in hands)
        {
            foreach (var groups in hand)
            {
                foreach (var tokenValues in groups)
                {
                    var split = tokenValues.Trim().Split(' ');
                    var token = split[1];
                    var value = split[0];
    
                    if (value == "Game")
                    {
                        token = value;
                        value = split[1];
                    }
    
                    switch (token)
                    {
                        case "blue":
                            Blue += int.Parse(value);
                            break;
                        case "red":
                            Red += int.Parse(value);
                            break;
                        case "green":
                            Green += int.Parse(value);
                            break;
                        case "Game":
                            Code = int.Parse(value);
                            break;
                    }
                }
            }
        }
    }

    public bool IsPossible(int blue, int red, int green)
    {
        return blue >= Blue && red >= Red && green >= Green;
    }

    public int Code { get; }
    public int Blue { get; }
    public int Red { get; }
    public int Green { get; }
};