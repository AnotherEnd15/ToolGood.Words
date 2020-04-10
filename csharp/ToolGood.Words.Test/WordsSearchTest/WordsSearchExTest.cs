﻿using PetaTest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ToolGood.Words.Test
{
    [TestFixture]
    public class WordsSearchExTest
    {
        [Test]
        public void test3()
        {
            string s = "中国|国人|zg人";
            string test = "我是中国人";

            WordsSearchEx2 wordsSearch = new WordsSearchEx2();
            wordsSearch.SetKeywords(s.Split('|').ToList());

            var b = wordsSearch.ContainsAny(test);
            Assert.AreEqual(true, b);


            var f = wordsSearch.FindFirst(test);
            Assert.AreEqual("中国", f.Keyword);

            var alls = wordsSearch.FindAll(test);
            Assert.AreEqual("中国", alls[0].Keyword);
            Assert.AreEqual(2, alls[0].Start);
            Assert.AreEqual(3, alls[0].End);
            Assert.AreEqual(0, alls[0].Index);//返回索引Index,默认从0开始
            Assert.AreEqual("国人", alls[1].Keyword);
            Assert.AreEqual(2, alls.Count);

            var t = wordsSearch.Replace(test, '*');
            Assert.AreEqual("我是***", t);


        }
    }
}
