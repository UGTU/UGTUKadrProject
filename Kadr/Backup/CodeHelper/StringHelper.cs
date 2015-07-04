using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace APG.CodeHelper
{
    /// <summary>
    /// Вспомогательный класс работы со строками
    /// </summary>
    public class StringHelper
    {
        /// <summary>
        /// Форматирует имя человека
        /// </summary>
        /// <param name="humanName">Имя</param>
        /// <returns>Форматированное имя</returns>
        public static string CorrectHumanName(string humanName)
        {
            string result = "";

            if (humanName != "")
            {
                result += char.ToUpper(humanName[0]);

                for (int i = 1; i < humanName.Length; i++)
                {
                    result += char.ToLower(humanName[i]);
                }
            }
            if (result.Trim()=="") throw new ApplicationException();
            else return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="incorrectString"></param>
        /// <returns></returns>
        public static string CorrectCase(string incorrectString)
        {
            string result = "";

            if (incorrectString != "")
            {
                result += char.ToUpper(incorrectString[0]);

                for (int i = 1; i < incorrectString.Length; i++)
                {
                    result += incorrectString[i];
                }
            }
            return result;
        }

        /// <summary>
        /// Убирает недопустимые символы пути в строке, заменяя их на заданный
        /// </summary>
        /// <param name="incorrectFileName"></param>
        /// <returns></returns>
        public static string CorrectFileName(string incorrectFileName, string substStr)
        {
            
            const string pattern = "\\\x2F|\\\x3C|\\\x3E|\\\\|\\\x3F|\\\x3A|\\\x2A|\\\"|\\\x7C";
            return Regex.Replace(incorrectFileName, pattern, substStr);            
        }

        /// <summary>
        /// Функция убирает из строки встречающиеся чаще одного раза знаки "\" 
        /// и добавляет в конец строки "\", если он там отсутствует. Исключение составляет путь в формате 
        /// UNC (строка начинается с "\\")
        /// </summary>
        /// <param name="incorrectPath">Путь</param>
        /// <returns></returns>
        public static string CorrectPath(string incorrectPath)
        {
            string pattern = "\\\\{2,}|(?<tail>[^\\\\]$)";

            Uri uri = new Uri(incorrectPath);
            
            if (uri.IsUnc) 
                pattern = "(?<tail>[^\\\\]$)";    
            
            return Regex.Replace(incorrectPath, pattern, "${tail}\\");   
            
        }
    }
}
