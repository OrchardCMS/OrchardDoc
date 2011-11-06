jQuery(function($) {
    var toc = $(".TocContainer ol")
        .on("mouseenter", function() {
            if (tocOverlay.width() > parent.width()) {
                tocOverlay.show();
            }
        });
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
    var parent = toc.parent(),
        tocOverlay = parent
          .clone()
          .insertBefore(parent)
          .css({
            overflow: "visible",
            position: "absolute",
            right: "10px",
        }).hide()
          .on("mouseleave", function() {tocOverlay.hide();});
});