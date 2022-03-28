using System;
using System.Collections.Generic;
using System.Text;

namespace com.mobiquity.packer.Interfaces
{
    /// <summary>
    /// Present result of the task as a string
    /// </summary>
    public interface IPresenter
    {
        string Present(List<int> resultIndexes);
    }
}
