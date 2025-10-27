//
// ResourceLab  Copyright (C) 2025  Aptivi
//
// This file is part of ResourceLab
//
// ResourceLab is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// ResourceLab is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY, without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <https://www.gnu.org/licenses/>.
//

using ResDemo1;
using ResDemo2;
using ResDemo3;
using ResourceLab.Management;
using System.Globalization;
using Terminaux.Colors.Themes.Colors;
using Terminaux.Writer.ConsoleWriters;

namespace ResourceLab.Demo
{
    internal class Program
    {
        static void Main()
        {
            TextWriterColor.Write("ResourceLab demonstration\n", ThemeColorType.Banner);

            // Test 1: string resources
            SeparatorWriterColor.WriteSeparator("[1 out of 3] String resources", ThemeColorType.Banner, true);
            StringResource.AddResource();
            var strResource = ResourcesManager.GetResourceManager("ResDemo1");
            string resultString1 = strResource.GetString("StringResource") ?? "RESOURCE IS INVALID (UNEXPECTED)";
            string resultString2 = strResource.GetString("StringResource2") ?? "RESOURCE IS INVALID (UNEXPECTED)";
            string resultString3 = strResource.GetString("StringResource3") ?? "RESOURCE IS INVALID (EXPECTED)";
            ListEntryWriterColor.WriteListEntry("StringResource", resultString1);
            ListEntryWriterColor.WriteListEntry("StringResource2", resultString2);
            ListEntryWriterColor.WriteListEntry("StringResource3", resultString3);

            // Test 2: binary resources
            SeparatorWriterColor.WriteSeparator("[2 out of 3] Binary resources", ThemeColorType.Banner, true);
            BinResource.AddResource();
            var binResource = ResourcesManager.GetResourceManager("ResDemo2");
            var resultBin1 = binResource.GetObject("ImageLogo");
            var resultBin2 = binResource.GetObject("ImageLogo2");
            ListEntryWriterColor.WriteListEntry("ImageLogo", resultBin1 is byte[] resultBinByte1 ? $"{resultBinByte1.Length}" : "RESOURCE IS INVALID (UNEXPECTED)");
            ListEntryWriterColor.WriteListEntry("ImageLogo2", resultBin2 is byte[] resultBinByte2 ? $"{resultBinByte2.Length}" : "RESOURCE IS INVALID (EXPECTED)");

            // Test 3: localized resources
            SeparatorWriterColor.WriteSeparator("[3 out of 3] Localized resources", ThemeColorType.Banner, true);
            LocalizedResource.AddResource();
            var locResource = ResourcesManager.GetResourceManager("ResDemo3");
            var spanish = new CultureInfo("es");
            string resultStringSpanish1 = locResource.GetString("StringResource", spanish) ?? "RESOURCE IS INVALID (UNEXPECTED)";
            string resultStringSpanish2 = locResource.GetString("StringResource2", spanish) ?? "RESOURCE IS INVALID (UNEXPECTED)";
            string resultStringSpanish3 = locResource.GetString("StringResource3", spanish) ?? "RESOURCE IS INVALID (EXPECTED)";
            ListEntryWriterColor.WriteListEntry("StringResource", resultStringSpanish1);
            ListEntryWriterColor.WriteListEntry("StringResource2", resultStringSpanish2);
            ListEntryWriterColor.WriteListEntry("StringResource3", resultStringSpanish3);
        }
    }
}
