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