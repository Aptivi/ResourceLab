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

using ResourceLab.Management;
using System.Resources;

namespace ResDemo2
{
    public static class BinResource
    {
        public static void AddResource()
        {
            var resourceManager = new ResourceManager("ResDemo2.Resources.Demonstration", typeof(BinResource).Assembly);
            ResourcesManager.AddResourceManager("ResDemo2", resourceManager);
        }
    }
}
