//console.log('userID', userID);
$(document).ready(function () {
    const userID = localStorage.getItem("userID");
    var listMessages = [];
    var indexMessages = 0;
    $.ajax({
        type: 'get',
        url: `/api/message/${userID}`,
        datatype: "json",
        success: function (message) {
            if (message.noFlight) {
                return;
            }

            localStorage.setItem("terminal", message.terminal);

            if (message.timeBeforeFlight - 15 > 0) {
                listMessages[indexMessages] = setTimeout(function () { createAlerts(message, true);}, (message.timeBeforeFlight - 15) * 60000);
                indexMessages++;
            }

            listMessages[indexMessages] = setTimeout(function () {
                createAlerts(message, false);
            }, message.timeBeforeFlight * 60000);
            indexMessages++;
            
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

    setInterval(function () { chechChangesFly(); }, 1000);

    function chechChangesFly() {
        const terminal = localStorage.getItem("terminal");
        $.ajax({
            type: 'get',
            url: `/api/check/${userID}/A`,
            datatype: "json",
            success: function (data) {
                console.log(data);
            },
            error: function (xhr) {
                console.log("error", xhr)
            }
        });
    }
    //function check

    function createAlerts(alertlList, isStart) {
        var parent = $('.alert_list');
        parent.append(getTemplatePanel(alertlList, isStart))
        //$(".panel-group > .panel-info").remove();
        //panelList.forEach(function (item, index) {
        //    parent.append(getTemplatePanel(item, index, index == panelList.length - 1));
        //});
    }
    // добавить текущее время
    // + 1) Шановний ФІО реєстрація на рейс №Номеррейсу розпочнеться через 15 хвилин.Термінал: №НомерТерміналу.Приємного польоту.
    //2) Шановний ФІО реєстрація буде затримана на ЧасЗатримки Термінал: №НомерТерміналу.Дякуємо за  розуміння.Приємного польоту.
    //3) Шановний ФІО реєстрація на рейс №Номеррейсу розпочалася.Термінал: №НомерТерміналу.Приємного польоту.
    function getTemplatePanel(alertData, isStart) {
        const timeCreatingPanel = new Date();
        const wait = isStart ? "розпочнеться через 15 хвилин" : "розпочалася";
        return `<div class="alert alert-info alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Шановний ${alertData.fcs}</strong> реєстрація на рейс № ${alertData.flightNumber} ${wait}.
                    <p>Термінал: №  ${alertData.terminal}. Приємного польоту.</p>
                    <span class="text-danger">Відправлено в ${timeCreatingPanel.getHours()}:${timeCreatingPanel.getMinutes()}</span >
                </div>`
        return `<div class="alert alert-info alert-dismissible" role="alert">
                    <button type="button" class="close" data-dismiss="alert" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                    <strong>Шановний ${alertData.fcs}</strong> реєстрація на рейс № ${alertData.flightNumber} ${wait}.
                    <p>Термінал: №  ${alertData.terminal}. Приємного польоту.</p>
                    <span class="text-danger">Відправлено в ${timeCreating.getHours()}:${timeCreating.getMinutes()}</span >
                </div>`
    }

    //var timerId = setTimeout(function () { alert(1) }, 1000);
    //alert(timerId); // число - идентификатор таймера

    //clearTimeout(timerId);
    //alert(timerId); // всё ещё число, оно не обнуляется после отмены
});