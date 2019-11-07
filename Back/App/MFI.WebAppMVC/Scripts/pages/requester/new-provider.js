function btnCreateProvider_OnClick() {
    let formElements = $('.new-requester-form');

    let newObjectForm = {};

    for (var i = 0; i < formElements.length; i++) {
        newObjectForm[formElements[i].name] = formElements[i].value;
    }
}


function onDocumentNewProviderReady() {
    setNewRequestActions();
}

function setNewRequestActions() {
    $('body').delegate('#btnCreateProvider', 'click', btnCreateProvider_OnClick);
}

$(document).ready(onDocumentNewProviderReady);