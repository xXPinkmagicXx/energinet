namespace Sample;

public class FlowService1
{
    private List<FlowData1>? _flowData {get; set;} = null;

    private List<FlowData1> flowData => _flowData ??= GetFlowDataInternalAsync().Result;

    private async Task<List<FlowData1>> GetFlowDataInternalAsync()
    {
        var flowData = new List<FlowData1>
        {
            new FlowData1 { Name = "Station 2", Value = 2.2 },
            new FlowData1 { Name = "Station 1", Value = 1.1 },
            new FlowData1 { Name = "Station 4", Value = 1.4 },
        };
        
        flowData.Sort((x, y) => string.Compare(x.Name, y.Name));
        return flowData;    
    }

    public List<FlowData1> GetFlowData() => flowData;

    public void AddFlowData(FlowData1 flowData)
    {
        this._flowData?.Add(flowData);
    }

    public bool RemoveFlowData(FlowData1 flowData)
    {
        return this._flowData?.Remove(flowData) ?? false;
    }

    public List<FlowData1> SortByValue()
    {
        this._flowData?.Sort((x, y) => x.Value.CompareTo(y.Value));
        return this._flowData ?? new List<FlowData1>();
    }
}


public class FlowData1
{
    public required string Name { get; set; }
    public double Value { get; set; }
}