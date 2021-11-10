using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demographic.FileOperations
{
    interface IDeathRulesFileParser
    {
        void ReadFile(string path);
        List<ArrayList> Matrix { get; }
    }
}
