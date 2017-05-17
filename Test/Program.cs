namespace Test
{
    using System;
    using System.Numerics;
    using ch.tobiaswuerth.baseconverter;

    internal class Program
    {
        private static void Main(String[] args)
        {
            String charset = "0123456789ABCDEF"; // base 16, hex
            String base16Input = "B8781E"; // 12089374 in decimal
            Int32 base10Input = 12089374;
            BigInteger resultBaseTen = BaseConverter.ToDec(charset, base16Input);
            if (resultBaseTen == base10Input)
            {
                Console.WriteLine("[OK] Base 10");
            }
            else
            {
                throw new Exception();
            }

            String resultBase16 = BaseConverter.ToBase(charset, base10Input);
            if (resultBase16 == base16Input)
            {
                Console.WriteLine("[OK] Base n");
            }
            else
            {
                throw new Exception();
            }

            String @base = BaseConverter.ToBase(charset, "657984635468794654687654686484684987445135121111215534");
            BigInteger bigInteger = BaseConverter.ToDec(charset, @base);
            if (bigInteger == BigInteger.Parse("657984635468794654687654686484684987445135121111215534"))
            {
                Console.WriteLine("[OK] Large numbers");
            }
            else
            {
                throw new Exception();
            }
        }
    }
}