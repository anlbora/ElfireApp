using ElfireApp.Data;

public class DesignFireLoadData
{
    public Dictionary<int, DesignFireLoad> DesignFireLoadValues { get; set; }

    public DesignFireLoadData()
    {
        this.DesignFireLoadValues = new Dictionary<int, DesignFireLoad>();

        DesignFireLoad office = new DesignFireLoad("Office", 511, FireGrowthRate.Medium, 20);
        DesignFireLoad residential = new DesignFireLoad("Residential", 948, FireGrowthRate.Medium, 20);
        DesignFireLoad hospital = new DesignFireLoad("Hospital", 280, FireGrowthRate.Medium, 20);
        DesignFireLoad hotel = new DesignFireLoad("Hotel", 377, FireGrowthRate.Medium, 20);
        DesignFireLoad library = new DesignFireLoad("Library", 1824, FireGrowthRate.Fast, 15);
        DesignFireLoad classroom = new DesignFireLoad("Classroom", 347, FireGrowthRate.Medium, 20);
        DesignFireLoad shoppingCenter = new DesignFireLoad("Shopping Center", 730, FireGrowthRate.Fast, 15);
        DesignFireLoad transport = new DesignFireLoad("Transport", 122, FireGrowthRate.Slow, 25);
        DesignFireLoad theatre = new DesignFireLoad("Theatre", 365, FireGrowthRate.Fast, 15);

        DesignFireLoadValues[0] = hospital;
        DesignFireLoadValues[1] = hotel;
        DesignFireLoadValues[2] = library;
        DesignFireLoadValues[3] = office;
        DesignFireLoadValues[4] = classroom;
        DesignFireLoadValues[5] = shoppingCenter;
        DesignFireLoadValues[6] = transport;
        DesignFireLoadValues[7] = theatre;
        DesignFireLoadValues[8] = residential;
    }

    public void AddValue(DesignFireLoad designFireLoad)
    {
        int lastKey = DesignFireLoadValues.Count > 0 ? DesignFireLoadValues.Keys.Max() : -1;
        DesignFireLoadValues.Add(lastKey + 1, designFireLoad);
    }

    public List<DesignFireLoad> GetDesignFireLoadList()
    {
        return DesignFireLoadValues.Values.ToList();
    }
}
