using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using MarkdownSharp;
using MarkdownWebPages;

namespace App_Code {
    public static class MarkdownExtensions {
        public static string ProcessIncludes(string content, MarkdownWebPage page) {
            return Regex.Replace(content, @"^@include\((?<include>~/.*?)\)", match => MarkdownWebPage.RenderFile(match.Groups["include"].Value, page), RegexOptions.Multiline);
        }

        public static string ProcessComments(string content, MarkdownWebPage page) {
            return Regex.Replace(content, @"^//(.*?)$", match => String.Empty, RegexOptions.Multiline);
        }
    
        // First Header  | Second Header | Third Header
        // ------------- | ------------- | ------------
        // Content Cell  | Content Cell  | Content Cell
        // Content Cell  | Content Cell  | Content Cell
        public static string ProcessTables(string content, MarkdownWebPage page) {
            return Regex.Replace(content,
                @"\r\n((.*?)\s+\|\s+)+(.*?)\s*" +
                @"\r\n((-+?)\s+\|\s+)+(-+?)\s*" +
                @"\r\n(((.*?)\s+\|\s+)+(.*?)\s*\r\n)+",
            match => {
                var writer = new StringWriter();
                writer.WriteLine("<table><thead><tr>");
                foreach (Capture header in match.Groups[1].Captures) {
                    var headerVal = header.Value.Trim();
                    writer.WriteLine("    <td>" + headerVal.Substring(0, headerVal.Length - 1) + "</td>");
                }
                writer.WriteLine("    <td>" + match.Groups[3].Value.Trim() + "</td>");
                writer.WriteLine("</tr></thead><tbody>");
                var rows = match.Groups[7].Captures;
                var cells = match.Groups[9].Captures;
                var colCount = cells.Count/rows.Count;
                var i = 0;
                foreach (Capture row in rows) {
                    writer.WriteLine("    <tr>");
                    for (var j = 0; j < colCount; j++ ) {
                        writer.WriteLine("        <td>" + cells[colCount * i + j] + "</td>");
                    }
                    writer.WriteLine("        <td>" + match.Groups[10].Captures[i++] + "</td>");
                    writer.WriteLine("    </tr>");
                }
                writer.WriteLine("</tbody></table>");
                return writer.ToString();
            }
            , RegexOptions.Multiline);
        }

        private static readonly Regex RemoveImagesExpression = new Regex("<img [^>]*>");

        public static string RemoveImages(string html) {
            return RemoveImagesExpression.Replace(html, "");
        }

        public static string ExtractSummary(string content) {
            // Taking the first two paragraphs
            var reader = new StringReader(content);
            var result = new StringBuilder();
            var line = "";
            var paragraphs = 1;
            var isEmpty = true;
            while(line != null && paragraphs > 0) {
                line = reader.ReadLine();
                if (string.IsNullOrWhiteSpace(line)) {
                    if (!isEmpty) {
                        paragraphs--;
                        isEmpty = true;
                    }
                    else {
                        isEmpty = false;
                    }
                }
                result.AppendLine(line);
            }
            var markdown = new Markdown();
            return RemoveImages(markdown.Transform(result.ToString()));
        }
    }
}