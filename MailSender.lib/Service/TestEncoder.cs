using System.Linq;

namespace MailSender.lib.Services
{
    public static class TestEncoder
    {
        public static string Encode(this string Source, int Key = 1) => new string(Source.Select(c => (char)(c + Key)).ToArray());

        public static string DeCode(this string Source, int Key = 1) => new string(Source.Select(c => (char)(c - Key)).ToArray());
    }
}