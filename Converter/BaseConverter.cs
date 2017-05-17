namespace ch.tobiaswuerth.baseconverter
{
    using System;
    using System.Linq;
    using System.Numerics;

    public static class BaseConverter
    {
        /// <summary>
        ///     Converts an input string in base-n into the equivalent in base-ten based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>BigInteger base-ten value of given input</returns>
        public static BigInteger ToDec(Char[] charset, String input)
        {
            return ToDec(new String(charset), input);
        }

        /// <summary>
        ///     Converts an input string in base-n into the equivalent in base-ten based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>BigInteger base-ten value of given input</returns>
        public static BigInteger ToDec(String charset, String input)
        {
            // validation
            if (null == charset)
            {
                throw new ArgumentException("Charset cannot be undefined", "charset");
            }
            if (1 > charset.Length)
            {
                throw new ArgumentException("Charset cannot be empty", "charset");
            }
            if (null == input)
            {
                throw new ArgumentException("Input cannot be undefined", "input");
            }
            if (input.ToList().Any(x => !charset.Contains(x)))
            {
                throw new ArgumentException("Input contains characters which are not defined in the charset", "input");
            }

            BigInteger nummericBase = charset.Length;
            BigInteger result = 0;
            Int32 inputLength = input.Length;
            for (Int32 i = 0; i < inputLength; i++)
            {
                Int32 valueOfChar = charset.IndexOf(input[i]);
                BigInteger pow = BigInteger.Pow(nummericBase, inputLength - i - 1);
                BigInteger mul = BigInteger.Multiply(valueOfChar, pow);
                result = BigInteger.Add(result, mul);
            }

            return result;
        }

        /// <summary>
        ///     Converts an input in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(Char[] charset, Int32 input)
        {
            return ToBase(new String(charset), new BigInteger(input));
        }

        /// <summary>
        ///     Converts an input in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(String charset, Int32 input)
        {
            return ToBase(charset, new BigInteger(input));
        }

        /// <summary>
        ///     Converts an input string in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(Char[] charset, String input)
        {
            return ToBase(new String(charset), BigInteger.Parse(input));
        }

        /// <summary>
        ///     Converts an input string in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(String charset, String input)
        {
            return ToBase(charset, BigInteger.Parse(input));
        }

        /// <summary>
        ///     Converts an input in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(Char[] charset, BigInteger input)
        {
            return ToBase(new String(charset), input);
        }

        /// <summary>
        ///     Converts an input in base-ten into the equivalent in base-n based on the given charset
        /// </summary>
        /// <param name="charset"></param>
        /// <param name="input"></param>
        /// <returns>String base-n value of given input</returns>
        public static String ToBase(String charset, BigInteger input)
        {
            if (null == charset)
            {
                throw new ArgumentException("Charset cannot be undefined", "charset");
            }
            if (1 > charset.Length)
            {
                throw new ArgumentException("Charset cannot be empty", "charset");
            }

            BigInteger nummericBase = charset.Length;
            String result = String.Empty;
            do
            {
                BigInteger div = BigInteger.Divide(input, nummericBase);
                BigInteger mul = BigInteger.Multiply(div, nummericBase);
                BigInteger reminder = BigInteger.Subtract(input, mul);
                result = charset[(Int32) reminder] + result;
                input = div;
            }
            while (0 < input);

            return result;
        }
    }
}