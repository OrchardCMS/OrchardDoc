﻿using System.Collections.Generic;
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
            var documentPath = ctx.Server.MapPath("~/مستندات");
            using (var indexService = new IndexService(indexWriter)) {
                indexService.IndexEntities(
                    Directory.EnumerateFiles(documentPath, "*.markdown", SearchOption.AllDirectories),
                    f => {
                        var doc = new Document();
                        var name = Path.GetFileNameWithoutExtension(f);
                        var text = File.ReadAllText(f);
                        doc.Add(new Field("Id", name, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("Url", "~/مستندات/" + name, Field.Store.YES, Field.Index.NOT_ANALYZED));
                        doc.Add(new Field("Title", name.Replace('-', ' '), Field.Store.YES, Field.Index.ANALYZED));
                        doc.Add(new Field("Text", text, Field.Store.YES, Field.Index.ANALYZED));
                        doc.Add(new Field("Summary", MarkdownExtensions.ExtractSummary(text), Field.Store.YES, Field.Index.NOT_ANALYZED));
                        return doc;
                    });
            }
        }

        public static SearchResults Query(HttpContext ctx, string query, int page = 1) {
            if (string.IsNullOrWhiteSpace(query)) {
                return new SearchResults {
                    Documents = new SearchResult[0],
                    TotalCount = 0
                };
            }
            var indexPath = ctx.Server.MapPath("~/App_Data/Index");
            var indexSearcher = new DirectoryIndexSearcher(new DirectoryInfo(indexPath));
            using (var searchService = new SearchService(indexSearcher)) {
                var parser = new MultiFieldQueryParser(
                    Lucene.Net.Util.Version.LUCENE_29,
                    new[] { "Text" },
                    new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29));
                Query multiQuery = parser.Parse(query);

                var result = searchService.SearchIndex(multiQuery);
                return new SearchResults {
                    Documents = result.Results
                    .Skip(PageSize*(page - 1))
                    .Take(PageSize)
                    .Select(d => new SearchResult {
                        Url = d.Get("Url"),
                        Title = d.Get("Title"),
                        Summary = d.Get("Summary")
                    }),
                    TotalCount = result.Results.Count()
                };
            }
        }
    }
}