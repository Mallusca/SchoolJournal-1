(function () {
    // разобраться с кнопкой + она не исчезает
    // закомитить 

    //поработать на дизайном, чтобы было чуть-чуть красивее посмотри в сторону материал дизайн гайдов
    //bootstrap дизайна
    //вынести весь цсс в отдельный файл

    //повыносить все элементы типа  $(".confirm-column-creation") в переменные пример ниже

    // просмотреть все имена методов и цсс классов, буду строго дрючить
    $(document).ready(function () {
        $('.new-column-input').bind("change keyup input click", function () {
            if (this.value.match(/[^0-9]/g)) {
                this.value = this.value.replace(/[^0-9]/g, '');
            }
        });
    });


    var createColumnButton = $(".create-column"),
        cancelColumnCreationButton = $(".cancel-column-creation"),
        confirmColumnCreationButton = $(".confirm-column-creation"),
        newColumnCell = $(".new-column-cell"),
        newColumnDate = $(".new-column-date"),
        newColumnDateInput = $("#datetime"),
        newColumnMarks = $('.new-column-input');
        addStudentButton = $('.add-student-cell'),
        confirmStudentCreationButton = $('.confirm-student-creation'),
        newFirstName= $('.new-student-firstname'),
        newLastName= $('.new-student-lastname');

    window.addStudent = function () {
        addStudentButton.show();
        cancelColumnCreationButton.show()
    }

    window.createColumn = function () {
        let now = new Date();
        let day = ("0" + now.getDate()).slice(-2);
        let month = ("0" + (now.getMonth() + 1)).slice(-2);
        let today = now.getFullYear() + "-" + (month) + "-" + (day);

        newColumnDateInput.val(today);

        createColumnButton.hide();
        confirmColumnCreationButton.show();
        newColumnCell.show();
        newColumnDate.show();
        cancelColumnCreationButton.show();
    }

    window.cancelColumn = function () {
        newColumnCell.hide();
        newColumnDate.hide();
        cancelColumnCreationButton.hide();
        confirmColumnCreationButton.hide();
        createColumnButton.show();
        addStudentButton.hide();
    }
    window.confirmStudentCreation = function () {
        //let addStudentFirstName = newFirstName.map(function () {
        //    const input = this;
        //    if (input.value !== "") {
        //        return {
        //            value: input.value,
        //        };
        //    }
        //}).get();
        //let addStudentLastName = newLastName.map(function () {
        //    const input = this;
        //    if (input.value !== "") {
        //        return {
        //            value: input.value,
        //        };
        //    }
        //}).get();

        $.ajax({
            url: "/School/CreateStudent",
            type: "POST",
            contentType: "application/json",
            dataType: "json",
            data: JSON.stringify({ studentFirstName: newFirstName.val(),studentLastName: newLastName.val() }),
            success: function (response) {
                if (response) {
                    $('.journal-container').load("/School/Partial", function () {
                        addStudentButton.hide();
                    });
                }
                else {
                    alert("ошибка, студент не добавлен!");
                }
            },
            error: function (error) {
                alert("ошибка, студент не добавлен, смотри консоль!");
                console.log(error);
            }
        });
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
        let columnMarks = newColumnMarks.map(function () {
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
            data: JSON.stringify({ marks: columnMarks, inputValue: newColumnDateInput.val() }),
            success: function (response) {
                if (response) {
                    $('.journal-container').load("/School/Partial", function () {
                        newColumnCell.hide();
                        newColumnDate.hide();
                    });
                }
                else {
                    alert("ошибка, колонка не добавлена!");
                }
            },
            error: function (error) {
                alert("ошибка, колонка не добавлена, смотри консоль!");
                console.log(error);
            }
        });
    }
})();