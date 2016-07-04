using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Clock {
    public static class FontHelper {

        // Check string array for valid font and return its string
        // if no fount found, return the first thing in the list
        //
        public static string findValidFont(string[] fontList) {
            InstalledFontCollection fonts = new InstalledFontCollection();

            foreach (string fnt in fontList) {
                foreach (FontFamily name in fonts.Families) {
                    if (fnt == name.Name) return name.Name;
                }
            }

            return fonts.Families[0].Name;
        }
    }
}
