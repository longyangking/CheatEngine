﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Diagnostics;
using System.Runtime.InteropServices;

namespace CheatEngine
{
    class MemoryManager
    {
        public static Process[] GetProcesses()
        {
            Process[] ps = Process.GetProcesses();
            return ps;
        }

        public const int PROCESS_QUERY_INFORMATION = 0x0400;
        public const int MEM_COMMIT = 0x00001000;
        public const int PAGE_READWRITE = 0x04;
        public const int PROCESS_WM_READ = 0x0010;

        [DllImport("kernel32.dll")]
        public static extern void GetSystemInfo(out SYSTEM_INFO lpSystemInfo);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int VirtualQueryEx
            (
                IntPtr hProcess,
                IntPtr lpAddress, 
                out MEMORY_BASIC_INFORMATION lpBuffer, 
                int dwLength
            );

        [DllImportAttribute("kernel32.dll", EntryPoint = "ReadProcessMemory")]
        public static extern bool ReadProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                IntPtr lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesRead
            );

        [DllImportAttribute("kernel32.dll", EntryPoint = "OpenProcess")]
        public static extern IntPtr OpenProcess
            (
                int dwDesiredAccess,
                bool bInheritHandle,
                int dwProcessId
            );

        [DllImport("kernel32.dll")]
        private static extern void CloseHandle
            (
                IntPtr hObject
            );

        [DllImportAttribute("kernel32.dll", EntryPoint = "WriteProcessMemory")]
        public static extern bool WriteProcessMemory
            (
                IntPtr hProcess,
                IntPtr lpBaseAddress,
                int[] lpBuffer,
                int nSize,
                IntPtr lpNumberOfBytesWritten
            );

        [DllImport("kernel32")]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        public struct MEMORY_BASIC_INFORMATION
        {
            public int BaseAddress;
            public int AllocationBase;
            public int AllocationProtect;
            public int RegionSize;
            public int State;
            public int Protect;
            public int lType;
        }

        public struct SYSTEM_INFO
        {
            public ushort processorArchitecture;
            ushort reserved;
            public uint pageSize;
            public IntPtr minimumApplicationAddress;
            public IntPtr maximumApplicationAddress;
            public IntPtr activeProcessorMask;
            public uint numberOfProcessors;
            public uint processorType;
            public uint allocationGranularity;
            public ushort processorLevel;
            public ushort processorRevision;
        }

        public static int SizeOf(object obj)
        {
            return Marshal.SizeOf(obj);
        }

        public static IntPtr GetAddressOfArray(Array array)
        {
            return Marshal.UnsafeAddrOfPinnedArrayElement(array, 0);
        }

        public static int ReadBytes2Int(IntPtr byteaddr)
        {
            return Marshal.ReadInt32(byteaddr);
        }
    }
}
