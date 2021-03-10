using System;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace CheckMate.Common
{
    public static class httpsValidation
    {
        //Call GenerateSSLpubklickey callback method and repalce here   
        static string PUBLIC_KEY = "98 09 74 21 79 7F 13 32 C4 1F D1 15 99 85 07 29 E2 19 25 28 5D B3 8E 8C 1F 6A B1 7E E0 59 0E DF 17 8F 33 C7 6B B1 24 0C 80 8B 52 D9 C2 9B BE D2 2B B9 59 B3 14 FC 04 0B 01 72 43 D1 DD 1F 78 44 92 E6 92 9D E8 FA 23 3A 82 59 E1 14 03 3D BD D2 E2 A1 3A 94 BD AB 7A D1 50 7D A5 52 58 0A 30 B6 0D 7D 18 AB 20 C2 80 B7 85 51 35 46 75 49 5A FE 7C F2 64 FD CC 57 FC 72 04 2C 5F 8C 83 34 CD 02 A9 7D 1B 66 71 38 96 AD E7 1B D2 34 5A F6 01 07 75 40 E3 97 53 A3 4C 2D D9 D4 E8 90 0A E9 62 0F 90 B6 70 A4 6A 4E EA 67 5C 3B 07 3D 34 27 27 8C 3C 37 0F 2E 7F 12 56 B5 97 6D 76 05 E7 CB A5 7C 43 7D 0B 84 F0 BC 91 BE 8D 81 7C 93 2D 51 C2 9C A1 C9 D8 AD 56 35 11 B1 82 1E C1 E6 2D BD F8 28 2F F7 06 72 7A 5E AE 04 51 B0 33 00 D3 6F BF AD CC 0B E8 F2 A0 79 68 BF 03 92 77 00 C4 E5 B8 0B";
        public static void Initialize()
        {
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            // ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;  
            //Generate Public Key and replace publickey variable   
            //  ServicePointManager.ServerCertificateValidationCallback = GenerateSSLPublicKey;  
            ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;
        }

        static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            var certPublicString = certificate?.GetPublicKeyString();
            var keysMatch = PUBLIC_KEY == certPublicString;
            return keysMatch;
        }
    }
}
