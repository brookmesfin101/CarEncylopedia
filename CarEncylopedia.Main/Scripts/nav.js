// Car Makes Display and Sort

$("#CarMakes").on("click", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();    
    var sortBy = $(".car-makes-sort-by").children("option:selected").val();
    var sortOrder = $(".car-makes-sort-order-numeric").children("option:selected").val();
    if (sortBy === "Model") {
        sortOrder = $(".car-makes-sort-order-alpha").children("option:selected").val();
    }
    var url = $("#DisplayByMakeURL").val();

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
            var carSort = $(".car-makes-sort");
            if (carSort.hasClass("d-none")) {
                carSort.removeClass("d-none");
            }
        },
        url: url,
        type: "POST",
        data: { carMake: JSON.stringify(carMake), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {        
        $("#main-body").html(response);
        if ($("#carMakesSortOptions").hasClass("d-none")) {
            $("#carMakesSortOptions").removeClass("d-none");
        }
        if (!$("#carPriceSortOptions").hasClass("d-none")) {
            $("#carPriceSortOptions").addClass("d-none");
        }
    });
});

$(".car-makes-sort-by").on("change", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();   
    var sortBy = $(".car-makes-sort-by").children("option:selected").val();
    var sortOrder = $(".car-makes-sort-order-numeric").children("option:selected").val();
    if (sortBy === "Model") {
        sortOrder = $(".car-makes-sort-order-alpha").children("option:selected").val();
    }
    var url = $("#DisplayByMakeURL").val();

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carMake: JSON.stringify(carMake), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
        var alphaSortOrder = $(".car-makes-sort-order-alpha");
        var numericSortOrder = $(".car-makes-sort-order-numeric");

        if (sortBy === "Model") {           
            if (alphaSortOrder.hasClass("d-none")) { alphaSortOrder.removeClass("d-none"); }
            if (!numericSortOrder.hasClass("d-none")) { numericSortOrder.addClass("d-none"); }
        } else {
            if (!alphaSortOrder.hasClass("d-none")) { alphaSortOrder.addClass("d-none"); }
            if (numericSortOrder.hasClass("d-none")) { numericSortOrder.removeClass("d-none"); }
        }
    });
});

$(".car-makes-sort-order-alpha").on("change", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();
    var sortBy = $(".car-makes-sort-by").children("option:selected").val();
    var sortOrder = $(this).children("option:selected").val();    
    var url = $("#DisplayByMakeURL").val();

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carMake: JSON.stringify(carMake), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder)},
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

$(".car-makes-sort-order-numeric").on("change", function () {
    var carMake = $("#CarMakesSelect").children("option:selected").val();
    var sortBy = $(".car-makes-sort-by").children("option:selected").val();
    var sortOrder = $(this).children("option:selected").val();
    var url = $("#DisplayByMakeURL").val(); 

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carMake: JSON.stringify(carMake), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

// Car Prices Display and Sort

$("#CarPrices").on("click", function () {
    var carPrice = $("#CarPricesSelect").children("option:selected").val();
    var sortBy = $(".car-prices-sort-by").children("option:selected").val();
    var sortOrder = $(".car-prices-sort-order-numeric").children("option:selected").val();
    if (sortBy === "Model") {
        sortOrder = $(".car-prices-sort-order-alpha").children("option:selected").val();
    }
    var url = $("#DisplayByPriceURL").val(); 

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carPrice: JSON.stringify(carPrice), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder)  },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
        if ($("#carPriceSortOptions").hasClass("d-none")) {
            $("#carPriceSortOptions").removeClass("d-none");
        }
        if (!$("#carMakesSortOptions").hasClass("d-none")) {            
            $("#carMakesSortOptions").addClass("d-none");
        }
    });
});

$(".car-prices-sort-by").on("change", function () {
    var carPrice = $("#CarPricesSelect").children("option:selected").val();
    var sortBy = $(".car-prices-sort-by").children("option:selected").val();
    var sortOrder = $(".car-prices-sort-order-numeric").children("option:selected").val();
    if (sortBy === "Model") {
        sortOrder = $(".car-prices-sort-order-alpha").children("option:selected").val();
    }
    var url = $("#DisplayByPriceURL").val(); 

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carPrice: JSON.stringify(carPrice), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
        var alphaSortOrder = $(".car-prices-sort-order-alpha");
        var numericSortOrder = $(".car-prices-sort-order-numeric");

        if (sortBy === "Model") {
            if (alphaSortOrder.hasClass("d-none")) { alphaSortOrder.removeClass("d-none"); }
            if (!numericSortOrder.hasClass("d-none")) { numericSortOrder.addClass("d-none"); }
        } else {
            if (!alphaSortOrder.hasClass("d-none")) { alphaSortOrder.addClass("d-none"); }
            if (numericSortOrder.hasClass("d-none")) { numericSortOrder.removeClass("d-none"); }
        }
    });
});

$(".car-prices-sort-order-alpha").on("change", function () {
    var carPrice = $("#CarPricesSelect").children("option:selected").val();
    var sortBy = $(".car-prices-sort-by").children("option:selected").val();
    var sortOrder = $(this).children("option:selected").val();
    var url = $("#DisplayByPriceURL").val();   

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carPrice: JSON.stringify(carPrice), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

$(".car-prices-sort-order-numeric").on("change", function () {
    var carPrice = $("#CarPricesSelect").children("option:selected").val();
    var sortBy = $(".car-prices-sort-by").children("option:selected").val();
    var sortOrder = $(this).children("option:selected").val();
    var url = $("#DisplayByPriceURL").val();   

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { carPrice: JSON.stringify(carPrice), sortBy: JSON.stringify(sortBy), sortOrder: JSON.stringify(sortOrder) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

// Visualize Section
// Car Compare By Make

$("#CompareMakesToggle").on("click", function () {
    $("#CompareMakesOptions").toggleClass("d-none");
});

$("#CompareMakes").on("click", function () {
    var compare = $("#CompareMakesOn").children("option:selected").val();
    var url = $("#CompareMakesToggleURL").val();    

    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "POST",
        data: { compare: JSON.stringify(compare) },
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

$("#ComparePackages").on("click", function () {
    var url = $("#ComparePackagesURL").val();

    if (!$("#CompareMakes").hasClass("d-none")) {
        $("#CompareMakesOptions").addClass("d-none");
    }
    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "GET",
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});

$("#CompareYears").on("click", function () {
    var url = $("#CompareYearsURL").val();

    if (!$("#CompareMakes").hasClass("d-none")) {
        $("#CompareMakesOptions").addClass("d-none");
    }
    $.ajax({
        beforeSend: function () {
            $("#busy").removeClass("d-none");
        },
        complete: function () {
            $("#busy").addClass("d-none");
        },
        url: url,
        type: "GET",
        dataType: "html"
    }).done(function (response) {
        $("#main-body").html(response);
    });
});