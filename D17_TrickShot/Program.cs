// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");
//step1
var y1 = 0;
var yDiff1 = 108;

while (yDiff1 != 0)
{
    y1 += yDiff1;
    yDiff1--;
}

Console.WriteLine(y1);


//step 2
var values = new List<(int x, int y)>();
var yMin = -109;
var yMax = -63;
var xMin = 179;
var xMax = 201;



for (var yVelo = yMin; yVelo < Math.Abs(yMin); yVelo++)
{
    for (var xVelo = 0;  xVelo <= xMax + 1; xVelo++)
    {
        var y = 0;
        var x = 0;
        var yDiff = yVelo;
        var xDiff = xVelo;
        while (true)
        {
            y += yDiff;
            x += xDiff;


            if (y < yMin) break;
            if (x > xMax) break;

            if (yMin <= y && y <= yMax && xMin <= x && x <= xMax) values.Add((xVelo, yVelo));


            yDiff -= 1;
            if (xDiff != 0) xDiff--;
        } 
    } 
}

Console.WriteLine(values.Distinct().Count());
