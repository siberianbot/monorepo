using System;
using System.Runtime.InteropServices;

namespace Asteroids.Rendering.Vulkan.Imports
{
    internal static class Vulkan
    {
        private const string DllName = "vulkan-1";

        [DllImport(DllName, CharSet = CharSet.Ansi, EntryPoint = "vkCreateInstance", ExactSpelling = true)]
        public static extern VulkanResult CreateInstance(
            [In] VulkanInstanceCreateInfo pCreateInfo,
            [In] VulkanAllocationCallbacks pAllocator,
            [In, Out] ref IntPtr pInstance
        );

        [DllImport(DllName, CharSet = CharSet.Ansi, EntryPoint = "vkDestroyInstance", ExactSpelling = true)]
        public static extern VulkanResult DestroyInstance(
            [In] IntPtr instance,
            [In] VulkanAllocationCallbacks pAllocator
        );

        [DllImport(DllName, CharSet = CharSet.Ansi, EntryPoint = "vkEnumeratePhysicalDevices", ExactSpelling = true)]
        public static extern VulkanResult EnumeratePhysicalDevices(
            [In] IntPtr instance,
            [In, Out] ref uint pPhysicalDeviceCount,
            [In, Out] IntPtr[] pPhysicalDevices
        );

        [DllImport(DllName, CharSet = CharSet.Ansi, EntryPoint = "vkGetPhysicalDeviceQueueFamilyProperties", ExactSpelling = true)]
        public static extern void GetPhysicalDeviceQueueFamilyProperties(
            [In] IntPtr physicalDevice,
            [In, Out] ref uint pQueueFamilyPropertyCount,
            [In, Out] VulkanQueueFamilyProperties[] pQueueFamilyProperties
        );
    }

    internal static class VulkanUtils
    {
        public static uint CreateVersion(uint major, uint minor, uint patch)
        {
            return major << 22 | minor << 12 | patch;
        }
    }

    internal enum VulkanResult
    {
        Success = 0,
        NotReady = 1,
        Timeout = 2,
        EventSet = 3,
        EventReset = 4,
        Incomplete = 5,
        
        ErrorOutOfHostMemory = -1,
        ErrorOutOfDeviceMemory = -2,
        ErrorInitializationFailed = -3,
        ErrorDeviceLost = -4,
        ErrorMemoryMapFailed = -5,
        ErrorLayerNotPresent = -6,
        ErrorExtensionNotPresent = -7,
        ErrorFeatureNotPresent = -8,
        ErrorIncompatibleDriver = -9,
        ErrorTooManyObjects = -10,
        ErrorFormatNotSupported = -11,
        ErrorFragmentedPool = -12,
        ErrorUnknown = -13,
        ErrorOutOfPoolMemory = -1000069000,
        ErrorInvalidExternalHandle = -1000072003,
        ErrorFragmentation = -1000161000,
        ErrorInvalidOpaqueCaptureAddress = -1000257000,
    }

