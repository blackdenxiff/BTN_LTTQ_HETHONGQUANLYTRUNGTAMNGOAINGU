using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BTL_LTTQ_QLHTTTNN.Services
{
    public sealed class EmailSenderSettings
    {
        public string Email { get; private set; }
        public string AppPassword { get; private set; }

        internal EmailSenderSettings(string email, string appPassword)
        {
            Email = email;
            AppPassword = appPassword;
        }
    }

    public static class EmailSettingsService
    {
        private static readonly byte[] Entropy = Encoding.UTF8.GetBytes("EnglishCenter.EmailSender.v1");

        public static EmailSenderSettings Load()
        {
            string email = Environment.GetEnvironmentVariable("QLTT_EMAIL_ADMIN");
            string password = Environment.GetEnvironmentVariable("QLTT_EMAIL_APP_PASSWORD");
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
                return new EmailSenderSettings(email.Trim(), password.Replace(" ", "").Trim());

            string path = SettingsPath;
            if (!File.Exists(path)) return null;
            try
            {
                byte[] protectedBytes = File.ReadAllBytes(path);
                byte[] clearBytes = ProtectedData.Unprotect(protectedBytes, Entropy, DataProtectionScope.CurrentUser);
                string[] values = Encoding.UTF8.GetString(clearBytes).Split(new[] { '\n' }, 2);
                if (values.Length != 2 || string.IsNullOrWhiteSpace(values[0]) || string.IsNullOrWhiteSpace(values[1])) return null;
                return new EmailSenderSettings(values[0].Trim(), values[1].Trim());
            }
            catch (CryptographicException) { return null; }
            catch (IOException) { return null; }
        }

        public static void Save(string email, string appPassword)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(appPassword))
                throw new ArgumentException("Nhập email người gửi và mật khẩu ứng dụng.");
            var address = new System.Net.Mail.MailAddress(email.Trim());
            string folder = Path.GetDirectoryName(SettingsPath);
            Directory.CreateDirectory(folder);
            byte[] clearBytes = Encoding.UTF8.GetBytes(address.Address + "\n" + appPassword.Replace(" ", "").Trim());
            byte[] protectedBytes = ProtectedData.Protect(clearBytes, Entropy, DataProtectionScope.CurrentUser);
            File.WriteAllBytes(SettingsPath, protectedBytes);
            Array.Clear(clearBytes, 0, clearBytes.Length);
        }

        private static string SettingsPath
        {
            get { return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "EnglishCenter", "email-sender.dat"); }
        }
    }
}
