using System.Text;

public class AddBinaryNumber {
    public string AddBinary(string a, string b) {
        StringBuilder sb = new StringBuilder();
        int carry = 0;
        int i = a.Length - 1;
        int j = b.Length - 1;

        while (i >= 0 || j >= 0 || carry > 0)
        {
            int sum = carry;
            if (i >= 0)
                sum += a[i--] - '0';
            if (j >= 0)
                sum += b[j--] - '0';

            sb.Insert(0, sum % 2);
            carry = sum / 2;
        }
        //Console.WriteLine(sb.ToString());
        return sb.ToString();
    }
}