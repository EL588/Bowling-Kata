using static bowlingScoreCalculator2._0.logic;

var scores = new List<int>();

for (int i = 0; i < 10; i++)
{
    int throwOne = firstThrow();
    scores.Add(throwOne);

    strikeCheck(throwOne);

    int throwTwo = secondThrow();

    int spare = spareCheck(i, throwOne, throwTwo);
}