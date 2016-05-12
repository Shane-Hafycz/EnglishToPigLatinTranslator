using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static string MakePigLatin(string word)
        {
         
            char firstLetter;
            string restOfWord;
          //if there is any punctuation and uppercase letters in the word
            if ((word.Any(char.IsPunctuation))&(word.Any(c => char.IsUpper(c))))
            {
                char puncuation = word[word.Length - 1];
               
                if(word.Length ==1)
                {
                    restOfWord = word; 
                }
                else if (word.Length == 2)
                {
                    restOfWord = word.Substring(0, 0)+"ay"+puncuation;

                }
                else if (word.Length == 3)
                {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    firstLetter = word[0];
                    restOfWord = word.Substring(1, 1);
                    restOfWord = Char.ToUpperInvariant(restOfWord[0]) + restOfWord.Substring(1) + firstLetter+"ay"+puncuation;
                }
                else
                {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    firstLetter = word[0];
                    restOfWord = word.Substring(1, word.Length - 2);
                    restOfWord = Char.ToUpperInvariant(restOfWord[0]) + restOfWord.Substring(1)+firstLetter+"ay"+puncuation;
                }

            }

            //if there is punctuation in the word
            else if (word.Any(char.IsPunctuation))
            {
                char puncuation = word[word.Length - 1];
                if(word.Length == 1)
                {
                    restOfWord = word;
                }
                else if(word.Length ==2)
                {
                    restOfWord = word.Substring(0, 0) + "ay" + puncuation;
                }
                else
                {
                    restOfWord = word.Substring(0, word.Length - 1) + "ay" + puncuation;
                }
            }
            //if there is any uppercase letters in the word
            else if (word.Any(c => char.IsUpper(c)))
            {
                if (word.Length == 1)
                {
                    restOfWord = word + "ay";
                }
                else {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    firstLetter = word[0];
                    restOfWord = word.Substring(1, word.Length - 1);
                    restOfWord = Char.ToUpperInvariant(restOfWord[0]) + restOfWord.Substring(1) + firstLetter + "ay";
                    
                }
            }

            else
            {
                firstLetter = word[0];
                restOfWord = word.Substring(1, word.Length - 1)+firstLetter + "ay";
            }

            
            return restOfWord;
        }

        private static string PigLatintoEnglish(string word)
        {
            char lastLetter;
            String restofWord;
            //if there is puncuation and any uppercase letters
            if ((word.Any(char.IsPunctuation)) & (word.Any(c => char.IsUpper(c))))
            {
                char puncuation = word[word.Length - 1];
                // isPunctuation = true;
                if (word.Length == 1)
                {
                    restofWord = word;
                }
                else if (word.Length == 2)
                {
                    restofWord = word.Substring(0, 0) + puncuation;

                }
                else if (word.Length == 3)
                {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    lastLetter = Char.ToUpperInvariant(word[word.Length-2]);
                    restofWord = word.Substring(0, 0);
                    restofWord = lastLetter+ restofWord + puncuation;
                }

                else
                {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    lastLetter = Char.ToUpperInvariant(word[word.Length-4]);
                    restofWord = word.Substring(0, word.Length - 4);
                    restofWord = lastLetter + restofWord + puncuation;
                }
            }
            //if there is puncuation
            else if (word.Any(char.IsPunctuation))
            {
                char puncuation = word[word.Length - 1];
                if (word.Length == 1)
                {
                    restofWord = word;
                }
                else if (word.Length == 3)
                {
                    restofWord = word.Substring(0, 0) + puncuation;
                }
                else if (word.Length == 4)
                {
                    restofWord = word.Substring(0, 0) + puncuation;
                }
                else
                {
                    lastLetter = word[word.Length - 4];
                    restofWord = word.Substring(0, word.Length - 3) + puncuation;
                }
            }
            //if there is any uppercase letters
            else if (word.Any(c => char.IsUpper(c)))
            {
                if (word.Length == 3)
                {
                    restofWord = word.Substring(0,1) ;
                }
                else
                {
                    word = Char.ToLowerInvariant(word[0]) + word.Substring(1);
                    lastLetter = Char.ToUpperInvariant(word[word.Length-3]);
                    restofWord = word.Substring(0, word.Length - 3);
                    restofWord = lastLetter+restofWord;
                    
                }
            }

            else
            {
                if (word.Length == 3)
                {
                    restofWord = word.Substring(0, 1);
                }
                
                else
                {
                    lastLetter = word[word.Length - 3];
                    restofWord = lastLetter + word.Substring(0, word.Length - 3);
                }
            }
            
            return restofWord;          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            var pigLatinWords = textBox1.Text

                                 .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                 .Select(MakePigLatin);

            textBox2.Text = string.Join(" ", pigLatinWords);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var englishWords = textBox2.Text
                                       .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                                       .Select(PigLatintoEnglish);
            textBox3.Text = string.Join(" ", englishWords);
        }
    }
}