    internal enum VulkanStructureType
    {
        ApplicationInfo = 0,
        InstanceCreateInfo = 1,
        VK_STRUCTURE_TYPE_DEVICE_QUEUE_CREATE_INFO = 2,
        VK_STRUCTURE_TYPE_DEVICE_CREATE_INFO = 3,
        VK_STRUCTURE_TYPE_SUBMIT_INFO = 4,
        VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_INFO = 5,
        VK_STRUCTURE_TYPE_MAPPED_MEMORY_RANGE = 6,
        VK_STRUCTURE_TYPE_BIND_SPARSE_INFO = 7,
        VK_STRUCTURE_TYPE_FENCE_CREATE_INFO = 8,
        VK_STRUCTURE_TYPE_SEMAPHORE_CREATE_INFO = 9,
        VK_STRUCTURE_TYPE_EVENT_CREATE_INFO = 10,
        VK_STRUCTURE_TYPE_QUERY_POOL_CREATE_INFO = 11,
        VK_STRUCTURE_TYPE_BUFFER_CREATE_INFO = 12,
        VK_STRUCTURE_TYPE_BUFFER_VIEW_CREATE_INFO = 13,
        VK_STRUCTURE_TYPE_IMAGE_CREATE_INFO = 14,
        VK_STRUCTURE_TYPE_IMAGE_VIEW_CREATE_INFO = 15,
        VK_STRUCTURE_TYPE_SHADER_MODULE_CREATE_INFO = 16,
        VK_STRUCTURE_TYPE_PIPELINE_CACHE_CREATE_INFO = 17,
        VK_STRUCTURE_TYPE_PIPELINE_SHADER_STAGE_CREATE_INFO = 18,
        VK_STRUCTURE_TYPE_PIPELINE_VERTEX_INPUT_STATE_CREATE_INFO = 19,
        VK_STRUCTURE_TYPE_PIPELINE_INPUT_ASSEMBLY_STATE_CREATE_INFO = 20,
        VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_STATE_CREATE_INFO = 21,
        VK_STRUCTURE_TYPE_PIPELINE_VIEWPORT_STATE_CREATE_INFO = 22,
        VK_STRUCTURE_TYPE_PIPELINE_RASTERIZATION_STATE_CREATE_INFO = 23,
        VK_STRUCTURE_TYPE_PIPELINE_MULTISAMPLE_STATE_CREATE_INFO = 24,
        VK_STRUCTURE_TYPE_PIPELINE_DEPTH_STENCIL_STATE_CREATE_INFO = 25,
        VK_STRUCTURE_TYPE_PIPELINE_COLOR_BLEND_STATE_CREATE_INFO = 26,
        VK_STRUCTURE_TYPE_PIPELINE_DYNAMIC_STATE_CREATE_INFO = 27,
        VK_STRUCTURE_TYPE_GRAPHICS_PIPELINE_CREATE_INFO = 28,
        VK_STRUCTURE_TYPE_COMPUTE_PIPELINE_CREATE_INFO = 29,
        VK_STRUCTURE_TYPE_PIPELINE_LAYOUT_CREATE_INFO = 30,
        VK_STRUCTURE_TYPE_SAMPLER_CREATE_INFO = 31,
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_CREATE_INFO = 32,
        VK_STRUCTURE_TYPE_DESCRIPTOR_POOL_CREATE_INFO = 33,
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_ALLOCATE_INFO = 34,
        VK_STRUCTURE_TYPE_WRITE_DESCRIPTOR_SET = 35,
        VK_STRUCTURE_TYPE_COPY_DESCRIPTOR_SET = 36,
        VK_STRUCTURE_TYPE_FRAMEBUFFER_CREATE_INFO = 37,
        VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO = 38,
        VK_STRUCTURE_TYPE_COMMAND_POOL_CREATE_INFO = 39,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_ALLOCATE_INFO = 40,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_INHERITANCE_INFO = 41,
        VK_STRUCTURE_TYPE_COMMAND_BUFFER_BEGIN_INFO = 42,
        VK_STRUCTURE_TYPE_RENDER_PASS_BEGIN_INFO = 43,
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_BARRIER = 44,
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_BARRIER = 45,
        VK_STRUCTURE_TYPE_MEMORY_BARRIER = 46,
        VK_STRUCTURE_TYPE_LOADER_INSTANCE_CREATE_INFO = 47,
        VK_STRUCTURE_TYPE_LOADER_DEVICE_CREATE_INFO = 48,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SUBGROUP_PROPERTIES = 1000094000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_INFO = 1000157000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_INFO = 1000157001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_16BIT_STORAGE_FEATURES = 1000083000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_REQUIREMENTS = 1000127000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_DEDICATED_ALLOCATE_INFO = 1000127001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_ALLOCATE_FLAGS_INFO = 1000060000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_RENDER_PASS_BEGIN_INFO = 1000060003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_COMMAND_BUFFER_BEGIN_INFO = 1000060004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_SUBMIT_INFO = 1000060005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_BIND_SPARSE_INFO = 1000060006,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_BUFFER_MEMORY_DEVICE_GROUP_INFO = 1000060013,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_MEMORY_DEVICE_GROUP_INFO = 1000060014,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_GROUP_PROPERTIES = 1000070000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_GROUP_DEVICE_CREATE_INFO = 1000070001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BUFFER_MEMORY_REQUIREMENTS_INFO_2 = 1000146000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_MEMORY_REQUIREMENTS_INFO_2 = 1000146001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_SPARSE_MEMORY_REQUIREMENTS_INFO_2 = 1000146002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_MEMORY_REQUIREMENTS_2 = 1000146003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_MEMORY_REQUIREMENTS_2 = 1000146004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FEATURES_2 = 1000059000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROPERTIES_2 = 1000059001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_FORMAT_PROPERTIES_2 = 1000059002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_PROPERTIES_2 = 1000059003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGE_FORMAT_INFO_2 = 1000059004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_QUEUE_FAMILY_PROPERTIES_2 = 1000059005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MEMORY_PROPERTIES_2 = 1000059006,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SPARSE_IMAGE_FORMAT_PROPERTIES_2 = 1000059007,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SPARSE_IMAGE_FORMAT_INFO_2 = 1000059008,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_POINT_CLIPPING_PROPERTIES = 1000117000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_RENDER_PASS_INPUT_ATTACHMENT_ASPECT_CREATE_INFO = 1000117001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_VIEW_USAGE_CREATE_INFO = 1000117002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PIPELINE_TESSELLATION_DOMAIN_ORIGIN_STATE_CREATE_INFO = 1000117003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_RENDER_PASS_MULTIVIEW_CREATE_INFO = 1000053000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_FEATURES = 1000053001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MULTIVIEW_PROPERTIES = 1000053002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES = 1000120000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PROTECTED_SUBMIT_INFO = 1000145000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_FEATURES = 1000145001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_PROTECTED_MEMORY_PROPERTIES = 1000145002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DEVICE_QUEUE_INFO_2 = 1000145003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_CREATE_INFO = 1000156000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_INFO = 1000156001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_BIND_IMAGE_PLANE_MEMORY_INFO = 1000156002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_IMAGE_PLANE_MEMORY_REQUIREMENTS_INFO = 1000156003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_YCBCR_CONVERSION_FEATURES = 1000156004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_SAMPLER_YCBCR_CONVERSION_IMAGE_FORMAT_PROPERTIES = 1000156005,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DESCRIPTOR_UPDATE_TEMPLATE_CREATE_INFO = 1000085000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_IMAGE_FORMAT_INFO = 1000071000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_IMAGE_FORMAT_PROPERTIES = 1000071001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_BUFFER_INFO = 1000071002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_BUFFER_PROPERTIES = 1000071003,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_ID_PROPERTIES = 1000071004,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_BUFFER_CREATE_INFO = 1000072000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_MEMORY_IMAGE_CREATE_INFO = 1000072001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_MEMORY_ALLOCATE_INFO = 1000072002,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_FENCE_INFO = 1000112000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_FENCE_PROPERTIES = 1000112001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_FENCE_CREATE_INFO = 1000113000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXPORT_SEMAPHORE_CREATE_INFO = 1000077000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_EXTERNAL_SEMAPHORE_INFO = 1000076000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_EXTERNAL_SEMAPHORE_PROPERTIES = 1000076001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_MAINTENANCE_3_PROPERTIES = 1000168000,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_SUPPORT = 1000168001,

