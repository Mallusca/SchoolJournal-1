(function () {
    // разобраться с кнопкой + она не исчезает
    // закомитить 

    //поработать на дизайном, чтобы было чуть-чуть красивее посмотри в сторону материал дизайн гайдов
    //bootstrap дизайна
    //вынести весь цсс в отдельный файл

    //повыносить все элементы типа  $(".confirm-column-creation") в переменные пример ниже

    // просмотреть все имена методов и цсс классов, буду строго дрючить


    var createColumnButton = $(".create-column"),
        cancelColumnButton = $(".cancel-column"),
        confirmColumnButton = $(".confirm-column-creation"),
        createColumnCell = $(".new-column-cell"),
        createColumnDate = $(".new-column-date")

    window.createColumn = function () {
        var now = new Date();
        var day = ("0" + now.getDate()).slice(-2);
        var month = ("0" + (now.getMonth() + 1)).slice(-2);
        var today = now.getFullYear() + "-" + (month) + "-" + (day);
        $("#datetime").val(today);
        createColumnButton.hide();
        confirmColumnButton.show();
        createColumnCell.show();
        createColumnDate.show();
        cancelColumnButton.show();
        $('.new-date').val();      
    }

    window.cancelColumn = function () {
        createColumnCell.hide();
        createColumnDate.hide();
        cancelColumnButton.hide();
        confirmColumnButton.hide();
        createColumnButton.show();
    }

    window.deleteAllColumnsAndDates = function () {
        $.ajax({
            url: "/School/DeleteColumnAndMarks",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            success: function (response) {
                if (response) {
                    $('.journal-container').load("/School/Partial");
                }
                else
                    alert("ошибка, колонки не удалены!");

            },
            error: function (error) {
                alert("ошибка, колонка не добавлена, смотри консоль!");
                console.log(error);
            }
        });
    }

    window.confirmColumnCreation = function () {
        let columnMarks = $('.new-column-input').map(function () {
            const input = this;
            if (input.value !== "") {
                return {
                    value: input.value,
                    studentId: input.getAttribute("studentid")
                };
            }
        }).get();

        if (columnMarks.length === 0) {
            alert("Введите оценки");
            return;
        }

        $.ajax({
            url: "/School/CreateColumn",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ marks: columnMarks,inputValue:$('.new-date').val()}),
            success: function (response) {
                if (response) {
                    $('.journal-container').load("/School/Partial", function () {
                        createColumnCell.hide();
                        createColumnDate.hide();
                    });
                }
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