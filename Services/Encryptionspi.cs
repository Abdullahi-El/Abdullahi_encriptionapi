namespace EncryptionAPI.Services
{
    public class EncryptionService
    {
        // Metod för att kryptera till rövarspråket
        public string Encrypt(string plainText)
        {
            var result = "";
            foreach (var c in plainText.ToLower())
            {
                if (IsConsonant(c))
                {
                    result += $"{c}o{c}"; // Dubbla konsonanten och lägg till "o"
                }
                else
                {
                    result += c; // Behåll vokaler och andra tecken oförändrade
                }
            }
            return result;
        }

        // Metod för att dekryptera från rövarspråket
        public string Decrypt(string encryptedText)
        {
            var result = "";
            var i = 0;
            while (i < encryptedText.Length)
            {
                var currentChar = encryptedText[i];
                if (IsConsonant(currentChar))
                {
                    // Ta bort "o" och den dubbla konsonanten
                    result += currentChar;
                    i += 3; // Hoppa över "o" och nästa konsonant
                }
                else
                {
                    result += currentChar; // Behåll vokaler och andra tecken oförändrade
                    i++;
                }
            }
            return result;
        }

        // Hjälpmetod för att kontrollera om ett tecken är en konsonant
        private bool IsConsonant(char c)
        {
            return "bcdfghjklmnpqrstvwxyz".Contains(c);
        }
    }
}