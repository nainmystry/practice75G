using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;

public class CamelAndSnakeCase
{
    public void Run(string s){

        string sc = "";


        if(s.Contains('_') && s.Length > 1){
            sc = ConvertToCamelCase(s);
        }
        else{
            sc = ConvertToC(s);
        }
    }


    public string ConvertToCamelCase(string s){
        StringBuilder sc = new StringBuilder();

        string[] splitWords = s.Split('_', StringSplitOptions.RemoveEmptyEntries);

        for(int I = 0; I < splitWords.Length; I++){
            if(I == 0) {
            sc.Append(splitWords[I]);
            continue;
            }
            sc.Append(char.ToUpper(splitWords[I][0]) + splitWords[I].Substring(1));
        }

        var ss = Regex.Replace(s, @"_([a-z0-9])", m => m.Groups[1].Value.ToUpper());
        return sc.ToString();
    }

    public string ConvertToC(string s){
        StringBuilder sc = new StringBuilder();

        char[] letters = s.ToCharArray();

        for (int I = 0; I < letters.Length; I++)
        {
            int letter = Math.Abs(letters[I] - 'A');
            if(letter > -1 && letter < 26){
                if(I == 0){
                sc.Append(char.ToLower(letters[I]));
                }
            else{
                sc.Append('_');
                sc.Append(char.ToLower(letters[I]));
            }
                
            } 
            else{
                sc.Append(letters[I]);
            }
        }

        // string[] splitWords = s.Split('_', StringSplitOptions.RemoveEmptyEntries);

        // for(int I = 0; I < splitWords.Length; I++){
        //     if(I == 0) {
        //     sc.Append(splitWords[I]);
        //     continue;
        //     }
        //     sc.Append(char.ToUpper(splitWords[I][0]) + splitWords[I].Substring(1));
        // }

         var ss = Regex.Replace(s, @"(?<!^)([A-Z])", "_$1").ToLower();
        return sc.ToString();
    }
}