﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace C18_Ex01_Gregory_317612950_Mariya_321373136
{
    public interface INews
    {
        List<INewsArticle> GetNewsArticles(string i_Params = "");
    }
}
