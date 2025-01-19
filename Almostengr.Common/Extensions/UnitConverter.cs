namespace Almostengr.Common.Extensions;

public static class UnitConverter
{
    public static float ToFahrenheitFromCelsius(this float celsius)
    {
        float fahrenheit = (((float)celsius * 9) / 5) + 32;
        return fahrenheit;
    }
}