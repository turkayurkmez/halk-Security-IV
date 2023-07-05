﻿using System;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InjectionAttacks
{
    public class CSRFHelper
    {
        public static void Check(Page page, HiddenField hiddenField)
        {
            if (!page.IsPostBack)
            {
                Guid guid = Guid.NewGuid();
                hiddenField.Value = guid.ToString();
                page.Session["token"] = guid;
            }
            else
            {
                Guid client = new Guid(hiddenField.Value);
                Guid server = (Guid)page.Session["token"];
                if (client != server)
                {
                    throw new SecurityException("CSRF Atağı algılandı! YEMEDİK YANİ!!!");

                }
            }
        }
    }
}