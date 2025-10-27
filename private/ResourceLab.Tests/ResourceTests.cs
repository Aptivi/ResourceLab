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

using Microsoft.VisualStudio.TestTools.UnitTesting;
using ResDemo1;
using ResDemo2;
using ResDemo3;
using ResourceLab.Management;
using Shouldly;
using System.Globalization;

namespace ResourceLab.Tests
{
    [TestClass]
    public sealed class ResourceTests
    {
        [TestMethod]
        public void TestStringResource()
        {
            StringResource.AddResource();
            var strResource = ResourcesManager.GetResourceManager("ResDemo1");
            strResource.GetString("StringResource").ShouldNotBeNull();
            strResource.GetString("StringResource2").ShouldNotBeNull();
            strResource.GetString("StringResource3").ShouldBeNull();
        }

        [TestMethod]
        public void TestBinResource()
        {
            BinResource.AddResource();
            var binResource = ResourcesManager.GetResourceManager("ResDemo2");
            binResource.GetObject("ImageLogo").ShouldNotBeNull();
            binResource.GetObject("ImageLogo2").ShouldBeNull();
        }

        [TestMethod]
        public void TestLocalizedResource()
        {
            LocalizedResource.AddResource();
            var strResource = ResourcesManager.GetResourceManager("ResDemo3");
            var spanish = new CultureInfo("es-SP");
            strResource.GetString("StringResource", spanish).ShouldNotBeNull();
            strResource.GetString("StringResource2", spanish).ShouldNotBeNull();
            strResource.GetString("StringResource3", spanish).ShouldBeNull();
        }
    }
}
