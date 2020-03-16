$("#CarMakes").on("click", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: "Main/DisplayByMake",
        type: "POST",
        data: { carMake: JSON.stringify(carMake) },
        dataType: "html"
    }).done(function (response) {
        console.log("done");
        $("#main-body").html(response);
    });
});