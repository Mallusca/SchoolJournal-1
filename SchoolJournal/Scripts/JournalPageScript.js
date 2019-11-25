(function () {
    $(".create-column").show();
    $(".confirm-column-creation").hide();
    $(".new-column-cell").hide();
    $(".new-column-date").hide();

    window.createColumn = function () {
        $(".create-column").hide();
        $(".confirm-column-creation").show();
        $(".new-column-cell").show();
        $(".new-column-date").show();
        var currentDate = new Date();
        $(".new-column-date").text((currentDate.getMonth() + 1) + "." + currentDate.getDate() + "." + currentDate.getFullYear());
    }

    window.confirmColumnCreation = function () {
        $(".create-column").show();
        $(".confirm-column-creation").hide();
        $(".new-column-cell").hide();
        $(".new-column-date").hide();

        let columnMarks = $('.new-column-input').map(function () {
            const input = this;
            if (input.value === "") {
                return {
                    value: input.value,
                    studentId: input.getAttribute("studentid")
                };
            }
        }).get();



        $.ajax({
            url: "School/CreateColumn",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ marks: columnMarks }),
            success: function (response) {
                if (response)
                    alert("колонка успешно добавлена");
                else
                    alert("ошибка, колонка не добавлена!");

            },
            error: function (error) {
                alert("ошибка, колонка не добавлена, смотри консоль!");
                console.log(error);
            }
        });

    }
})();

//разобраться как обрабатывается ответ сервера в $.ajax
// разобраться почему мы заходим в error
