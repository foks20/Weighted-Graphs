var graph = new Dictionary<string, List<(string, int)>>()
{
    { "A", new List<(string, int)>() { ("B", 5), ("C", 2) } },
    { "B", new List<(string, int)>() { ("A", 2), ("C", 7) } },
    { "C", new List<(string, int)>() { ("A", 3), ("B", 11) } }
};

foreach (var chinatown in graph)
{
    Console.WriteLine("Chinatown: " + chinatown.Key);

    foreach (var edge in chinatown.Value)
    {
        Console.WriteLine($"    -> Destination: {edge.Item1}, Weight: {edge.Item2}");
    }
}
var startNode = "A";
var distances = new Dictionary<string, int>();
var priorityQueue = new PriorityQueue<(string, int)>((a, b) => a.Item2.CompareTo(b.Item2));

public class PriorityQueue<T>
{
    private SortedSet<T> set;
    private Comparison<T> comparison;

    public PriorityQueue(Comparison<T> comparison)
    {
        this.set = new SortedSet<T>(Comparer<T>.Create(comparison));
        this.comparison = comparison;
    }

    public void Enqueue(T item)
    {
        set.Add(item);
    }

    public T Dequeue()
    {
        var item = set.Min;
        set.Remove(item);
        return item;
    }

    public int Count => set.Count;
}