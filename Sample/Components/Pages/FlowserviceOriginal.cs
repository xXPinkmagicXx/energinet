namespace Sample;

public class FlowService
{
    private List<FlowData>? _flowData {get; set;} = null;

    private List<FlowData> flowData => _flowData ??= GetFlowDataInternalAsync().Result;

    private async Task<List<FlowData>> GetFlowDataInternalAsync()
    {
        var flowData = new List<FlowData>
        {
            new FlowData { Name = "Station 2", Value = 2 },
            new FlowData { Name = "Station 1", Value = 1 },
        };
        
        flowData.Sort((x, y) => string.Compare(x.Name, y.Name));
        return flowData;    
    }

    public List<FlowData> GetFlowData() => flowData;
}


public class FlowData
{
    public required string Name { get; set; }
    public int Value { get; set; }
}