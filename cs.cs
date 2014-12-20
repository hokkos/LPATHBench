using System;
using System.Diagnostics;

public sealed class LongestPathFinder{

	int numNodes = -1;
	readonly int[][] nodes;
	readonly bool[] visited;

	LongestPathFinder() {
		nodes = ReadPlaces();
		visited = new bool[numNodes];
	}

	public static void Main(String[] args) {
		var longestPathFinder = new LongestPathFinder();
		var watch = Stopwatch.StartNew();
		int len = longestPathFinder.GetLongestPath(0);
		watch.Stop();
		var elapsedMs = watch.ElapsedMilliseconds;
		Console.WriteLine("{0} LANGUAGE CSharp {1}", len, elapsedMs);
	}

	/**
	 * int[node][dest|cost|...]
	 */
	int[][] ReadPlaces() {
		string[] lines = System.IO.File.ReadAllLines("agraph");
		numNodes = System.Convert.ToInt32(lines[0]);
		var nodes = new int[numNodes][];
		for(int i = 0; i < numNodes; i++){
		    nodes[i]=new int[0];
		}
		for(int i = 1; i < lines.Length; i++) {
		    string[] nums = lines[i].Split(' ');
		    if(nums.Length < 3){
				break;
		    }
		    int node = System.Convert.ToInt32(nums[0]);
			int neighbour = System.Convert.ToInt32(nums[1]);
			int cost = System.Convert.ToInt32(nums[2]);

			int index = nodes[node].Length;
			int[] replacement = new int[index + 2];
			Array.Copy(nodes[node], replacement, index);
			replacement[index] = neighbour;
			replacement[index+1] = cost;

			nodes[node] = replacement;
		}
		return nodes;
	}

	int GetLongestPath(int nodeID){
		visited[nodeID] = true;
		int dist, max=0;

		int length = nodes[nodeID].Length;

		for (int i = 0; i < length; i+=2) {

			int dest = nodes[nodeID][i];

			if (!visited[dest]) {
				dist = nodes[nodeID][i + 1] + GetLongestPath(dest);
				if (dist > max) {
					max = dist;
				}
			}
		}

		visited[nodeID] = false;
		return max;
	}

}
