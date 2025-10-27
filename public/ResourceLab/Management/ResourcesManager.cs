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

using ResourceLab.Exceptions;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Resources;

namespace ResourceLab.Management
{
    /// <summary>
    /// Manages the resources
    /// </summary>
	public static class ResourcesManager
	{
        internal static readonly Dictionary<string, ResourceManager> resourceManagers = [];

        /// <summary>
        /// A list of resource managers
        /// </summary>
        public static ReadOnlyDictionary<string, ResourceManager> ResourceManagers =>
            new(resourceManagers);

        /// <summary>
        /// Adds a resource manager to the list of resources
        /// </summary>
        /// <param name="name">Tag name of the resource manager to track</param>
        /// <param name="resourceManager">Resource manager to track</param>
        /// <exception cref="ResourceLabException">If resource already exists or doesn't exist in the resource manager</exception>
        public static void AddResourceManager(string name, ResourceManager resourceManager)
        {
            // Check to see if we have this resource, and verify the resource manager
            if (ResourceManagerExists(name))
                throw new ResourceLabException($"Resource {name} already exists");
            _ = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true) ??
                throw new ResourceLabException($"Resource {name} doesn't exist in the resource manager for the specified assembly");

            // Now, add it
            resourceManagers.Add(name, resourceManager);
        }

        /// <summary>
        /// Edits a resource manager in the list of resources
        /// </summary>
        /// <param name="name">Tag name of the resource manager to track</param>
        /// <param name="resourceManager">Resource manager to replace with</param>
        /// <exception cref="ResourceLabException">If resource already exists or doesn't exist in the resource manager</exception>
        public static void EditResourceManager(string name, ResourceManager resourceManager)
        {
            // Check to see if we have this resource, and verify the resource manager
            if (!ResourceManagerExists(name))
                throw new ResourceLabException($"Resource {name} doesn't exist");
            _ = resourceManager.GetResourceSet(CultureInfo.CurrentUICulture, true, true) ??
                throw new ResourceLabException($"Resource {name} doesn't exist in the resource manager for the specified assembly");

            // Now, add it
            resourceManagers[name] = resourceManager;
        }

        /// <summary>
        /// Removes a resource manager from the list of resources
        /// </summary>
        /// <param name="name">Tag name of the resource manager to remove</param>
        /// <exception cref="ResourceLabException">If resource doesn't exist</exception>
        public static void RemoveResourceManager(string name)
        {
            // Check to see if we have this resource, and remove it
            if (!ResourceManagerExists(name))
                throw new ResourceLabException($"Resource {name} doesn't exist");
            if (!resourceManagers.Remove(name))
                throw new ResourceLabException($"Failed to remove resource {name}");
        }

        /// <summary>
        /// Gets the resource manager
        /// </summary>
        /// <param name="name">Tag name of the resource manager to track</param>
        /// <returns>Output resource manager</returns>
        public static ResourceManager GetResourceManager(string name)
        {
            if (!TryGetResourceManager(name, out ResourceManager? resourceManager))
                throw new ResourceLabException($"Resource {name} doesn't exist");
            return resourceManager ??
                throw new ResourceLabException($"Failed to get resource {name}");
        }

        /// <summary>
        /// Tries to get the resource manager
        /// </summary>
        /// <param name="name">Tag name of the resource manager to track</param>
        /// <param name="resourceManager">Output resource manager</param>
        /// <returns>True if it exists; false otherwise</returns>
        public static bool TryGetResourceManager(string name, out ResourceManager? resourceManager) =>
            resourceManagers.TryGetValue(name, out resourceManager);

        /// <summary>
        /// Checks to see if a resource manager exists
        /// </summary>
        /// <param name="name">Tag name of the resource manager to track</param>
        /// <returns>True if it exists; false otherwise</returns>
        public static bool ResourceManagerExists(string name) =>
            resourceManagers.ContainsKey(name);
    }
}
