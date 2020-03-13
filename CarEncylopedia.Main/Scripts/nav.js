$("#CarMakes").on("click", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();

    $.ajax({
        url: "Main/DisplayByMake",
        type: "POST",
        data: JSON.stringify(carMake),
        dataType: "json",
        contentType: "application/json; charset=utf-8"
    })
});