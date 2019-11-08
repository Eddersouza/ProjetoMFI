function btnCleanRequester_OnClick() {
    cleanFields();
    closeDialogs();
}

function btnCreateRequester_onClick() {
    createNewRequester();
}

function cleanFields() {
    $('#txtEmail').val('');
    $('#txtName').val('');
    $('#txtPassword').val('');
    $('#txtPassword').val('');
}

function createNewRequester() {
    let urlNewClientRequester = $('#urlNewClientRequester').val();

    let newRequesters = getNewRequesterData();

    if (validPassword(newRequesters)) {
        blockPage(true);

        apiAjax('POST', 'json', 'application/json',
            newRequesters, urlNewClientRequester,
            createNewRequesterSuccess, createNewRequesterAlert, resultApiComplete);
    }
}

function createNewRequesterAlert(jqXHR, textStatus, errorThrown) {
    let status = jqXHR.status;

    let messages = jqXHR.responseJSON.Warnings || [];

    if (status >= 400 && status < 500) {

        dialogWarningShowMessages(messages);
    }
    else {
        dialogErrorShowMessages(messages);
    }
}

function createNewRequesterSuccess() {
    let messages = [];
    messages.push('Cliente criado com sucesso.');
    dialogSuccessShowMessages(messages);
}

function getNewRequesterData() {
    let fieldEmail = $('#txtEmail');
    let fieldName = $('#txtName');
    let fieldPassword = $('#txtPassword');
    let fieldConfirmPassword = $('#txtPasswordConfirm');

    let newRequesterData = {
        Email: fieldEmail.val(),
        Name: fieldName.val(),
        Password: fieldPassword.val(),
        PasswordConfirm: fieldConfirmPassword.val()
    };

    return newRequesterData;
}

function onDocumentReady() {
    setActions();
}

function setActions() {
    $('body').delegate('#btnCleanRequester', 'click', btnCleanRequester_OnClick);
    $('body').delegate('#btnCreateRequester', 'click', btnCreateRequester_onClick);
}

function validPassword(requester) {
    if (requester.Password !== requester.PasswordConfirm) {
        let messages = [];
        messages.push('O campo de Senha e Confirmação de Senha devem ser iguais.');

        dialogWarningShowMessages(messages);

        return false;
    }

    return true;
}

$(document).ready(onDocumentReady);