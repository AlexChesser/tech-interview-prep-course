# Candles

```bash
dotnet new classlib --name candles -o src
dotnet new classlib --name candles.test -o test
dotnet add .\test\candles.test.csproj reference .\src\candles.csproj
dotnet new sln --name candles
dotnet sln add .\src\candles.csproj .\test\candles.test.csproj .\candles.sln
```

You are in charge of the cake for a child's birthday. You have decided the cake will have one candle for each year of their total age. They will only be able to blow out the tallest of the candles. Count how many candles are tallest.

Example

The maximum height candles are  units high. There are  of them, so return .

Function Description

Complete the function birthdayCakeCandles in the editor below.

birthdayCakeCandles has the following parameter(s):

int candles[n]: the candle heights
Returns

int: the number of candles that are tallest
Input Format

The first line contains a single integer, , the size of .
The second line contains  space-separated integers, where each integer  describes the height of .

Constraints

Sample Input 0

4
3 2 1 3
Sample Output 0

2
Explanation 0

Candle heights are . The tallest candles are  units, and there are  of them.
