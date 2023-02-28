﻿using System;
using System.Linq;
using System.Text;

namespace ExtensionBlocks
{
    public class Beef0024 : BeefBase
    {
        public Beef0024(byte[] rawBytes)
            : base(rawBytes)
        {
            if (Signature != 0xbeef0024)
            {
                throw new Exception($"Signature mismatch! Should be 0xbeef0024 but is 0x{Signature:X}");
            }

            var propStore = new PropertyStore(rawBytes.Skip(8).ToArray());


            PropertyStore = propStore;


            VersionOffset = BitConverter.ToInt16(rawBytes, rawBytes.Length - 2);
        }

        public PropertyStore PropertyStore { get; }


        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());

            var sheetNumber = 0;

            foreach (var propertySheet in PropertyStore.Sheets)
            {
                sb.AppendLine($"Sheet #{sheetNumber} => {propertySheet}");

                sheetNumber += 1;
            }


            return sb.ToString();
        }
    }
}