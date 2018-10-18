using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Text.RegularExpressions;
using System.Numerics;


namespace bus_lab1_test
{
    class AES
    {
        private static string line;
        static String file(String file_name)
        {
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(file_name))
                {
                    // Read the stream to a string, and write the string to the console.
                    line = sr.ReadToEnd();
                    //  Console.WriteLine(line);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
            return line;
        }

        public static void aes(String file_name)
        {
            /*
             try
             {   // Open the text file using a stream reader.
                 using (StreamReader sr = new StreamReader(file_name))
                 {
                     // Read the stream to a string, and write the string to the console.
                     line = sr.ReadToEnd();
                     //  Console.WriteLine(line);
                 }
             }
             catch (Exception e)
             {
                 Console.WriteLine("The file could not be read:");
                 Console.WriteLine(e.Message);
             }*/
            line = file(file_name);

            //algorytm aes-a
            try
            {

                string original = line;//"Here is some data to encrypt!";

                // Create a new instance of the Aes
                // class.  This generates a new key and initialization 
                // vector (IV).
                using (Aes myAes = Aes.Create())
                {

                    // Encrypt the string to an array of bytes.
                    byte[] encrypted = EncryptStringToBytes_Aes(original, myAes.Key, myAes.IV);



                    // Decrypt the bytes to a string.
                    //
                    //Stream fs = .PostedFile.InputStream;
                    /*
                    using(StreamWriter outputFile = new StreamWriter(Path.Combine("klucz.txt")))
                    {
                        outputFile.WriteLine(myAes.Key);
                    }*/
                    try
                    {
                        using (var fs = new FileStream("klucz.txt", FileMode.Open, FileAccess.Write))
                        {
                            fs.Write(encrypted, 0,encrypted.Length);
                            
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Exception caught in process: {0}", ex);
                      
                    }


                  //  File.WriteAllBytes("klucz.txt", encrypted);
                    String from_code = file("szyfr.txt");
                    BinaryReader br = new BinaryReader(File.Open("szyfr.txt", FileMode.Open));
                   // encrypted = br.ReadBytes(from_code.Length);
                    String roundtrip = DecryptStringFromBytes_Aes(encrypted, myAes.Key, myAes.IV);

                    //Display the original data and the decrypted data.
                    Console.WriteLine("Original:   {0}", original);
                    Console.WriteLine("Round Trip: {0}", roundtrip);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error: {0}", e.Message);
            }
        }
        static byte[] EncryptStringToBytes_Aes(string plainText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();

                    }
                }
            }

            File.WriteAllBytes("szyfr.txt", encrypted);

            

            // Return the encrypted bytes from the memory stream.
            return encrypted;

        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (Key == null || Key.Length <= 0)
                throw new ArgumentNullException("Key");
            if (IV == null || IV.Length <= 0)
                throw new ArgumentNullException("IV");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine("odszyfrowane.txt")))
            {
                //foreach (string line in lines)
                    outputFile.WriteLine(plaintext);
            }

                return plaintext;

        }
    }
}



