//console.log('userID', userID);
$(document).ready(function () {
    console.log('userID', userID);
    $.ajax({
        type: 'get',
        url: `/api/message/${userID}`,
        datatype: "json",
        success: function (historylist) {
            createalerts(historylist);
        },
        error: function (xhr) {
            console.log("error",xhr)
        //var errormessage = json.parse(xhr.responsetext).message;
        //    swal({
        //        title: errormessage,
        //        type: "error"
        //    });
        }
            //sessionstorage.setitem('partsdata', json.stringify(jsondata));

            //partselect.append('<option value="" selected disabled>select a part</option>');

            //$.each(jsondata, function (index, part) {
            //    partselect.append('<option value="' + part + '">' + part + '</option>');
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