using System;
using System.Text;
using _01.Logger.Models.Contracts;

namespace _01.Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
        }

        public string Format => this.GetFormat();

        private string GetFormat()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("<log>")
                    .AppendLine("\t<date>{0}</date>")
                    .AppendLine("\t<level>{1}</level>")
                    .AppendLine("\t<message>{2}</message>")
                .AppendLine("</log>");

            return sb.ToString();
        }
    }
}
