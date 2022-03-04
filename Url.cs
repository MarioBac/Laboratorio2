using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp2
{
    internal class Url
    {
        private string resource;
        private int timesVisited;
        private DateTime fecha;
        public string Resource
        {
            get { return resource; }
            set { resource = value; }
        }

        public string[] UrlData()
        {
            string[] datos = { this.resource, this.timesVisited.ToString(), this.Date.ToString() };
            return datos;
        }

        public int TimesVisited
        {
            get { return timesVisited; }
            set { timesVisited = value; }
        }


        public DateTime Date
        {
            get { return fecha; }
            set { fecha = value; }
        }


    }
}
