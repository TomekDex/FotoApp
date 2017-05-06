using Microsoft.Win32;
using System;
using System.Collections.Generic;

namespace FotoApp.Pref.Helpers
{
    public class KeySettings
    {
        private string key = @"SYSTEM\CurrentControlSet\Control\Keyboard Layout";
        private RegistryKey rk;
        private byte sumKey = 0;
        private List<byte[]> listSetings = new List<byte[]>();
        public static byte[] _null { get; private set; } = new byte[] { 0x00, 0x00 };
        public static byte[] _f12 { get; private set; } = new byte[] { 0x58, 0x00 };
        public static byte[] _lCtr { get; private set; } = new byte[] { 0x1D, 0x00 };
        public static byte[] _lAlt { get; private set; } = new byte[] { 0x38, 0x00 };
        public static byte[] _rAlt { get; private set; } = new byte[] { 0x38, 0xE0 };
        public static byte[] _rCtr { get; private set; } = new byte[] { 0x1D, 0xE0 };
        public static byte[] _lWin { get; private set; } = new byte[] { 0x5B, 0xE0 };
        public static byte[] _rWin { get; private set; } = new byte[] { 0x5C, 0xE0 };
        public static byte[] _app { get; private set; } = new byte[] { 0x5D, 0xE0 };
        public static byte[] _power { get; private set; } = new byte[] { 0x5E, 0xE0 };
        public static byte[] _sleep { get; private set; } = new byte[] { 0x5F, 0xE0 };

        public void Delete()
        {
            rk = Registry.LocalMachine.OpenSubKey(key, true);
            rk.DeleteValue("Scancode Map"); //can throw ArgumentException when key doesn't exist
        }

        public void Set()
        {
            int countByte = 16 + 4 * sumKey;
            byte[] value = new byte[countByte];
            for (int i = 0; i < countByte; i++) value[i] = 0x00;
            value[8] = (byte)(sumKey + 1);
            int j = 0;
            foreach (byte[] b in listSetings)
            {
                value[12 + 4 * j] = b[0];
                value[13 + 4 * j] = b[1];
                value[14 + 4 * j] = b[2];
                value[15 + 4 * j] = b[3];
                j++;
            }
            rk = Registry.LocalMachine.CreateSubKey(key);
            rk.SetValue("Scancode Map", value);
        }

        public void Add(byte[] from, byte[] to)
        {
            sumKey++;
            listSetings.Add(new byte[] { to[0], to[1], from[0], from[1] });
        }

        public void BlockAll()
        {
            Add(_lAlt, _f12);
            Add(_rAlt, _f12);
            Add(_lCtr, _f12);
            Add(_rCtr, _f12);
            Add(_lWin, _f12);
            Add(_rWin, _f12);
            Add(_app, _f12);
            Add(_power, _f12);
            Add(_sleep, _f12);
            Set();
        }
    }
}
