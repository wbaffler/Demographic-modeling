using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Demographic.FileOperations
{
    interface IInitialAgeFileParser
    {
        void ReadFile(string path);
        List<ArrayList> Matrix { get;  }

    }
}
