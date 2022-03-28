using com.mobiquity.packer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace com.mobiquity.packer
{
    public class Presenter : IPresenter
    {
        public string Present(List<int> resultIndexes)
        {
            if(resultIndexes == null || resultIndexes.Count == 0)
            {
                return "-\n";
            }

            return String.Join(',', resultIndexes.OrderBy(x => x).ToArray()) + '\n';
        }
    }
}
