public class MinBitFlip {
    public int MinBitFlips(int start, int goal) {
        
        int res = start ^ goal;
        int shift = 0;
        while(res != 0){
            if((res & 1) == 1){
                shift++;
            }
            res >>= 1;
        }

        return shift;
    }
}