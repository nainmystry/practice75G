using System.Text;

public class BackspaceStringCompare {
    public bool BackspaceCompare(string s, string t) {
        if(isStringEqual(s,t))
            return true;
        else{
            return ValidateString(s, t);
        }
    }

    private bool ValidateString(string s, string t){
        try{
        int sl = 0;
        int tl = 0;
        StringBuilder sb = new();
        StringBuilder tb = new ();
        while(sl < s.Length || tl < t.Length){
            if(sl < s.Length){
            if(s[sl] == '#' && sb.Length > 0){
                sb.Length--;
            }
            if(s[sl] != '#'){
                sb.Append(s[sl]);
            }
            }
            if(tl < t.Length){
            if(t[tl] == '#' && tb.Length > 0){
                tb.Length--;
            }
            if(t[tl] != '#'){
                tb.Append(t[tl]);
            }
            }
            sl++;tl++;
        }
        return isStringEqual(sb.ToString(), tb.ToString());
        }
        catch(Exception ex){
            throw;
        }
    }

    private bool isStringEqual(string s, string t){
        return String.Equals(s,t,StringComparison.OrdinalIgnoreCase);
    }
}