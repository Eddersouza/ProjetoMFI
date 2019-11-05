function btnCloseDialogError_onClick() {
    closeDialog($('#dialog-error'));
}

function btnCloseDialogSuccess_onClick() {
    closeDialog($('#dialog-success'));
}

function btnCloseDialogWarning_onClick() {
    closeDialog($('#dialog-warning'));
}

function closeDialog(elementDialog) {
    elementDialog.hide();
}

function closeDialogs() {
    closeDialog($('#dialog-error'));
    closeDialog($('#dialog-success'));
    closeDialog($('#dialog-warning'));
}

function dialogErrorShowMessages(messages) {
    let spanText = $('#alertError');
    let divMessage = $('#dialog-error');

    dialogOpenMessage(spanText, messages);
    divMessage.show();
}

function dialogSuccessShowMessages(messages) {
    let spanText = $('#alertSuccess');
    let divMessage = $('#dialog-success');

    dialogOpenMessage(spanText, messages);
    divMessage.show();
}

function dialogWarningShowMessages(messages) {
    let spanText = $('#alertMessage');
    let divMessage = $('#dialog-warning');

    dialogOpenMessage(spanText, messages);
    divMessage.show();
}

function dialogOpenMessage(elementSpan, messages) {
    elementSpan.text('');
    let messagesToShow = messages || [];

    for (var i = 0; i < messagesToShow.length; i++) {
        elementSpan.append(messagesToShow[i] + '<br />');
    }
}

$(document).delegate('#btnCloseDialogError', 'click', btnCloseDialogError_onClick);
$(document).delegate('#btnCloseDialogSuccess', 'click', btnCloseDialogSuccess_onClick);
$(document).delegate('#btnCloseDialogWarning', 'click', btnCloseDialogWarning_onClick);