        // Provided by VK_VERSION_1_1
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES = 1000063000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_FEATURES = 49,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_1_PROPERTIES = 50,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_FEATURES = 51,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_1_2_PROPERTIES = 52,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_IMAGE_FORMAT_LIST_CREATE_INFO = 1000147000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_2 = 1000109000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_2 = 1000109001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_2 = 1000109002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DEPENDENCY_2 = 1000109003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_RENDER_PASS_CREATE_INFO_2 = 1000109004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_BEGIN_INFO = 1000109005,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_END_INFO = 1000109006,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_8BIT_STORAGE_FEATURES = 1000177000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DRIVER_PROPERTIES = 1000196000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_ATOMIC_INT64_FEATURES = 1000180000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_FLOAT16_INT8_FEATURES = 1000082000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_FLOAT_CONTROLS_PROPERTIES = 1000197000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_LAYOUT_BINDING_FLAGS_CREATE_INFO = 1000161000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_FEATURES = 1000161001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DESCRIPTOR_INDEXING_PROPERTIES = 1000161002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_ALLOCATE_INFO = 1000161003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DESCRIPTOR_SET_VARIABLE_DESCRIPTOR_COUNT_LAYOUT_SUPPORT = 1000161004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_DEPTH_STENCIL_RESOLVE_PROPERTIES = 1000199000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SUBPASS_DESCRIPTION_DEPTH_STENCIL_RESOLVE = 1000199001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SCALAR_BLOCK_LAYOUT_FEATURES = 1000221000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_IMAGE_STENCIL_USAGE_CREATE_INFO = 1000246000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SAMPLER_FILTER_MINMAX_PROPERTIES = 1000130000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SAMPLER_REDUCTION_MODE_CREATE_INFO = 1000130001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VULKAN_MEMORY_MODEL_FEATURES = 1000211000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_IMAGELESS_FRAMEBUFFER_FEATURES = 1000108000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENTS_CREATE_INFO = 1000108001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_FRAMEBUFFER_ATTACHMENT_IMAGE_INFO = 1000108002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_RENDER_PASS_ATTACHMENT_BEGIN_INFO = 1000108003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_UNIFORM_BUFFER_STANDARD_LAYOUT_FEATURES = 1000253000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_SUBGROUP_EXTENDED_TYPES_FEATURES = 1000175000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SEPARATE_DEPTH_STENCIL_LAYOUTS_FEATURES = 1000241000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_REFERENCE_STENCIL_LAYOUT = 1000241001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_ATTACHMENT_DESCRIPTION_STENCIL_LAYOUT = 1000241002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_HOST_QUERY_RESET_FEATURES = 1000261000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_FEATURES = 1000207000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_TIMELINE_SEMAPHORE_PROPERTIES = 1000207001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_TYPE_CREATE_INFO = 1000207002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_TIMELINE_SEMAPHORE_SUBMIT_INFO = 1000207003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_WAIT_INFO = 1000207004,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_SEMAPHORE_SIGNAL_INFO = 1000207005,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_BUFFER_DEVICE_ADDRESS_FEATURES = 1000257000,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_BUFFER_DEVICE_ADDRESS_INFO = 1000244001,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_BUFFER_OPAQUE_CAPTURE_ADDRESS_CREATE_INFO = 1000257002,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_MEMORY_OPAQUE_CAPTURE_ADDRESS_ALLOCATE_INFO = 1000257003,

