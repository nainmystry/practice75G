public class PlayerWinningKGamesInRow
{
    /*
    Question - 
    The competition process is as follows:
        The first two players in the queue play a game, and the player with the higher skill level wins.
        After the game, the winner stays at the beginning of the queue, and the loser goes to the end of it.
        The winner of the competition is the first player who wins k games in a row.
    */
    public int FindWinningPlayer(int[] skills, int k) 
    {
        try
        {
           int prev = skills[0], winInd = 0, conWin = 0, n = skills.Length;
           for (int I = 1; I < n; I++)
           {
               //If new player wins against prev one, reset counter & winner index
               if(skills[I] > prev){
                   prev = skills[I];
                   conWin = 0;
                   winInd = I;
               }
               conWin++;  //else increment cntr
               if(conWin == k) break;    //if cntr == k, break
           }        
           return winInd;
        }
        catch (Exception ex)
        {
           throw;
        } 
    }
}