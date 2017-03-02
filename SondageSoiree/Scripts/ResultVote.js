

console.log("ok");


$(".bar").each(function () {
    $(this).find(".bar-bar")
        .animate({
        height: $(this).attr("number")*5+"vmin"
    }, 1500);
});

