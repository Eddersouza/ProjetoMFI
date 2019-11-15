function btnCreateProvider_OnClick() {
    createNewProvider();
}

function createNewProvider() {
    let urlNewClientProvider = $('#urlNewClientProvider').val();

    let newProvider = getObjectJSONFromForm('.new-provider-form');

    if (validPassword(newProvider)) {
        blockPage(true);

        apiAjax('POST', 'json', 'application/json',
            newProvider, urlNewClientProvider,
            createNewProviderSuccess, createNewProviderAlert, resultApiComplete);
    }
}

function createNewProviderAlert(jqXHR, textStatus, errorThrown) {
    let status = jqXHR.status;

    let messages = jqXHR.responseJSON.Warnings || [];

    if (status >= 400 && status < 500) {

        dialogWarningShowMessages(messages);
    }
    else {
        dialogErrorShowMessages(messages);
    }
}

function createNewProviderSuccess() {
    let messages = [];
    messages.push('Cliente criado com sucesso.');
    dialogSuccessShowMessages(messages);

    let urlLogin = $('#urlLogin').val();

    let user = getObjectJSONFromForm('.new-provider-form');

    post_to_url(urlLogin, user, 'POST');
}

function onDocumentNewProviderReady() {
    setNewRequestActions();
}

function setNewRequestActions() {
    $('body').delegate('#btnCreateProvider', 'click', btnCreateProvider_OnClick);
}

function validPassword(requester) {
    if (requester.password !== requester.passwordConfirm) {
        let messages = [];
        messages.push('O campo de Senha e Confirmação de Senha devem ser iguais.');

        dialogWarningShowMessages(messages);

        return false;
    }

    return true;
}

$(document).ready(onDocumentNewProviderReady);

$(document).ready(function () {
    //Initialize tooltips
    $('.nav-tabs > li a[title]').tooltip();

    //Wizard
    $('a[data-toggle="tab"]').on('show.bs.tab', function (e) {

        var $target = $(e.target);

        if ($target.parent().hasClass('disabled')) {
            return false;
        }
    });

    $(".next-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        $active.next().removeClass('disabled');
        nextTab($active);

    });
    $(".prev-step").click(function (e) {

        var $active = $('.wizard .nav-tabs li.active');
        prevTab($active);

    });
});

function nextTab(elem) {
    $(elem).next().find('a[data-toggle="tab"]').click();
}
function prevTab(elem) {
    $(elem).prev().find('a[data-toggle="tab"]').click();
}