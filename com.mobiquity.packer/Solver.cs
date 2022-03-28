using com.mobiquity.packer.Dto;
using com.mobiquity.packer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.mobiquity.packer
{
    public class Solver : ISolver
    {
        private readonly IPresenter _presenter;
        // The multiplicator is used to hadle the situation when weight is double and has 2 digits after point.
        // TODO: define the multiplicator by calculationg the max number of digits after point in weight.
        private const int MULTIPLICATOR = 100;

        public Solver(IPresenter presenter)
        {
            _presenter = presenter;
        }

        public string Solve(List<PackageData> data)
        {
            StringBuilder answer = new StringBuilder();

            foreach (PackageData dataItem in data)
            {
                var orderedList = dataItem.Items.OrderBy(x => x.Weight).ToList();
                int[] weights = orderedList.Select(x => (int)(x.Weight * MULTIPLICATOR)).ToArray();               
                int[] costs = orderedList.Select(x => x.Cost).ToArray();
                int S = dataItem.MaxWeight * MULTIPLICATOR;
                int count = weights.Length;
                int[,] F = new int[count + 1, S + 1];

                for (int i = 0; i <= count; ++i)
                {
                    for (int j = 0; j <= S; ++j)
                    {
                        if (i == 0 || j == 0)
                        {
                            F[i, j] = 0;
                        }
                        else
                        {
                            if (weights[i - 1] > j)
                            {
                                F[i, j] = F[i - 1, j];
                            }
                            else
                            {
                                F[i, j] = Math.Max(F[i - 1, j], costs[i - 1] + F[i - 1, j - weights[i - 1]]);
                            }
                        }
                    }
                }

                var resultIndexes = new List<int>();
                CollectResult(count, S, F, weights, orderedList, resultIndexes);
                answer.Append(_presenter.Present(resultIndexes));
            }

            return answer.ToString();
        }

        private void CollectResult(int s, int n, int[,] F, int[] w, List<Item> list, List<int> resultIndexes)
        {
            if (F[s, n] == 0) 
                return;
            else if (F[s - 1, n] == F[s, n])
                CollectResult(s - 1, n, F, w, list, resultIndexes);
            else
            {
                CollectResult(s - 1, n - w[s - 1], F, w, list, resultIndexes);
                resultIndexes.Add(list[s - 1].Index);
            }
        }
    }
}
