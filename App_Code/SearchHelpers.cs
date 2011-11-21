using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using SimpleLucene.Impl;

namespace App_Code {
    public static class SearchHelpers
    {
        public const int PageSize = 10;

        public static void BuildIndex(HttpContext ctx) {
            var indexPath = ctx.Server.MapPath("~/App_Data/Index");
            var indexWriter = new DirectoryIndexWriter(new DirectoryInfo(indexPath), true);
            var documentPath = ctx.Server.MapPath("~/Documentation");
            using (var indexService = new IndexService(indexWriter)) {
                indexService.IndexEntities(
                    Directory.EnumerateFiles(documentPath, "*.markdown", SearchOption.AllDirectories),
                    f => {
                        var doc = new Document();
                        var name = Path.GetFileNameWithoutExtension(f);
                        var text = File.ReadAllText(f);
                        doc.Add(new Field("Id", name, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("Url", documentPath + '/' + name, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("Title", name.Replace('-', ' '), Field.Store.YES, Field.Index.ANALYZED));
                        doc.Add(new Field("Text", text, Field.Store.YES, Field.Index.ANALYZED));
                        doc.Add(new Field("Summary", MarkdownExtensions.ExtractSummary(text), Field.Store.YES, Field.Index.NOT_ANALYZED));
                        return doc;
                    });
            }
        }

        public static IEnumerable<Document> Query(HttpContext ctx, string query, int page = 0) {
            var indexPath = ctx.Server.MapPath("~/App_Data/Index");
            var indexSearcher = new DirectoryIndexSearcher(new DirectoryInfo(indexPath));
            using (var searchService = new SearchService(indexSearcher)) {
                var parser = new MultiFieldQueryParser(
                    Lucene.Net.Util.Version.LUCENE_29,
                    new[] { "Text" },
                    new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                Query multiQuery = parser.Parse(query);

                var result = searchService.SearchIndex(multiQuery);
                return result.Results.Skip(PageSize * page).Take(PageSize);
            }
        }
    }
}