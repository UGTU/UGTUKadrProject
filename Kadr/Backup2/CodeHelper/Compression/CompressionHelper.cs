using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper
{
    public class CompressionHelper
    {
        /// <summary>
        /// Компрессия или декомпрессия файла
        /// </summary>
        /// <param name="fromFile">Исходный файл для компрессии или декомпрессии</param>
        /// <param name="toFile">Целевой файл</param>
        /// <param name="compressionMode">Указывает на компрессию или декомпрессию</param>
        private static void CompressOrDecompressFile(string fromFile, string toFile, System.IO.Compression.CompressionMode compressionMode)
        {
            System.IO.FileStream toFs = null;
            System.IO.Compression.GZipStream gzStream = null;
            System.IO.FileStream fromFs = new System.IO.FileStream(fromFile, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            
            try
            {
                toFs = new System.IO.FileStream(toFile, System.IO.FileMode.Create, System.IO.FileAccess.Write);
                gzStream = new System.IO.Compression.GZipStream(toFs, compressionMode);
                byte[] buf = new byte[fromFs.Length];
                fromFs.Read(buf, 0, buf.Length);
                gzStream.Write(buf, 0, buf.Length);
            }
            finally
            {
                if (gzStream != null) 
                    gzStream.Close();
                
                if (toFs != null)
                    toFs.Close();

                fromFs.Close();
            }
        }

        /// <summary>
        /// Декомпрессия файла
        /// </summary>
        /// <param name="compressFileName">Исходный файл</param>
        /// <param name="fileName">Целевой файл</param>
        public static void DecompressFile(string compressFileName, string fileName)
        {
            CompressOrDecompressFile(compressFileName, fileName, System.IO.Compression.CompressionMode.Decompress);
        }

        /// <summary>
        /// Компрессия файла
        /// </summary>
        /// <param name="fileName">Исходный файл</param>
        /// <param name="compressFileName">Целевой файл</param>
        public static void CompressFile(string fileName, string compressFileName)
        {
            CompressOrDecompressFile(fileName, compressFileName, System.IO.Compression.CompressionMode.Compress);
        }

    }
}
