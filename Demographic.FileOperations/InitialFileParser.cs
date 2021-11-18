using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace Demographic.FileOperations
{
    public class InitialFileParser : IFileParser
    {
        private const int _maxSizeBytes = 2 * 1024 * 1024;
        private string[][] _stringMatrix;
        private int _numInRow = 2;
        private List<ArrayList> _convertedMatrix = new List<ArrayList>();
        private void DefineData()
        {
            if (_stringMatrix.Length <= 1)
                throw new FileLoadException("Файл не содержит данных");
            for (int i = 0; i < _stringMatrix.Length; i++)
            {
                ArrayList tempList = new ArrayList();
                if (_stringMatrix[i].Length != _numInRow)
                {
                    throw new FileLoadException("Некорректный формат файла");
                }
                if (int.TryParse(_stringMatrix[i][0], out int n)
                    && double.TryParse(_stringMatrix[i][1], out double d) && i != 0)
                {
                    tempList.Add(Convert.ToInt32(_stringMatrix[i][0]));
                    tempList.Add(Convert.ToDouble(_stringMatrix[i][1]));
                    _convertedMatrix.Add(tempList);
                }
                else if (i != 0)
                {
                    throw new FileLoadException("Некорректные данные в файле");
                }
                
            }
        }
        public List<ArrayList> Matrix 
        { 
            get
            {
                return _convertedMatrix;
            }
        }

        public void ReadFile(string path)
        {
            if (Path.GetExtension(path) != ".csv")
            {
                throw new FileLoadException("Неверное расширение файла");
            }
            if (path == null)
                throw new FileNotFoundException();
            long sizeBytes = new FileInfo(path).Length;
            Console.WriteLine("file size " + sizeBytes);
            if (sizeBytes > _maxSizeBytes)
                throw new FileLoadException("Превышен размер файла");

            string[] _stringsArray = File.ReadAllLines(path);
            _stringMatrix = _stringsArray.Select(x => x.Split(',')).ToArray();
            DefineData();
        }
        public void ClearData()
        {
            _convertedMatrix.Clear();
        }
    }
}
