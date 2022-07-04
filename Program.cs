//@mokhc
//Program demonstrates reading of a csv file
//and filtering individual characters into meaningful elements.
//These elements are converted to type double and the sum and average are calculated.

//declaration
using System;
using System.IO;

namespace File1
{
    class Program
    {
        //const string
        const string Path = "C:\\Users\\Mok\\Files\\CSharp\\YangHu\\File\\CSV3\\Test1.csv";

        static void Main(string[] args)
        {
            //declaration and assignment
            string gettext1;
            //char array
            char[] copytext1;

            //method to read the all the text in the file according to the path
            gettext1 = File.ReadAllText(Path);
            int len = gettext1.Length;
            Console.WriteLine("The len of the original string is : " + len);

            copytext1 = new char[len];
            //copy the text into an array
            gettext1.CopyTo(0, copytext1, 0, len);
  
            //calculating the total of all the elements
            //declaration and assignment
            string[] filter1;
            string strgetnum1 = "";
            int countnum;
            countnum = 0;

            //concatenate the necessary characters into a string
            for (int a = 0; a < len; a++)
            {
                //filter out the necesaary characters
                //characters are '0' to '9' and '.' 
                if ((copytext1[a] == 48 || copytext1[a] == 49 || copytext1[a] == 50
                    || copytext1[a] == 51 || copytext1[a] == 52 || copytext1[a] == 53
                    || copytext1[a] == 54 || copytext1[a] == 55 || copytext1[a] == 56
                    || copytext1[a] == 57) || (copytext1[a] == 46))
                {
                    strgetnum1 = strgetnum1 + copytext1[a];
                }
                //target character is ','
                if (copytext1[a] == 44)
                {
                    //add a zero before and after the character
                    strgetnum1 = strgetnum1 + "0";
                }
            }
            Console.WriteLine("The content of strgetnum1 is :" + strgetnum1);
            int lennum1 = strgetnum1.Length;
            Console.WriteLine("Length of strgetnum1 :" + lennum1);

            //count the number of elements
            //there is a zero before the start and after the end of each element
            //these zeros are used to count
            //declaration and assignment
            int countzero;
            countzero = 0;
            char tempchar;
            string com1;
            com1 = "";

            //character Enumerator
            //loop through all the characters in the string
            CharEnumerator ce1 = strgetnum1.GetEnumerator();
            //find the first character using MoveNext()
            bool ans1 =  ce1.MoveNext();
            while (ans1)
            {
                //assign the current character
                tempchar = ce1.Current;
                if (tempchar != '0')
                {
                    com1 = com1 + tempchar;
                }
                if (tempchar == '0')
                {
                    countzero++;
                }
                //find if there is a next character
                ans1 = ce1.MoveNext();
            }
            com1 = "";
            Console.WriteLine("Variable countzero is :" + countzero);
            Console.WriteLine("The number of elements is :" + (countzero - 1));

            //put the elements into an array
            //declaration and assignment
            int lenfilter = countzero - 1;
            filter1 = new string[lenfilter];
            int countloop;

            //character Enumerator
            //loop through all the characters in the string
            CharEnumerator ce2 = strgetnum1.GetEnumerator();
            countloop = 0;
            //find the first character using MoveNext()
            bool ans2 = ce2.MoveNext();
            while (ans2)
            {
                //assign the current character
                tempchar = ce2.Current;
                if (tempchar != '0')
                {
                    com1 = com1 + tempchar;
                }
                if ((tempchar == '0') & (countloop != 0))
                {
                    filter1[countnum] = com1;
                    countnum++;
                    com1 = "";
                }
                //find if there is a next character
                ans2 = ce2.MoveNext();
                countloop++;
            }

            //display all the elements
            for (int a = 0; a < lenfilter; a++)
            {
                Console.WriteLine("Value of element " + a + " is : " + filter1[a]);
            }

            //convert the elements to type double
            //declaration
            double[] array1 = new double[lenfilter];
            for (int a = 0; a < lenfilter; a++)
            {
                array1[a] = Double.Parse(filter1[a]);
            }

            //add the elements
            double total1 = 0;
            for (int a = 0; a < lenfilter; a++)
            {
                total1 = total1 + array1[a];
            }

            //find the average
            double average1 = 0;
            average1 = total1 / lenfilter;

            //display the results
            Console.WriteLine("The sum of all the elements is :" + total1);
            Console.WriteLine("The average of all the elements is :" + average1);
        }
    }
}
