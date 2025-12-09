var lines = File.ReadAllLines("input");

int position = 50;
int clickCount = 0;

foreach (var line in lines)
{
    char direction = line[0];
    int distance = int.Parse(line.Substring(1));
    
    if (direction == 'L')
    {
        // Moving left from position by distance clicks
        // Count how many times we land on 0
        // We land on 0 if: (position - k) % 100 == 0 for k in [1..distance]
        // This means: position - k ≡ 0 (mod 100)
        // So: k ≡ position (mod 100)
        // k = position, position + 100, position + 200, ...
        
        // How many such k exist in range [1, distance]?
        if (distance >= position && position > 0)
        {
            // First time we hit 0 is at click 'position'
            // Then every 100 clicks after that
            clickCount += 1 + ((distance - position) / 100);
        }
        else if (position == 0)
        {
            // Starting at 0, we hit it every 100 clicks
            clickCount += distance / 100;
        }
        
        position = (position - distance % 100 + 100) % 100;
    }
    else // direction == 'R'
    {
        // Moving right from position by distance clicks
        // We land on 0 if: (position + k) % 100 == 0 for k in [1..distance]
        // This means: position + k ≡ 0 (mod 100)
        // So: k ≡ -position ≡ (100 - position) (mod 100)
        // k = (100 - position), (100 - position) + 100, ...
        
        int firstZero = (100 - position) % 100;
        if (firstZero == 0) firstZero = 100;
        
        if (distance >= firstZero)
        {
            // Count how many times we hit 0
            clickCount += 1 + ((distance - firstZero) / 100);
        }
        
        position = (position + distance % 100) % 100;
    }
}

Console.WriteLine($"The password (Part 2) is: {clickCount}");
