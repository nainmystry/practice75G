using System.Net.Sockets;

public class Solution408
{
    public bool CanAliceWin(int[] nums) {
        long lessNum = 0;
        long gretNum = 0;
        foreach (int item in nums)
        {
            if(item >= 10)
            {
                gretNum+=item;
            }
            else{
                lessNum+=item;
            }
        }    
        if(lessNum == gretNum)
        return false;
        else 
        return true;
    }

    public int NonSpecialCount(int l, int r) {
        int res = 0;
        double dStart = (int)Math.Ceiling(Math.Sqrt(l));
        double startSquare;
        while(true)
        {
            startSquare = dStart * dStart;
            if (startSquare > r) break;
            if(l <= startSquare && startSquare <= r && IsPrime(dStart))
            {
                res++;
            }
            dStart++;
        }
        return  (r - l + 1) - res;
    }

    private bool IsPrime(double n) 
    {
        if (n <= 1) return false;
        if (n <= 3) return true;
        if (n % 2 == 0 || n % 3 == 0) return false;

        for (long i = 5; i * i <= n; i += 6) {
            if (n % i == 0 || n % (i + 2) == 0) return false;
        }
        return true;
    }

    public int NumberOfSubstrings(string s) 
    {
        int n = s.Length;
        int[] pre = new int[n];
        for (int i = 0; i < n; i++)
        {
            if (i == 0)
            {
                pre[i] = s[i] == '1' ? 1 : 0;
            }
            else
            {
                pre[i] = pre[i - 1] + (s[i] == '1' ? 1 : 0);
            }
        }
        int ans = 0;
        for (int i = 0; i < n; i++)
        {
            int ones = 0, zeros = 0;
            for (int j = i; j < n; j++)
            {
                ones = pre[j];
                if (i > 0)
                {
                    ones -= pre[i - 1];
                }
                zeros = j - i + 1 - ones;

                if (ones < (zeros * zeros))
                {
                    j += (zeros * zeros) - ones - 1;
                }
                else
                {
                    ans++;
                    if (ones > (zeros * zeros))
                    {
                        int diff = (int)Math.Sqrt(ones) - zeros;
                        int temp = diff + j;
                        if (temp >= n)
                        {
                            ans += n - j - 1;
                        }
                        else
                        {
                            ans += temp - j;
                        }
                        j = temp;
                    }
                }
            }
        }
        return ans;
    }
    public int NumberOfSubstrings1(string s) 
    {
        int numSub = 0;
        int minLength;
        Queue<int> zeroesIndex = new Queue<int>();
        for (int numZeroes = 0; numZeroes <= 200; ++numZeroes) {
            minLength = numZeroes * numZeroes + numZeroes - 1;
            if (minLength == -1) {
                minLength = 0;
            }
            zeroesIndex.Clear();
            for (int r = 0, l = 1, m = 0; r < s.Length; ++r, ++l) {
                if (s[r] == '0') {
                    zeroesIndex.Enqueue(r);
                }
                if (numZeroes < zeroesIndex.Count) {
                    l = r - zeroesIndex.Dequeue();
                }
                if (numZeroes > 0 && zeroesIndex.Count > 0) {
                    m = r - zeroesIndex.Peek();
                } else {
                    m = 0;
                }
                if (zeroesIndex.Count == numZeroes) {
                    numSub += Math.Max(0, l - Math.Max(m, minLength));
                }
            }
        }
        return numSub;
    }

    public bool CanReachCorner1(int X, int Y, int[][] circles)
    {
        int[,] grid = new int[X + 1, Y + 1];
        bool[,] visited = new bool[X + 1, Y + 1];

        // Mark blocked areas by circles
        foreach (var circle in circles)
        {
            int cx = circle[0], cy = circle[1], r = circle[2];
            //loop iterates from cx - r to cx + r
            for (int i = Math.Max(0, cx - r); i <= Math.Min(X, cx + r); i++)
            {
                //loop iterates from cy - r to cy + r
                for (int j = Math.Max(0, cy - r); j <= Math.Min(Y, cy + r); j++)
                {
                    //checks if the point is inside the circle with distance formula.
                    //If this distance is less than or equal to the radius r, the point (i, j) is within the circle.
                    if (Math.Sqrt(Math.Pow(i - cx, 2) + Math.Pow(j - cy, 2)) <= r)
                    {
                        grid[i, j] = -1; // Mark as blocked
                    }
                }
            }
        }

        // BFS from (0, 0) to (X, Y)
        Queue<(int, int)> queue = new Queue<(int, int)>();
        queue.Enqueue((0, 0));
        visited[0, 0] = true;

        int[][] directions = new int[][]
        {
            new int[] {0, 1}, // Up
            new int[] {1, 0}, // Right
            new int[] {0, -1}, // Down
            new int[] {-1, 0}  // Left
        };

        //Traverse the BFS untill the queue is empty or the result is found.
        while (queue.Count > 0)
        {
            var (x, y) = queue.Dequeue();
            
            if (x == X && y == Y) return true;

            foreach (var dir in directions)
            {
                int nx = x + dir[0];
                int ny = y + dir[1];

                if (nx >= 0 && nx <= X && ny >= 0 && ny <= Y && !visited[nx, ny] && grid[nx, ny] != -1)
                {
                    visited[nx, ny] = true;
                    queue.Enqueue((nx, ny));
                }
            }
        }

        return false;
    }

    public bool CanReachCorner(int X, int Y, int[][] A) {
        int n = A.Length;
        int[] f = new int[n + 2];
        for (int i = 0; i < n + 2; i++) {
            f[i] = i;
        }

        for (int i = 0; i < n; i++) {
            int x = A[i][0];
            int y = A[i][1];
            int r = A[i][2];

            if (x - r <= 0 || y + r >= Y) {
                f[Find(f, n)] = Find(f, i);
            }
            if (x + r >= X || y - r <= 0) {
                f[Find(f, n + 1)] = Find(f, i);
            }

            for (int j = 0; j < i; j++) {
                int x2 = A[j][0];
                int y2 = A[j][1];
                int r2 = A[j][2];

                if ((x - x2) * (x - x2) + (y - y2) * (y - y2) <= (r + r2) * (r + r2)) {
                    f[Find(f, i)] = Find(f, j);
                }
            }
        }

        return Find(f, n) != Find(f, n + 1);
    }

    private int Find(int[] f, int i) {
        if (f[i] != i) {
            f[i] = Find(f, f[i]);
        }
        return f[i];
    }
}