﻿using LocalizationCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalizationCRUD.Models
{
    public class SearchClassLabel: RisorseLocalizzazioneLabel
    {
        public SearchClassLabel()
        {
            ResultList = new List<RisorseLocalizzazioneLabel>();
        }

        public List<RisorseLocalizzazioneLabel> ResultList { get; set; }

        

    }
}