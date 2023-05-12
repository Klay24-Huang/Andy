using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Tests
{
    [TestClass()]
    public class Class1Tests
    {
        [TestMethod()]
        public void ChangeableTest_1()
        {
            var class1 = new Class1();
            var products = new char[] { 'A' };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
            };
            var result = class1.Changeable(products, codes);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ChangeableTest_2()
        {
            var class1 = new Class1();
            var products = new char[] { 'A', 'B' };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
            };
            var result = class1.Changeable(products, codes);
            // 商品多餘可兌換數量
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ChangeableTest_3()
        {
            var class1 = new Class1();
            var products = new char[] { 'A' };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 2
                },
            };
            var result = class1.Changeable(products, codes);
            // 沒有兌換完全部商品
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ChangeableTest_4()
        {
            var class1 = new Class1();
            var products = new char[] { 'A', 'B', 'C' };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 2
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期正確
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ChangeableTest_5()
        {
            var class1 = new Class1();
            var products = new char[] {
                'A',
                'B', 'C',
                'B', 'Z'
            };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 2
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'D', 'Z' },
                    Amount = 2
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期正確
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ChangeableTest_6()
        {
            var class1 = new Class1();
            var products = new char[] {
                'A',
                'B', 'C',
                'B', 'Z',
                'A',
                'Z',
                'O',
                'A', 'B', 'C',
                'B',
                'P', 'X',
                'Z',
                'P'
            };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 2
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'D', 'Z' },
                    Amount = 2
                },
                new Code
                {
                    Products = new HashSet<char>{ 'O', 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'Z', 'A', 'O' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'O' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 3
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C', 'D', 'E', 'F'},
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'P', 'X', 'Y' },
                    Amount = 2
                },
                new Code
                {
                    Products = new HashSet<char>{ 'Z' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'P', 'Z' },
                    Amount = 1
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期正確
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ChangeableTest_7()
        {
            var class1 = new Class1();
            var products = new char[] {
                'A',
                'B',
                'B',
            };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'D', 'Z' },
                    Amount = 1
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期正確
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public void ChangeableTest_8()
        {
            var class1 = new Class1();
            var products = new char[] {
                'A',
                'B',
                'B',
            };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C' },
                    Amount = 1
                },
                new Code
                {
                    Products = new HashSet<char>{ 'C' },
                    Amount = 1
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期錯誤
            Assert.IsFalse(result);
        }

        [TestMethod()]
        public void ChangeableTest_9()
        {
            var class1 = new Class1();
            var products = new char[] {
                // 5
                'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T',
                // 2
                'M', 'N', 'O', 'P', 'Q', 'R',
                // 7
                'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I',
                // 0
                'A', 'B', 'C', 'D',
                // 4
                'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J',
                // 9
                'G', 'H', 'I', 'J', 'K', 'L', 'M',
                // 6
                'W', 'X', 'Y',
                // 3
                'W', 'X', 'Y',
                // 1
                'F', 'G', 'H', 'I', 'J',
                // 8
                'N', 'O', 'P', 'Q', 'R', 'S', 'T',
            };
            var codes = new Code[] {
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C', 'D', 'E' },
                    Amount = 4
                },
                new Code
                {
                    Products = new HashSet<char>{ 'F', 'G', 'H', 'I', 'J', 'K', 'L' },
                    Amount = 5
                },
                new Code
                {
                    Products = new HashSet<char>{ 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T' },
                    Amount = 6
                },
                new Code
                {
                    Products = new HashSet<char>{'U', 'V', 'W', 'X', 'Y', 'Z'},
                    Amount = 3
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' },
                    Amount = 9
                },
                new Code
                {
                    Products = new HashSet<char>{ 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U'},
                    Amount = 9
                },
                new Code
                {
                    Products = new HashSet<char>{ 'V', 'W', 'X', 'Y', 'Z', },
                    Amount = 3
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M'},
                    Amount = 9
                },
                new Code
                {
                    Products = new HashSet<char>{ 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' },
                    Amount = 7
                },
                new Code
                {
                    Products = new HashSet<char>{ 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N'},
                    Amount = 7
                },
            };
            var result = class1.Changeable(products, codes);
            // 預期正確
            Assert.IsTrue(result);
        }
    }
}