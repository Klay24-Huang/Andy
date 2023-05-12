using System;
using System.Net.Http.Headers;
using System.Reflection.Emit;

namespace ClassLibrary1
{
    public class Class1
    {
        public bool Changeable(char[] products, Code[] codes)
        {
            // 確認商品跟所有條碼預計可兌換的總數是否相同
            var sum = codes.Sum(c => c.Amount);
            if (sum != products.Length)
                return false;
            // 紀錄每個條碼目前已被兌換的商品
            HashSet<char>[] codeRecorders = codes.Select(_ => new HashSet<char>()).ToArray();

            var index = 0;
            Backtracking(ref index, ref codeRecorders, products, codes);

            return index == products.Length;
        }

        private void Backtracking(ref int index, ref HashSet<char>[] codeRecorders, char[] products, Code[] codes)
        {
            if (index == products.Length)
            {
                // 所有商品與對應的條碼有解，後續不需要再驗
                return ;
            }
            var product = products[index];

            for (int i = 0; i < codes.Length; i++)
            {
                Code code = codes[i];
                HashSet<char> codeRecorder = codeRecorders[i];

                var exchangeable = IsExchangeable(ref codeRecorder, product, code);
                if (!exchangeable)
                    continue;

                index++;
                Backtracking(ref index, ref codeRecorders, products, codes);
                if (index == products.Length)
                {
                    // 所有商品與對應的條碼有解，後續不需要再驗
                    break;
                }
                // 清除這次商品的兌換資訊
                index--;
                codeRecorder.Remove(product);
            }
        }

        private static bool IsExchangeable(ref HashSet<char> codeRecorder, char product, Code code)
        {
            // 檢查此條碼是否已被兌換
            if (codeRecorder.Count == code.Amount)
            {
                return false;
            }

            // 這個條碼沒有包含這個商品
            if (!code.Products.Contains(product))
            {
                return false;
            }

            // 只能兌換一個商品的條碼 ，此條碼沒有被兌換過
            if (code.Amount == 1 && codeRecorder.Add(product))
            {
                return true;
            }

            // 是可換複數商品的條碼，未達到兌換數量的上限，且此商品還沒被兌換
            if (code.Amount > 1 && codeRecorder.Count < code.Amount && codeRecorder.Add(product))
            {
                return true;
            }

            return false;
        }
    }

    public class Code
    {
        // 條碼可兌換的商品
        public HashSet<char> Products { get; set; } = new HashSet<char>();
        // 可兌換的商品數量
        public int Amount { get; set; }
    }
}