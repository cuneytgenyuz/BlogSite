﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Web;

namespace WBlog.App_Classes
{
    public class Settings
    {
        public static Size ResimKucukBoyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["sw"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["sh"]);
                return sonuc;
            }
        }

        public static Size ResimOrtakBoyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["mw"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["mh"]);
                return sonuc;
            }
        }

        public static Size ResimBuyukBoyut
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["lw"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["lh"]);
                return sonuc;
            }
        }

        public static Size YazarResim
        {
            get
            {
                Size sonuc = new Size();

                sonuc.Width = Convert.ToInt32(ConfigurationManager.AppSettings["yazar"]);
                sonuc.Height = Convert.ToInt32(ConfigurationManager.AppSettings["yazar"]);
                return sonuc;
            }
        }

    }
}