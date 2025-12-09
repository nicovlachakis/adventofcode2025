var lines = File.ReadAllLines("input");

int position = 50;
int zeroCount = 0;

foreach (var line in lines)
{
    char direction = line[0];
    int distance = int.Parse(line.Substring(1));
    
    if (direction == 'L')
    {
        position = (position - distance) % 100;
        if (position < 0)
            position += 100;
    }
    else // direction == 'R'
    {
        position = (position + distance) % 100;
    }
    
    if (position == 0)
    {
        zeroCount++;
    }
}

Console.WriteLine($"The password is: {zeroCount}");
