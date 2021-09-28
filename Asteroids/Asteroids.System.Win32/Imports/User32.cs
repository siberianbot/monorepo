using System;
using System.Runtime.InteropServices;

namespace Asteroids.System.Win32.Imports
{
    /// <summary>user32.dll imports</summary>
    internal static class User32
    {
        private const string DllName = "user32.dll";
        private const string DefWindowProcName = "DefWindowProcW";
        private const string RegisterClassExName = "RegisterClassExW";
        private const string CreateWindowExName = "CreateWindowExW";
        private const string DestroyWindowName = "DestroyWindow";
        private const string PeekMessageName = "PeekMessageW";
        private const string TranslateMessageName = "TranslateMessage";
        private const string DispatchMessageName = "DispatchMessageW";

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = DefWindowProcName, ExactSpelling = true)]
        public static extern IntPtr DefWindowProc(
            [In] IntPtr hWnd,
            [In, MarshalAs(UnmanagedType.U4)] WindowMessage uMsg,
            [In] UIntPtr wParam,
            [In] IntPtr lParam);

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = RegisterClassExName, ExactSpelling = true, SetLastError = true)]
        public static extern bool RegisterClassEx([In] ref WndClassEx wndClass);

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = CreateWindowExName, ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateWindowEx(
            [In, MarshalAs(UnmanagedType.U4)] ExtendedWindowStyle dwExStyle,
            [In] string lpClassName,
            [In] string lpWindowName,
            [In, MarshalAs(UnmanagedType.U4)] WindowStyle dwStyle,
            [In] int x,
            [In] int y,
            [In] int nWidth,
            [In] int nHeight,
            [In] IntPtr hWndParent,
            [In] IntPtr hMenu,
            [In] IntPtr hInstance,
            [In] IntPtr lpParam
        );
        
        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = DestroyWindowName, ExactSpelling = true)]
        public static extern bool DestroyWindow([In] IntPtr hWnd);

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = PeekMessageName, ExactSpelling = true)]
        public static extern bool PeekMessage(
            [In] ref Message lpMsg,
            [In] IntPtr hWnd,
            [In] uint wMsgFilterMin,
            [In] uint wMsgFilterMax,
            [In, MarshalAs(UnmanagedType.U4)] PeekMessageRemove wRemoveMsg);

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = DispatchMessageName, ExactSpelling = true)]
        public static extern IntPtr DispatchMessage([In] ref Message lpMsg);

        [DllImport(DllName, CharSet = CharSet.Unicode, EntryPoint = TranslateMessageName, ExactSpelling = true)]
        public static extern bool TranslateMessage([In] ref Message lpMsg);
    }

    internal delegate IntPtr WndProcDelegate(IntPtr hWnd, [MarshalAs(UnmanagedType.U4)] WindowMessage uMsg, UIntPtr wParam, IntPtr lParam);
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct WndClassEx
    {
        [MarshalAs(UnmanagedType.U4)]
        public int cbSize;
        [MarshalAs(UnmanagedType.U4)]
        public ClassStyle style;
        public WndProcDelegate lpfnWndProc;
        public int cbClsExtra;
        public int cbWndExtra;
        public IntPtr hInstance;
        public IntPtr hIcon;
        public IntPtr hCursor;
        public IntPtr hbrBackground;
        public string lpszMenuName;
        public string lpszClassName;
        public IntPtr hIconSm;
    }

    [Flags]
    internal enum ClassStyle : uint
    {
        None = 0,
        
        VerticalRedraw = 0x0001,
        HorizontalRedraw = 0x0002,
        
        ByteAlignClient = 0x1000,
        ByteAlignWindow = 0x2000,
        
        OwnDC = 0x0020,
        ClassDC = 0x0040,
        ParentDC = 0x0080,
        
        DoubleClicks = 0x0008,
        NoClose = 0x0200,
        SaveBits = 0x0800,
        GlobalClass = 0x4000,
        DropShadow = 0x00020000,
    }

    [Flags]
    internal enum WindowStyle : uint
    {
        None = 0,
        
        Border = 0x00800000,
        Caption = 0x00C00000,
        Child = 0x40000000,
        ChildWindow = 0x40000000,
        ClipChildren = 0x02000000,
        ClipSiblings = 0x04000000,
        Disabled = 0x08000000,
        DialogFrame = 0x00400000,
        Group = 0x00020000,
        HorizontalScroll = 0x00100000,
        VerticalScroll = 0x00200000,
        Visible = 0x10000000,
        Tiled = 0x00000000,
        ThickFrame = 0x00040000,
        TabStop = 0x00010000,
        SysMenu = 0x00080000,
        SizeBox = 0x00040000,
        Popup = 0x80000000,
        Iconic = 0x20000000,
        Maximize = 0x01000000,
        MaximizeBox = 0x00010000,
        Minimize = 0x20000000,
        MinimizeBox = 0x00020000,
        Overlapped = 0x00000000,
        
        OverlappedWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox,
        PopupWindow = Popup | Border | SysMenu,
        TiledWindow = Overlapped | Caption | SysMenu | ThickFrame | MinimizeBox | MaximizeBox
    }
    
    [Flags]
    internal enum ExtendedWindowStyle : uint
    {
        None = 0,

        Left = 0x00000000,
        Right = 0x00001000,

        RightScrollbar = 0x00000000,
        LeftScrollbar = 0x00004000,

        LtrReading = 0x00000000,
        RtlReading = 0x00002000,

        WindowEdge = 0x00000100,
        ClientEdge = 0x00000200,
        StaticEdge = 0x00020000,

        DialogModalFrame = 0x00000001,
        AppWindow = 0x00040000,
        ToolWindow = 0x00000080,
        
        AcceptFiles = 0x00000010,
        Composited = 0x02000000,
        ContextHelp = 0x00000400,
        ControlParent = 0x00010000,
        Layered = 0x00080000,
        LayoutRtl = 0x00400000,
        MdiChild = 0x00000040,
        NoActivate = 0x08000000,
        NoInheritLayout = 0x00100000,
        NoParentNotify = 0x00000004,
        NoRedirectionBitmap = 0x00200000,
        TopMost = 0x00000008,
        Transparent = 0x00000020,
        
        OverlappedWindow = WindowEdge | ClientEdge,
        PaletteWindow = WindowEdge | ToolWindow | TopMost
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct Point
    {
        public long x;
        public long y;
    }
    
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    internal struct Message
    {
        public IntPtr hWnd;
        public uint message;
        public UIntPtr wParam;
        public IntPtr lParam;
        public uint time;
        public Point pt;
        public uint lPrivate;
    }
    
    [Flags]
    internal enum PeekMessageRemove : uint
    {
        NoRemove = 0x0000,
        Remove = 0x0001,
        NoYield = 0x0002
    }

    internal enum WindowMessage : uint
    {
        Destroy = 0x0002,
        Close = 0x0010,
    }
}