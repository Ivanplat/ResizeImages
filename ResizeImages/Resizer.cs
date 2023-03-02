using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResizeImages
{
    internal class Resizer
    {
        private string? _FolderPath;
        public Resizer() 
        {
            _FolderPath = ConfigurationManager.AppSettings.Get("FolderPath");
        }
        public void Resize()
        {
            var files = Directory.GetFiles(_FolderPath);
            foreach (var file in files) 
            {
                Bitmap bm = new Bitmap(file);
                if(bm != null) 
                {
                    if(bm.Width > 2048 && bm.Height > 2048) 
                    {
                        var newWidth = bm.Width / 2;
                        var newHeight = bm.Height / 2;
                        var fileName = GetFileName(file);
                        Console.WriteLine($"Current file is: {fileName}");
                        Bitmap newBm = new Bitmap(bm, new Size(newWidth, newHeight));
                        newBm.Save(_FolderPath + "\\New\\" + fileName);
                    }
                }
            }
        }
        private string GetFileName(string path)
        {
            string result = "";
            for(int i = path.Length - 1; i >= 0; i--) 
            {
                if (path[i] != '\\')
                {
                    result += path[i];
                }
                else
                {
                    break;
                }
            }
            var ch = result.ToCharArray();
            Array.Reverse(ch);
            return new string(ch);
        }
    }
}
