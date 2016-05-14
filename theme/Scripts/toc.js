;(function($){
    $(document).ready(function(){
        var toc = $(".TocContainer ol")
            .on("mouseenter", function() {
                if (tocOverlay.width() > parent.width()) {
                    tocOverlay.show();
                }
            });
            
        $("#MainDiv :header")
            .each(function() {
                var $headerTag = $(this);
                var cleanedHeaderFragment = $headerTag.text().replace(/[^A-Za-z0-9\-]/g, "");
                var headerId = getHeaderId(cleanedHeaderFragment);
                
                $headerTag.attr("id", headerId);
                
                toc.append(
                    $("<li></li>").append(
                        $("<a/>", {
                            href: "#" + headerId
                        })
                        .append($("<" + this.tagName + "/>", {
                            html: $headerTag.text().replace(/\s/g, "&nbsp;")
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
    
    function getHeaderId(headerFragment, nextIndex) {
        var idToQuery = (nextIndex === undefined ? headerFragment : headerFragment + nextIndex);
                
        if($("#" + idToQuery).length === 0) {
            return idToQuery;
        }

        if(nextIndex === undefined) {
            nextIndex = 1;
        }

        return getHeaderId(headerFragment, nextIndex + 1);
    }
})(window.jQuery);