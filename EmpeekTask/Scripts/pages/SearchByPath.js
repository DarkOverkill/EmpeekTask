var onSearchClick = function () {
    console.log($("#searchPath")[0].value);

    var data = {
        path: $("#searchPath")[0].value
    }

    $.ajax({
        type: "GET",
        url: "/home/Search",
        dataType: "html",
        data: data
    }).done(function (data) {
        console.log("ajax-done");
        $(".mainInfo").html(data);
        $(".checkBoxIsDone").on("click", onCheckBoxClick);
    }).fail(function () {
        console.log("Something wrong(");
    })
}

var init = function () {
    $("#btn_searchByPath").on("click", onSearchClick);
}

$(function () {
    init();
})