using LocalizationCRUD.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocalizationCRUD.Models
{
    public class SearchClassMessage: RisorseLocalizzazioneMessage
    {
        public SearchClassMessage()
        {
            ResultList = new List<RisorseLocalizzazioneMessage>();
        }

        public List<RisorseLocalizzazioneMessage> ResultList { get; set; }
        public new int? idModulo { get; set; }


    }
}