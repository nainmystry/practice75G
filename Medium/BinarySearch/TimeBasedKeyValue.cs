
public class TimeMap
{
    Dictionary<string, (SortedSet<int> set, Dictionary<int, string> dict)> Data { get; set; } = [];

    public TimeMap() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        if (Data.TryGetValue(key, out var data))
        {
            data.set.Add(timestamp);
            data.dict[timestamp] = value;
        }
        else Data[key] = ([timestamp], new Dictionary<int, string> { [timestamp] = value });
    }
    
    public string Get(string key, int timestamp) {
        if (!Data.TryGetValue(key, out var data)) return "";
        if (data.dict.TryGetValue(timestamp, out var val)) return val;
        if (data.set.Min >= timestamp) return "";
        var last = data.set.GetViewBetween(data.set.Min, timestamp).Max;
        if (last == 0) return "";
        return data.dict[last];
    }
}

public class TimeMap2
{

    record struct TimeValue(int Timestamp, string Value);

    Dictionary<string, List<TimeValue>> dict = new();

    IComparer<TimeValue> timestampComparer =
        Comparer<TimeValue>.Create((a, b) => a.Timestamp - b.Timestamp);

    public TimeMap2() {
        
    }
    
    public void Set(string key, string value, int timestamp) {
        if (!dict.TryGetValue(key, out var values))
            values = dict[key] = new();

        values.Add(new TimeValue(timestamp, value));
    }
    
    public string Get(string key, int timestamp) {
        if (!dict.TryGetValue(key, out var values))
            return string.Empty;

        var target = new TimeValue(timestamp, string.Empty);
        var index = values.BinarySearch(target, timestampComparer);
        var upperBound = Math.Abs(index + 1);
        var value = values.ElementAtOrDefault(upperBound - 1);
        return value.Value ?? string.Empty;
    }
}