        // Provided by VK_VERSION_1_2
        VK_STRUCTURE_TYPE_DEVICE_MEMORY_OPAQUE_CAPTURE_ADDRESS_INFO = 1000257004,
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTER_FEATURES = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_VARIABLE_POINTERS_FEATURES,
        VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETER_FEATURES = VK_STRUCTURE_TYPE_PHYSICAL_DEVICE_SHADER_DRAW_PARAMETERS_FEATURES,
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal sealed class VulkanApplicationInfo
    {
        [MarshalAs(UnmanagedType.I4)]
        public VulkanStructureType sType;
        public IntPtr pNext;
        public string pApplicationName;
        public uint applicationVersion;
        public string pEngineName;
        public uint engineVersion;
        public uint apiVersion;
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal sealed class VulkanInstanceCreateInfo
    {
        [MarshalAs(UnmanagedType.I4)]
        public VulkanStructureType sType;
        public IntPtr pNext;
        public int flags; // not used
        public VulkanApplicationInfo pApplicationInfo;
        public int enabledLayerCount;
        public string[] ppEnabledLayerNames;
        public int enabledExtensionCount;
        public string[] ppEnabledExtensionNames;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal sealed class VulkanAllocationCallbacks
    {
        // TODO
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct VulkanExtend3D
    {
        public uint Width { get; set; }
        public uint Height { get; set; }
        public uint Depth { get; set; }
    }

    [Flags]
    internal enum VulkanQueueFlagBits : uint
    {
        None = 0x00,
        GraphicsBit = 0x01,
        ComputeBit = 0x02,
        TransferBit = 0x04,
        SparseBindingBit = 0x08,
        ProtectedBit = 0x10
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct VulkanQueueFamilyProperties
    {
        public VulkanQueueFlagBits queueFlags;
        public uint queueCount;
        public uint timestampValidBits;
        public VulkanExtend3D minImageTransferGranularity;
    }

    internal enum VulkanDeviceQueueCreateFlagBits : uint
    {
        None = 0x00,
        ProtectedBit = 0x01
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct VulkanDeviceQueueCreateInfo
    {
        public VulkanStructureType sType;
        public IntPtr pNext;
        public VulkanDeviceQueueCreateFlagBits flags;
        public uint queueFamilyIndex;
        public uint queueCount;
        public float[] pQueuePriorities;
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    internal struct VulkanDeviceCreateInfo
    {
        public VulkanStructureType sType;
        public IntPtr pNext;
        public uint flags;
        public uint queueCreateInfoCount;
        public VulkanDeviceQueueCreateInfo[] pQueueCreateInfos;
        public uint enabledLayerCount;
        public string[] ppEnabledLayerNames;
        uint32_t                           enabledExtensionCount;
        const char* const*                 ppEnabledExtensionNames;
        const VkPhysicalDeviceFeatures*    pEnabledFeatures;
    }
}