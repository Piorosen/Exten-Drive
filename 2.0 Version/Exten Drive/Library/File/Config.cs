using System.Text;
using System.Runtime.InteropServices;

namespace Library.File
{
    class Config
    {
        [DllImport("kernel32")]
        public static extern int GetPrivateProfileString(string section, string key, string Default, StringBuilder result, int size, string path);
        [DllImport("kernel32")]
        public static extern long WritePrivateProfileString(string section, string key, string val, string path);
    }
}
