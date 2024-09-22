public class MD5Hashing
{
    // Assuming you have a method to compute MD5 hash of a string
    string ComputeMD5Hash(string input)
    {
        using (var md5 = System.Security.Cryptography.MD5.Create())
        {
            byte[] inputBytes = System.Text.Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert byte array to hexadecimal string
            var sb = new System.Text.StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2")); // "x2" formats byte to hexadecimal
            }
            return sb.ToString();
        }
    }

    // Function to shorten MD5 hash to 7 characters
    string ShortenMD5To7Chars(string input)
    {
        string md5Hash = ComputeMD5Hash(input);

        // Take the first 7 characters of the MD5 hash
        string shortenedHash = md5Hash.Substring(0, 7);

        return shortenedHash;
    }

    // Example usage:
    string originalString = "example_input_string";
    // string shortenedString = ShortenMD5To7Chars(originalString);
    // Console.WriteLine("Shortened MD5 hash:", shortenedString);

}