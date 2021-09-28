using System;
using System.Linq;
using Asteroids.Rendering.Abstractions;
using Asteroids.Rendering.Vulkan.Imports;

namespace Asteroids.Rendering.Vulkan
{
    public sealed class VulkanRenderingProvider : IRenderingProvider
    {
        public IRenderer CreateRenderer()
        {
            VulkanResult result;
            VulkanInstanceCreateInfo instanceCreateInfo = new VulkanInstanceCreateInfo
            {
                sType = VulkanStructureType.InstanceCreateInfo,
                pNext = IntPtr.Zero,
                pApplicationInfo = new VulkanApplicationInfo
                {
                    sType = VulkanStructureType.ApplicationInfo,
                    pNext = IntPtr.Zero,
                    pApplicationName = "Asteroids",
                    applicationVersion = 0, // TODO: causes AccessViolationException, why?
                    pEngineName = "Asteroids Engine",
                    engineVersion = 0, // TODO: causes AccessViolationException, why?
                    apiVersion = VulkanUtils.CreateVersion(1, 2, 0)
                },
                enabledExtensionCount = 0,
                enabledLayerCount = 0,
                ppEnabledExtensionNames = Array.Empty<string>(),
                ppEnabledLayerNames = Array.Empty<string>()
            };

            IntPtr instance = IntPtr.Zero;
            
            result = Imports.Vulkan.CreateInstance(instanceCreateInfo, null, ref instance);
            if (result != VulkanResult.Success)
            {
                throw new Exception(); // TODO
            }

            uint count = 0;
            Imports.Vulkan.EnumeratePhysicalDevices(instance, ref count, null);

            if (count <= 0)
            {
                throw new Exception(); // TODO
            }

            IntPtr[] physicalDevices = new IntPtr[count];
            Imports.Vulkan.EnumeratePhysicalDevices(instance, ref count, physicalDevices);

            return new VulkanRenderer
            {
                Instance = instance,
                PhysicalDevices = physicalDevices.Select(PhysicalDevice.CreateFromHandle).ToArray()
            };
        }
    }
    
    internal sealed class VulkanRenderer : IRenderer
    {
        public IntPtr Instance { get; set; }
        
        public PhysicalDevice[] PhysicalDevices { get; set; }    
    }

    internal sealed class PhysicalDevice
    {
        public IntPtr Handle { get; set; }
        
        public VulkanQueueFamilyProperties[] QueueFamilyProperties { get; set; }

        public static PhysicalDevice CreateFromHandle(IntPtr handle)
        {
            PhysicalDevice physicalDevice = new PhysicalDevice
            {
                Handle = handle
            };
            
            uint count = 0;
            Imports.Vulkan.GetPhysicalDeviceQueueFamilyProperties(handle, ref count, null);

            if (count <= 0)
            {
                throw new Exception(); // TODO
            }

            physicalDevice.QueueFamilyProperties = new VulkanQueueFamilyProperties[count];
            Imports.Vulkan.GetPhysicalDeviceQueueFamilyProperties(handle, ref count, physicalDevice.QueueFamilyProperties);
            
            return physicalDevice;
        }
    }

    internal sealed class LogicalDevice
    {
        public PhysicalDevice PhysicalDevice { get; set; }
        
        
    }
}