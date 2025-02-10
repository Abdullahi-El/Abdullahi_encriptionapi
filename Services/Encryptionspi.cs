using System.Text;

namespace EncryptionAPI.Services
{
    public class Encryptionspi
    {
        // Encrypts text to Rövarspråket
        public string Encrypt(string plainText)
        {
            var result = new StringBuilder(); // Use StringBuilder for performance

            foreach (var c in plainText)
            {
                if (IsConsonant(c))
                {
                    result.Append($"{c}o{c}"); // Double the consonant and add "o"
                }
                else
                {
                    result.Append(c); // Keep vowels and other characters unchanged
                }
            }

            return result.ToString();
        }

        // Decrypts text from Rövarspråket
        public string Decrypt(string encryptedText)
        {
            var result = new StringBuilder(); // Use StringBuilder for performance
            var i = 0;

            while (i < encryptedText.Length)
            {
                var currentChar = encryptedText[i];

                if (IsConsonant(currentChar) && i + 2 < encryptedText.Length && encryptedText[i + 1] == 'o' && encryptedText[i + 2] == currentChar)
                {
                    // Remove the "o" and the extra consonant
                    result.Append(currentChar);
                    i += 3; // Skip "o" and the next consonant
                }
                else
                {
                    result.Append(currentChar); // Keep vowels and other characters unchanged
                    i++;
                }
            }

            return result.ToString();
        }

        // Helper method to check if a character is a consonant
        private bool IsConsonant(char c)
        {
            // Check both lowercase and uppercase consonants
            return "bcdfghjklmnpqrstvwxyzBCDFGHJKLMNPQRSTVWXYZ".Contains(c);
        }

        // POST endpoint to encrypt text (to be used with a controller)
        public string EncryptPost(string plainText)
        {
            return Encrypt(plainText); // Calls the Encrypt method to perform encryption
        }

        // POST endpoint to decrypt text (to be used with a controller)
        public string DecryptPost(string cipherText)
        {
            return Decrypt(cipherText); // Calls the Decrypt method to perform decryption
        }

        // GET endpoint to encrypt text (just as an alternative)
        public string EncryptGet(string plainText)
        {
            return Encrypt(plainText); // Calls the Encrypt method to perform encryption
        }

        // GET endpoint to decrypt text (just as an alternative)
        public string DecryptGet(string cipherText)
        {
            return Decrypt(cipherText); // Calls the Decrypt method to perform decryption
        }
    }
}
