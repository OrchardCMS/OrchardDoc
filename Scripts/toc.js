jQuery(function($) {
    var toc = $("#TocContainer ol");
    $("#MainDiv :header")
        .each(function() {
            var h = $(this),
                name = h.text().replace(/[\s,-;\.]/g, "");
            h.before($("<a/>", {name: name}));
            toc.append(
                $("<li></li>").append(
                    $("<a/>", {
                        href: "#" + name
                    })
                    .append($("<" + this.tagName + "/>", {
                        html: h.text().replace(/\s/g, "&nbsp;")
                    }))
                )
            );
        });
});