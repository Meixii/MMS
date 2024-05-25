using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace MMS
{
    internal class start
    {
    }


    public class PasscodeHasher
    {
        private const int SaltSize = 16; // 128-bit salt
        private const int HashSize = 32; // 256-bit hash
        private const int Iterations = 100000; // Adjust for desired security vs. performance

        private static readonly List<string> securityQuestions = new List<string>
    {
        "What is your mother's maiden name?",
        "What was the name of your first pet?",
        "What is your favorite childhood book?",
        // Add more questions here
    };

        public static (byte[] hash, byte[] salt) HashPasscode(string passcode)
        {
            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(passcode, SaltSize, Iterations, HashAlgorithmName.SHA256))
            {
                byte[] hash = rfc2898DeriveBytes.GetBytes(HashSize);
                byte[] salt = rfc2898DeriveBytes.Salt;
                return (hash, salt);
            }
        }

        public static bool VerifyPasscode(string passcode, byte[] hash, byte[] salt)
        {
            var newHash = HashPasscode(passcode);
            return newHash.hash.SequenceEqual(hash) && newHash.salt.SequenceEqual(salt);
        }
        // Constants for file storage and encryption
        private const string PasscodeFileName = "passcode.dat";
        private const string SecurityQuestionFileName = "security.dat";

        // Passcode Storage and Retrieval
        private static void StorePasscode(byte[] hash, byte[] salt)
        {
            byte[] encryptedData = ProtectedData.Protect(
                hash.Concat(salt).ToArray(), null, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(PasscodeFileName, encryptedData);
        }

        private static (byte[] hash, byte[] salt) RetrievePasscode()
        {
            if (!File.Exists(PasscodeFileName))
                return (null, null);

            byte[] encryptedData = File.ReadAllBytes(PasscodeFileName);
            byte[] decryptedData = ProtectedData.Unprotect(encryptedData, null, DataProtectionScope.CurrentUser);

            byte[] hash = decryptedData.Take(HashSize).ToArray();
            byte[] salt = decryptedData.Skip(HashSize).ToArray();
            return (hash, salt);
        }





        // Security Question Storage and Verification
        public static void StoreSecurityQuestion(string question, string answerHash)
        {
            // ... (Hash the answer and store along with the question)
        }

        public static void StoreSecurityQuestionAndAnswer(string question, string answer)
        {
            // Hash the answer
            var answerHash = HashPasscode(answer).hash; // Reuse the passcode hashing method

            // Store the question and hashed answer (e.g., in a file)
            var data = $"{question}|{Convert.ToBase64String(answerHash)}";
            File.WriteAllText(SecurityQuestionFileName, data);
        }

        public static bool VerifySecurityQuestionAndAnswer(string question, string answer)
        {
            if (!File.Exists(SecurityQuestionFileName))
                return false; // No security question set

            var data = File.ReadAllText(SecurityQuestionFileName);
            var parts = data.Split('|');
            if (parts.Length != 2)
                return false; // Invalid data format

            var storedQuestion = parts[0];
            var storedAnswerHash = Convert.FromBase64String(parts[1]);

            // Hash the provided answer
            var answerHash = HashPasscode(answer).hash;

            return storedQuestion == question && storedAnswerHash.SequenceEqual(answerHash);
        }

        // Passcode Creation and Verification (Combined for the Startup Window)
        public static bool CreateOrVerifyPasscode(string enteredPasscode)
        {
            var (storedHash, storedSalt) = RetrievePasscode();

            if (storedHash == null)
            {
                // No passcode set yet: Create new passcode
                var (hash, salt) = HashPasscode(enteredPasscode);
                StorePasscode(hash, salt);
                return true; // Passcode created successfully
            }
            else
            {
                // Passcode exists: Verify the entered passcode
                return VerifyPasscode(enteredPasscode, storedHash, storedSalt);
            }
        }


    }
}
