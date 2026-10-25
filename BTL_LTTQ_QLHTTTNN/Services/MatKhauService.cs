using System;
using System.Security.Cryptography;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public static class MatKhauService
    {
        private const int SoVongLap = 100000;
        private const int DoDaiSalt = 16;
        private const int DoDaiKhoa = 32;

        // Định dạng ASP.NET Identity V3: marker, PRF, iteration, salt length, salt, subkey.
        public static string BamMatKhau(string matKhau)
        {
            if (matKhau == null) throw new ArgumentNullException("matKhau");
            byte[] salt = new byte[DoDaiSalt];
            using (var rng = RandomNumberGenerator.Create()) rng.GetBytes(salt);
            byte[] key = Pbkdf2(matKhau, salt, SoVongLap, DoDaiKhoa, 2);
            byte[] result = new byte[13 + salt.Length + key.Length];
            result[0] = 1; GhiInt32(result, 1, 2); GhiInt32(result, 5, SoVongLap); GhiInt32(result, 9, salt.Length);
            Buffer.BlockCopy(salt, 0, result, 13, salt.Length); Buffer.BlockCopy(key, 0, result, 13 + salt.Length, key.Length);
            return Convert.ToBase64String(result);
        }

        public static bool KiemTraMatKhau(string matKhau, string hash)
        {
            if (matKhau == null || string.IsNullOrWhiteSpace(hash)) return false;
            try
            {
                byte[] data = Convert.FromBase64String(hash);
                if (data.Length < 14 || data[0] != 1) return false;
                int prf = DocInt32(data, 1), iterations = DocInt32(data, 5), saltLength = DocInt32(data, 9);
                if ((prf != 1 && prf != 2) || iterations < 1 || iterations > 1000000 || saltLength < 16 || saltLength > 64 || 13 + saltLength >= data.Length) return false;
                int keyLength = data.Length - 13 - saltLength;
                if (keyLength < 16 || keyLength > 64) return false;
                byte[] salt = new byte[saltLength], expected = new byte[keyLength];
                Buffer.BlockCopy(data, 13, salt, 0, saltLength); Buffer.BlockCopy(data, 13 + saltLength, expected, 0, keyLength);
                byte[] actual = Pbkdf2(matKhau, salt, iterations, keyLength, prf);
                int different = 0; for (int i = 0; i < expected.Length; i++) different |= expected[i] ^ actual[i];
                return different == 0;
            }
            catch (Exception ex) when (ex is FormatException || ex is ArgumentException || ex is CryptographicException || ex is OverflowException) { return false; }
        }

        private static byte[] Pbkdf2(string password, byte[] salt, int iterations, int length, int prf)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(password);
            using (HMAC hmac = prf == 2 ? (HMAC)new HMACSHA512(passwordBytes) : new HMACSHA256(passwordBytes))
            {
                int hashLength = hmac.HashSize / 8, blocks = (length + hashLength - 1) / hashLength;
                byte[] output = new byte[length], input = new byte[salt.Length + 4]; Buffer.BlockCopy(salt, 0, input, 0, salt.Length);
                for (int block = 1; block <= blocks; block++)
                {
                    input[input.Length - 4] = (byte)(block >> 24); input[input.Length - 3] = (byte)(block >> 16); input[input.Length - 2] = (byte)(block >> 8); input[input.Length - 1] = (byte)block;
                    byte[] u = hmac.ComputeHash(input), t = (byte[])u.Clone();
                    for (int round = 1; round < iterations; round++) { u = hmac.ComputeHash(u); for (int i = 0; i < t.Length; i++) t[i] ^= u[i]; }
                    Buffer.BlockCopy(t, 0, output, (block - 1) * hashLength, Math.Min(hashLength, length - (block - 1) * hashLength));
                }
                Array.Clear(passwordBytes, 0, passwordBytes.Length); return output;
            }
        }
        private static int DocInt32(byte[] bytes, int offset) { return (bytes[offset] << 24) | (bytes[offset + 1] << 16) | (bytes[offset + 2] << 8) | bytes[offset + 3]; }
        private static void GhiInt32(byte[] bytes, int offset, int value) { bytes[offset] = (byte)(value >> 24); bytes[offset + 1] = (byte)(value >> 16); bytes[offset + 2] = (byte)(value >> 8); bytes[offset + 3] = (byte)value; }
    }
}
