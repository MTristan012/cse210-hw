class Activity
{
    protected DateTime _date;
    protected int _length;

    public Activity(DateTime date, int length)
    {
        _date = date;
        _length = length;
    }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return $"Date: {_date.ToShortDateString()}, Length: {_length} minutes";
    }
}