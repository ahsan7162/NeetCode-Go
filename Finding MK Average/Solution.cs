class MKAverage {
    private int m, k;
    private Queue<int> stream;
    private SortedDictionary<int, int> small, middle, large;
    private long middleSum;

    public MKAverage(int m, int k)
    {
        this.m = m;
        this.k = k;
        stream = new Queue<int>();
        small = new SortedDictionary<int, int>();
        middle = new SortedDictionary<int, int>();
        large = new SortedDictionary<int, int>();
        middleSum = 0;
    }

    public void AddElement(int num)
    {
        stream.Enqueue(num);

        if (stream.Count < m)
            return;

        if (stream.Count == m)
        {
            // First window: initialize buckets
            var arr = stream.ToArray();
            Array.Sort(arr);

            for (int i = 0; i < k; ++i)
                AddToMultiset(small, arr[i]);
            for (int i = k; i < m - k; ++i)
            {
                AddToMultiset(middle, arr[i]);
                middleSum += arr[i];
            }
            for (int i = m - k; i < m; ++i)
                AddToMultiset(large, arr[i]);
        }
        else
        {
            // Remove oldest
            int old = stream.Dequeue();
            if (RemoveFromMultiset(small, old))
                RebalanceAfterRemove(small, middle, ref middleSum, true);
            else if (RemoveFromMultiset(large, old))
                RebalanceAfterRemove(large, middle, ref middleSum, false);
            else
            {
                RemoveFromMultiset(middle, old);
                middleSum -= old;
            }

            // Add new
            if (small.Count > 0 && num <= small.Last().Key)
            {
                AddToMultiset(small, num);
                RebalanceAfterAdd(small, middle, ref middleSum, true);
            }
            else if (large.Count > 0 && num >= large.First().Key)
            {
                AddToMultiset(large, num);
                RebalanceAfterAdd(large, middle, ref middleSum, false);
            }
            else
            {
                AddToMultiset(middle, num);
                middleSum += num;
            }
        }
    }

    public int CalculateMKAverage()
    {
        if (stream.Count < m)
            return -1;
        return (int)(middleSum / (m - 2 * k));
    }

    // Multiset helpers
    private void AddToMultiset(SortedDictionary<int, int> set, int val)
    {
        if (!set.ContainsKey(val))
            set[val] = 0;
        set[val]++;
    }

    private bool RemoveFromMultiset(SortedDictionary<int, int> set, int val)
    {
        if (set.ContainsKey(val))
        {
            if (--set[val] == 0)
                set.Remove(val);
            return true;
        }
        return false;
    }

    // Rebalance after removing oldest
    private void RebalanceAfterRemove(SortedDictionary<int, int> border, SortedDictionary<int, int> middle, ref long middleSum, bool isSmall)
    {
        // If border has less than k elements, move one from middle to border
        while (border.Values.Sum() < k)
        {
            if (isSmall)
            {
                int move = middle.First().Key;
                RemoveFromMultiset(middle, move);
                middleSum -= move;
                AddToMultiset(border, move);
            }
            else
            {
                int move = middle.Last().Key;
                RemoveFromMultiset(middle, move);
                middleSum -= move;
                AddToMultiset(border, move);
            }
        }
    }

    // Rebalance after adding new
    private void RebalanceAfterAdd(SortedDictionary<int, int> border, SortedDictionary<int, int> middle, ref long middleSum, bool isSmall)
    {
        // If border has more than k elements, move one to middle
        while (border.Values.Sum() > k)
        {
            if (isSmall)
            {
                int move = border.Last().Key;
                RemoveFromMultiset(border, move);
                AddToMultiset(middle, move);
                middleSum += move;
            }
            else
            {
                int move = border.First().Key;
                RemoveFromMultiset(border, move);
                AddToMultiset(middle, move);
                middleSum += move;
            }
        }
    }
}