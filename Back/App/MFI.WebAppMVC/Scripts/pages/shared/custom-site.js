
function apiAjax(method, dataType, contentType, data, url, apiAjaxOnDone, apiAjaxOnFail, apiAjaxOnComplete) {
    $.ajax({
        contentType: contentType,
        data: JSON.stringify(data),
        dataType: dataType,
        method: method,
        url: url,
    }).done(function (data, textStatus, jqXHR) {
        if (apiAjaxOnDone !== null)
            apiAjaxOnDone(data, textStatus, jqXHR);
    }).fail(function (jqXHR, textStatus, errorThrown) {
        if (apiAjaxOnFail !== null)
            apiAjaxOnFail(jqXHR, textStatus, errorThrown);
    }).always(function () {
        if (apiAjaxOnComplete !== null)
            apiAjaxOnComplete();
    });
}

function blockPage(block) {
    if (block) {
        $.blockUI({ message: $('#domMessage') });
    }
    else {
        $.unblockUI();
    }
}

function getObjectJSONFromForm(fieldClassName) {
    let formElements = $(fieldClassName);

    let newObjectForm = {};

    for (var i = 0; i < formElements.length; i++) {
        newObjectForm[formElements[i].name] = formElements[i].value;
    }

    return newObjectForm;
}

function resultApiComplete() {
    blockPage(false);
}