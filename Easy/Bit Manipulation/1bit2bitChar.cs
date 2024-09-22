public class OneBitTwoBit {
    public bool IsOneBitCharacter(int[] bits) {
         int i = 0;

        // while (i < bits.Length - 1)
        // {
        //     i += bits[i] == 0 ? 1 : 2;
        // }

        // return i == bits.Length - 1;
        while(i < bits.Length-1)
        {
            if(bits[i] == 1)
            {
                i++;
            }
            i++;
        }
        return i == bits.Length-1;
    }
    
}