class Fraction
{
    private int _top = 1; //seting the initial values
    private int _bottom = 1; //setting the initial values

    // Getter to retrive the attribute
    private int GetTopNumber()
    {
        return _top;
    }
    // Set the attribute equal to an input value.
    private void SetTopNumber(string topNumber)
    {
        _top = int.Parse(topNumber);
    }

    // Getter to retrive the attribute
    private int GetBottomNumber()
    {
        return _bottom;
    }
    // Set the attribute equal to an input value.
    private void SetBottomNumber(string bottomNumber)
    {
        _bottom = int.Parse(bottomNumber);
    }

    public float CalculateFraction()
    {
        return _top / (float)_bottom; // Cast to float to avoid integer division
    }

    public void DoFraction(string topNumber, string bottomNumber)
    {
        SetTopNumber(topNumber);
        SetBottomNumber(bottomNumber);
        Console.WriteLine($"Fraction result: {CalculateFraction()}");
    }
}