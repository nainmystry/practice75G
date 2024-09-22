using System.Globalization;

public class AsteroidCollisions
{
    public int[] AsteroidCollision(int[] asteroids) {
        if(asteroids.Length == 0) return asteroids;

        Stack<int> stack = new Stack<int>();
        foreach (int asteroid in asteroids) {
            if (asteroid > 0) {
                stack.Push(asteroid);
            } else {
                while (stack.Count > 0 && stack.Peek() > 0 && stack.Peek() < Math.Abs(asteroid)) {
                    stack.Pop();
                }
                
                if (stack.Count == 0 || stack.Peek() < 0) {
                    stack.Push(asteroid);
                } else if (stack.Peek() == Math.Abs(asteroid)) {
                    stack.Pop();
                }
            }
        }
        int n = stack.Count;
        int[] res = new int[n];
        for (int I = n - 1; I >= 0; I--)
        {
            res[I] = stack.Pop();
        }
        return res;
    }
}