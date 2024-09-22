public class ReverseBit {
    public uint reverseBits(uint n) {
        uint reversed = 0;
        Console.WriteLine(Convert.ToString(n, 2));
        for(int I = 0; I < 32; I++){
            reversed = reversed << 1;//Left shift reversed object
            Console.WriteLine(Convert.ToString(reversed, 2));
            // if(n % 2 == 1)//if LSB of n == 1, then goes inside if block & sets bit for reversed.
            //     reversed++;
            reversed |= n & 1; 
            // Console.WriteLine(Convert.ToString(1, 2));
            // Console.WriteLine(Convert.ToString(n & 1, 2));
            n = n >> 1;//Right shifting bits to LSB
            // Console.WriteLine(Convert.ToString(n, 2));
            // Console.WriteLine(Convert.ToString(reversed, 2));
        }
        return reversed;
    }
}