using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAssistent_v1
{
    class Open
    {
        public Open()
        {

        }

        public void Run(string name)
        {
            string keyBase = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";
            string keyBase2 = @"SOFTWARE\WOW6432Node\Microsoft\Windows\CurrentVersion\App Paths";
            string keybase3 = @"Applications";
            RegistryKey localMachine = Registry.LocalMachine;
            RegistryKey curUser = Registry.CurrentUser;
            RegistryKey rootclasses = Registry.ClassesRoot;
            RegistryKey keys = localMachine.OpenSubKey(keyBase);
            RegistryKey keys2 = curUser.OpenSubKey(keyBase);
            RegistryKey keys3 = localMachine.OpenSubKey(keyBase2);
            RegistryKey keys4 = rootclasses.OpenSubKey(keybase3);
            foreach (var v in keys.GetSubKeyNames())
            {
                if (v.Contains(name))
                {
                    Console.WriteLine(v);
                }
            }
            foreach (var v in keys2.GetSubKeyNames())
            {
                if (v.Contains(name))
                {
                    Console.WriteLine(v);
                }
            }
            foreach (var v in keys3.GetSubKeyNames())
            {
                if (v.Contains(name))
                {
                    Console.WriteLine(v);
                }
            }
            foreach (var v in keys4.GetSubKeyNames())
            {
                if (v.Contains(name))
                {
                    Console.WriteLine(v);
                }
            }
        }
    }
}
