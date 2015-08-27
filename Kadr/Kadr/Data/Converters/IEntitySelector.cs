using System;

namespace Kadr.Data.Converters
{
    internal interface IEntitySelector
    {
        bool InculdeToOutput { get; }         
    }
}