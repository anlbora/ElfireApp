using ElfireApp.Data;

public class DesignFireLoad
{
    public string OccupancyType { get; set; }
    public double FractileValue { get; set; }
    public FireGrowthRate GrowthRate { get; set; }
    public double LimitingTime { get; set; }

    public DesignFireLoad(string occupancyType, double fractile, FireGrowthRate fireGrowthRate, double limitingTime)
    {
        this.OccupancyType = occupancyType;
        this.FractileValue = fractile;
        this.GrowthRate = fireGrowthRate;
        this.LimitingTime = limitingTime;
    }
}
