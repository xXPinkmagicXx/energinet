namespace Sample;

public class FlowService2
{
    private List<FlowData1>? _flowData {get; set;} = null;
    public async Task<List<FlowData1>> GetFlowDataAsync()
    {
        if (_flowData != null)
        {
            return _flowData;
        }

        return await GetFlowDataInternalAsync();
    }

    private async Task<List<FlowData1>> GetFlowDataInternalAsync()
    {
        Task.Delay(1000).Wait(); // Simulate async operation
        _flowData = new List<FlowData1>
        {
            new FlowData1 { Name = "Station 2", Value = 2.2 },
            new FlowData1 { Name = "Station 1", Value = 1.1 },
            new FlowData1 { Name = "Station 4", Value = 1.4 },
        };
        
        _flowData.Sort((x, y) => string.Compare(x.Name, y.Name));
        return _flowData;    
    }
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
