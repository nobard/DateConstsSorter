using System;
using System.Collections.Generic;
using System.Text;
using StringSorter.Utilities;

namespace StringSorter
{
    public class DateConstElement
    {
        public string Element { get; }
        public string Description { get; private set; }
        public string ConstPole { get; private set; }
        public string ConstName { get; private set; }
        public DateTime ConstDate { get; private set; }

        public DateConstElement(string element)
        {
            Element = element;
            SetElementProperties(element);
        }

        private void SetElementProperties(string element)
        {
            var sb = new StringBuilder();
            
            element.Split('\r').ForEach(x =>
            {
                if (!x.Contains("new DateTime("))
                {
                    sb.AppendLine(x);
                }
                else
                {
                    Description = sb.ToString();
                    ConstPole = x;
                    ConstName = GetConstName(x);
                    ConstDate = GetConstDate(x);
                }
            });
        }

        private string GetConstName(string element)
        {
            var splittedPole = element.Split(' ');

            for (var i = 0; i < splittedPole.Length; i++)
            {
                if (splittedPole[i] == "DateTime") return splittedPole[i + 1];
            }

            return "";
        }

        private DateTime GetConstDate(string element)
        {
            var dateList = new List<int>();
            
            element.Split('(', ')', ',').ForEach(x =>
            {
                if(int.TryParse(x, out var result)) dateList.Add(result);
            });
            
            return new DateTime(dateList[0], dateList[1], dateList[2]);
        }

        public override string ToString() 
            => $"Const Name: {ConstName} Const Date: {ConstDate}";
    }
}