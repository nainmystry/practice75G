public class Solution135
{
    public string LosingPlayer(int x, int y) {
        string alice = "Alice";
        string bob = "Bob";
        if(!CanPick(x,y))
        {
            return bob;
        }
        bool aliceTurn = true;
        while(true)
        {
            if(CanPick(x,y))
            {
                if(x > 0 && y >= 4)
                {
                    x -= 1;
                    y -= 4;
                }
                else{
                    y -= 11;
                }
            }
            else{
                if(aliceTurn)
                return bob;
                else
                return alice;
            }
        }
    }

    private bool CanPick(int x,int y)
    {
        return (x > 0 && y >= 4) || (y >= 11);
    }
}