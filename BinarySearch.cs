        public class Search
        {
            /// <summary>
            /// 二分查找/折半查找（分治思想、递归，目标数组必须是有序序列），算法复杂度为o（log（n）,n代表目标数组长度）
            /// </summary>
            /// <param name="sources">目标数组, 已经排好序</param>
            /// <param name="findValue">目标查找数</param>
            /// <param name="low">区间最小索引</param>
            /// <param name="high">区间最大索引</param>
            /// <returns>true:存在，false,不存在</returns>
            public static int BinarySearch_with_Recursion(int[] sources, int findValue, int low, int high)
            {
                // 未找到，终止递归
                if (low > high) return -1;

                // 折半查找中间值 索引:(a + b) / 2表示算数平均数，即中点
                // int middleIndex = (low + high) / 2 , low + high 可能超出 int.Maxvalue 范围， 改用下面一行代码，
                int middleIndex = (low + high) >> 1;//int middleIndex = low + (high-low)/2;

                if (findValue > sources[middleIndex])
                {
                    // 大于中间值，在区间[middleIndex + 1, high]递归继续查找
                    return BinarySearch_with_Recursion(sources, findValue, middleIndex + 1, high);
                }
                if (findValue < sources[middleIndex])
                {
                    // 小于中间值，在区间[low, middleIndex - 1]递归继续查找
                    return BinarySearch_with_Recursion(sources, findValue, low, middleIndex - 1);
                }

                // findValue 等于 sources[middleIndex],找到，终止递归
                return middleIndex;
            }



            /// <summary>
            /// 二分查找,非递归
            /// </summary>
            /// <param name="sources"></param>
            /// <param name="findValue"></param>
            /// <returns></returns>
            public static int BinarySearch_without_Recursion(int[] sources, int findValue)
            {
                int low = 0;
                int high = sources.Length - 1;
                int mid = low;

                while (low <= high)
                {
                    mid = (low + high) >> 1;//mid = low + (high - low) / 2;             
                    if (sources[mid] == findValue) return mid;
                    else if (sources[mid] > findValue) high = mid - 1;
                    else low = mid + 1;
                }

                return -1;
            }
        }