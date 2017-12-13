$(document).ready(function () {
    $.ajax({
        type: 'GET',
        url: "/api/message/id",
        dataType: "json",
        success: function (historyList) {
            createAlerts(historyList);
        },
        error: function (xhr) {
            console.log("Error",xhr)
        //var errorMessage = JSON.parse(xhr.responseText).message;
        //    swal({
        //        title: errorMessage,
        //        type: "error"
        //    });
        }
            //sessionStorage.setItem('partsData', JSON.stringify(JsonData));

            //partSelect.append('<option value="" selected disabled>Select a part</option>');

            //$.each(JsonData, function (index, part) {
            //    partSelect.append('<option value="' + part + '">' + part + '</option>');
            //});
    });


    //setInterval();

    //function check

    function createAlerts(alertlList) {
        var parent = $('.alert_list');
        parent.append(getTemplatePanel(alertlList))
        //$(".panel-group > .panel-info").remove();
        //panelList.forEach(function (item, index) {
        //    parent.append(getTemplatePanel(item, index, index == panelList.length - 1));
        //});
    }
    // добавить текущее время
    // + 1) Шановний ФІО реєстрація на рейс №Номеррейсу розпочнеться через 15 хвилин.Термінал: №НомерТерміналу.Приємного польоту.
    //2) Шановний ФІО реєстрація буде затримана на ЧасЗатримки Термінал: №НомерТерміналу.Дякуємо за  розуміння.Приємного польоту.
    //3) Шановний ФІО реєстрація на рейс №Номеррейсу розпочалася.Термінал: №НомерТерміналу.Приємного польоту.
    function getTemplatePanel(alertData) {
        return `<div class="alert alert-info alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Шановний ${alerData.fcs}</strong> реєстрація на рейс № ${alertData.flightNumber} розпочнеться через 15 хвилин.
                    Термінал: №  ${alertData.terminal}. Приємного польоту.
                </div>`
    }

    var timerId = setTimeout(function () { alert(1) }, 1000);
    alert(timerId); // число - идентификатор таймера

    clearTimeout(timerId);
    alert(timerId); // всё ещё число, оно не обнуляется после отмены
});