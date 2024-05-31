class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int length, int laps)
        : base(date, length)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (_length / 60.0);
    }

    public override double GetPace()
    {
        return _length / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{base.GetSummary()}, Laps: {_laps}, Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min per km";
    }
}