using System;
using System.Collections.Generic;
using System.Linq;

public class Solution {
    public int MinimumTime(int n, int[][] relations, int[] time) {
        // Build graph and in-degree array
        var graph = new List<int>[n];
        for (int i = 0; i < n; i++) graph[i] = new List<int>();
        int[] inDegree = new int[n];
        foreach (var rel in relations) {
            int prev = rel[0] - 1, next = rel[1] - 1;
            graph[prev].Add(next);
            inDegree[next]++;
        }

        // Earliest finish time for each course
        int[] earliest = new int[n];

        // Queue for courses with no prerequisites
        var queue = new Queue<int>();
        for (int i = 0; i < n; i++) {
            if (inDegree[i] == 0) {
                earliest[i] = time[i];
                queue.Enqueue(i);
            }
        }

        while (queue.Count > 0) {
            int curr = queue.Dequeue();
            foreach (var neighbor in graph[curr]) {
                // Update neighbor's earliest finish time
                earliest[neighbor] = Math.Max(earliest[neighbor], earliest[curr] + time[neighbor]);
                inDegree[neighbor]--;
                if (inDegree[neighbor] == 0) {
                    queue.Enqueue(neighbor);
                }
            }
        }

        int result = 0;
        foreach (int t in earliest) result = Math.Max(result, t);
        return result;
    }
}
