function onDocumentProviderListReady() {
    getCardList();
}

function getCardList() {
    let urlClientProviderCardList = $('#urlClientProviderCardList').val();
    blockPage(true);

    apiAjax('GET', 'html', 'application/json',
        {}, urlClientProviderCardList,
        getCardListSuccess, getCardListError, resultApiComplete);

}

function getCardListSuccess(data) {
    $('#div-card-provider').html(data);
}

function getCardListError(jqXHR) {
    let status = jqXHR.status;

    let messages = jqXHR.responseJSON.Warnings || [];

    if (status >= 400 && status < 500) {

        dialogWarningShowMessages(messages);
    }
    else {
        dialogErrorShowMessages(messages);
    }
}

$(document).ready(onDocumentProviderListReady);